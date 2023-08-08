using Microsoft.AspNetCore.Mvc;
using MultipleImplementationsDependencyInjection.Services;

namespace MultipleImplementationsDependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        readonly IReminderService _myService;        
        public EmailController(IEnumerable<IReminderService> reminderServices)
        {
            _myService = reminderServices.FirstOrDefault(s => s.GetType() == typeof(EmailReminderService));
        }

        [HttpGet]
        [Route("GetMyService")]
        public string GetMyService()
        {
            return _myService.SendReminder();
        }

    }
}
