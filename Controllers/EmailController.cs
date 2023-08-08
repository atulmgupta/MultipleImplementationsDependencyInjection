using Microsoft.AspNetCore.Mvc;
using MultipleImplementationsDependencyInjection.Services;
using MultipleImplementationsDependencyInjection.Services.Common;

namespace MultipleImplementationsDependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        readonly ServiceResolver serviceResolver;  
        readonly IReminderService _myService;
        public EmailController(ServiceResolver serviceResolver)
        {
            this.serviceResolver = serviceResolver;
            this._myService = serviceResolver(ServiceType.Email);
        }

        [HttpGet]
        [Route("GetMyService")]
        public string GetMyService()
        {
            return _myService.SendReminder();
        }

    }
}
