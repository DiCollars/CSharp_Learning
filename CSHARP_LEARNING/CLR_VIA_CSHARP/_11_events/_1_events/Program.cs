var manager = new MailManager();
_ = new Fax(manager);
_ = new SMS(manager);
manager.SimulateNewMail("me", "you", "love");

Console.ReadKey(false);

public class NewMailEventArgs : EventArgs
{
    private readonly string _from, _to, _subject;

    public NewMailEventArgs(
        string from, 
        string to,
        string subject)
    {
        _from = from;
        _to = to;
        _subject = subject;
    }

    public string From { get { return _from; } }

    public string To { get { return _to; } }

    public string Subject { get { return _subject; } }
}

public class MailManager
{
    // void EventHandler<TEventArgs>(object? sender, TEventArgs e)
    public event EventHandler<NewMailEventArgs> NewMail;

    protected virtual void OnNewMail(NewMailEventArgs e)
    {
        e.Raise(this, ref NewMail);
    }

    public void SimulateNewMail(
        string from, 
        string to, 
        string subject)
    {
        var e = new NewMailEventArgs(from, to, subject);
        OnNewMail(e);
    }
}

public static class EventArgExtwnsions
{
    public static void Raise<TEventArgs>(
        this TEventArgs e,
        object sender,
        ref EventHandler<TEventArgs> eventDelegate)
    {
        var temp = Volatile.Read(ref eventDelegate);

        if (temp != null) temp(sender, e);
    }
}

public sealed class Fax
{
    public Fax(MailManager mm)
    {
        mm.NewMail += FaxMessage;
    }

    public void UnRegestr(MailManager mm)
    {
        mm.NewMail -= FaxMessage;
    }

    private void FaxMessage(object o, NewMailEventArgs e)
    {
        Console.WriteLine($"Faxing mail message: {e.From} - {e.To} - {e.Subject}");
    }
}

public sealed class SMS
{
    public SMS(MailManager mm)
    {
        mm.NewMail += FaxMessage;
    }   

    public void UnRegestr(MailManager mm)
    {
        mm.NewMail -= FaxMessage;
    }

    private void FaxMessage(object o, NewMailEventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Faxing SMS message: {e.From} - {e.To} - {e.Subject}");
        Console.ResetColor();
    }
}