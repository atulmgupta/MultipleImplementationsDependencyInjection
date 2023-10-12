using MultipleImplementationsDependencyInjection.Services.Common;

namespace MultipleImplementationsDependencyInjection.Services
{
    public class PushNotificationReminderService : ReminderServiceDecorator
    {
        public override string CallingService => "PushNotificationReminderService";
    }
}
