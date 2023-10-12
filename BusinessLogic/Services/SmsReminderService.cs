using MultipleImplementationsDependencyInjection.Services.Common;

namespace MultipleImplementationsDependencyInjection.Services
{
    public class SmsReminderService : ReminderServiceDecorator
    {
        public override string CallingService => "SmsReminderService";
    }
}
