using Kafka_Test_App.Lib.Kafka;

var colorArrayr = new[] { "Red", "Green", "Blue", "Black" };
var offset = 0;

while (true)
{
    if (offset >= colorArrayr.Length) offset = 0;
    var message = colorArrayr[offset];

    Console.WriteLine("Send: " + message);

    var producer = new Producer();
    _ = await producer.SendToKafkaAsync(message);

    offset++;
    Thread.Sleep(1000);
}
