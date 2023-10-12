using MultipleImplementationsDependencyInjection.Services.Common;

namespace MultipleImplementationsDependencyInjection.Services
{
    public class EmailReminderService : ReminderServiceDecorator
    {        
        public override string CallingService => "EmailReminderService";
        
    }
}
