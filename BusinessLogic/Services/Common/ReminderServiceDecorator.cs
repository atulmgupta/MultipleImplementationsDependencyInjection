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
            Console.WriteLine($"Decorated: Calling => {CallingService}");
            _ = Process();
            return $"Decorated: Called => {CallingService}";
        }

        private static async Task<string> Process()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Decorated: {i}");
                await Task.Delay(1000);
            }
            return "Decorated: Done";
        }
    }
}
