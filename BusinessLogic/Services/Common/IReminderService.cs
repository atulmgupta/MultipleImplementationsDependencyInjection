namespace MultipleImplementationsDependencyInjection.Services.Common
{
    public interface IReminderService
    {
        string SendReminder();

        string PostMessage(string value);
    }
}
