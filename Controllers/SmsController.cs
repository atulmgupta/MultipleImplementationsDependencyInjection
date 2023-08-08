using Microsoft.AspNetCore.Mvc;
using MultipleImplementationsDependencyInjection.Services;

namespace MultipleImplementationsDependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmsController : ControllerBase
    {
        readonly IReminderService _myService;
        readonly IEnumerable<IReminderService> _myServices;
        public SmsController(IEnumerable<IReminderService> reminderServices)
        {
            _myService = reminderServices.FirstOrDefault(s => s.GetType() == typeof(SmsReminderService));
        }

        [HttpGet]
        [Route("GetMyService")]
        public string GetMyService()
        {
            return _myService.SendReminder();
        }        
    }
}
