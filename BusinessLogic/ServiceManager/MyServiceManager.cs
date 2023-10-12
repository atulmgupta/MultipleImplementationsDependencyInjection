using MultipleImplementationsDependencyInjection.Services.Common;

namespace MultipleImplementationsDependencyInjection.ServiceManager
{
    public class MyServiceManager : IMyServiceManager
    {
        readonly IReminderServiceResolver _serviceResolver;
        readonly IReminderService emailService;
        readonly IReminderService smsService;
        readonly IReminderService pushService;

        public MyServiceManager(IReminderServiceResolver serviceResolver)
        {
            this._serviceResolver = serviceResolver;
            this.emailService = this._serviceResolver(ServiceType.Email);
            this.smsService = this._serviceResolver(ServiceType.Sms);
            this.pushService = this._serviceResolver(ServiceType.Push);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string StartProcess(string command)
        {
            var email = this.emailService.SendReminder();
            var sms = this.smsService.SendReminder();
            var push = this.pushService.SendReminder();
            return $"Email: {email} | Sms: {sms} | Push: {push}";
        }
    }
}
