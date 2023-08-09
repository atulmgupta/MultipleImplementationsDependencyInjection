namespace MultipleImplementationsDependencyInjection.Services.Common
{
    public abstract class ReminderServiceDecorator : IReminderService
    {        
        public abstract string CallingService { get; }

        public string PostMessage(string value)
        {
            throw new NotImplementedException();
        }

        public virtual string SendReminder()
        {
            return $"Decorated: Called => {CallingService}";
        }
    }
}
