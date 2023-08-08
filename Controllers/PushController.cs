using Microsoft.AspNetCore.Mvc;
using MultipleImplementationsDependencyInjection.Services;

namespace MultipleImplementationsDependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PushController : ControllerBase
    {
        readonly IReminderService _myService;
        readonly IEnumerable<IReminderService> _myServices;
        public PushController(IEnumerable<IReminderService> reminderServices)
        {
            _myService = reminderServices.FirstOrDefault(s => s.GetType() == typeof(PushNotificationReminderService));
        }

        [HttpGet]
        [Route("HomeB/GetMyService")]
        public string GetMyService()
        {
            var service = _myServices.FirstOrDefault(s => s.GetType() == typeof(SmsReminderService));
            return service.SendReminder();
        }
    }
}
