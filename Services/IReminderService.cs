namespace MultipleImplementationsDependencyInjection.Services
{
    public interface IReminderService
    {
        string SendReminder();

        string PostMessage(string value);
    }
}
