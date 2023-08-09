using Microsoft.AspNetCore.Mvc;
using MultipleImplementationsDependencyInjection.Services.Common;

namespace MultipleImplementationsDependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmsController : ControllerBase
    {
        readonly IReminderServiceResolver reminderServiceResolver;
        readonly IReminderService _myService;        
        public SmsController(IReminderServiceResolver reminderServiceResolver)
        {
            this.reminderServiceResolver = reminderServiceResolver;
            this._myService = this.reminderServiceResolver(ServiceType.Sms);
        }

        [HttpGet]
        [Route("GetMyService")]
        public string GetMyService()
        {
            return this._myService.SendReminder();
        }        
    }
}
