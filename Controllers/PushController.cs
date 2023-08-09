using Microsoft.AspNetCore.Mvc;
using MultipleImplementationsDependencyInjection.Services.Common;

namespace MultipleImplementationsDependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PushController : ControllerBase
    {
        readonly IReminderServiceResolver reminderServiceResolver;
        readonly IReminderService _myService;
        public PushController(IReminderServiceResolver reminderServiceResolver)
        {
            this.reminderServiceResolver = reminderServiceResolver;
            this._myService = this.reminderServiceResolver(ServiceType.Push);
        }

        [HttpGet]
        [Route("HomeB/GetMyService")]
        public string GetMyService()
        {            
            return this._myService.SendReminder();
        }
    }
}
