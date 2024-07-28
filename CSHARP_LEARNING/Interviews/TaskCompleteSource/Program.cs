
// Наше приложение общается с удаленным сервисом: шлет запросы и получает ответы. 
// С удаленным сервером установлено единственное соединение, по которому мы шлем запросы и получаем ответы. 
// Каждый запрос содержит Id (GUID), ответ на запрос содержит его же. 
// Ответы на запросы могут приходить в произвольном порядке и с произвольными задержками. 
// Нам необходимо реализовать интерфейс, который абстрагирует факт такого мультиплексирования. 
// Реализация IRequestProcessor обязана быть потокобезопасной.

// У нас есть готовая реализация интерфейса INetworkAdapter

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

public record Request(Guid Id);

public record Response(Guid Id);

public interface INetworkAdapter
{
    /// Вычитывает очередной ответ
    Task<Response> ReadAsync(CancellationToken cancellationToken);

    /// Отправляет запрос
    Task WriteAsync(Request request, CancellationToken cancellationToken);
}

// Нам нужно реализовать интерфейс IRequestProcessor

public interface IRequestProcessor
{
    /// Запускает обработчик. Гарантированно вызывается 1 раз при старте приложения
    Task RunAsync(CancellationToken cancellationToken);

    Task StopAsync(CancellationToken cancellationToken);

    // При отмене CancellationToken не обязательно гарантировать то, что мы не отправим запрос на сервер, но клиент должен получить отмену задачи
    Task<Response> SendAsync(Request request, CancellationToken cancellationToken);
}

public class RequestProcessor : IRequestProcessor
{
    private readonly INetworkAdapter _networkAdapter;
    private ConcurrentDictionary<Guid, TaskCompletionSource<Response>> _requests;
    private bool _stop = false;

    public RequestProcessor(INetworkAdapter networkAdapter)
    {
        _networkAdapter = networkAdapter;
        _requests = new ConcurrentDictionary<Guid, TaskCompletionSource<Response>>();
    }

    public async Task RunAsync(CancellationToken cancellationToken)
    {
        await Task.Run(async () =>
        {
            var isWait = true;
            while (isWait)
            {
                if (_stop == true)
                {
                    return;
                }

                var result = await _networkAdapter.ReadAsync(cancellationToken);
                _requests[result.Id].SetResult(result);
            }
        });
    }

    public async Task<Response> SendAsync(Request request, CancellationToken cancellationToken)
    {
        await _networkAdapter.WriteAsync(request, cancellationToken);

        var taskEvent = new TaskCompletionSource<Response>();
        _requests.TryAdd(request.Id, taskEvent);

        return await taskEvent.Task;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _stop = true;
    }
}