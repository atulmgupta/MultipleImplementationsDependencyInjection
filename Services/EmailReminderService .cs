using MultipleImplementationsDependencyInjection.Services.Common;

namespace MultipleImplementationsDependencyInjection.Services
{
    public class EmailReminderService : ReminderServiceDecorator
    {
        public override string CallingService => "EmailReminderService";

        public EmailReminderService()
        {
            Console.WriteLine("EmailReminderService constructor");
        }
    }
}
