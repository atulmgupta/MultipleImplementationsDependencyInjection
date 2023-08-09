using Microsoft.AspNetCore.Mvc;
using MultipleImplementationsDependencyInjection.Services.Common;

namespace MultipleImplementationsDependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IReminderServiceResolver serviceResolver;  
        private readonly IReminderService _myService;        
        public EmailController(IReminderServiceResolver serviceResolver)
        {            
            this.serviceResolver = serviceResolver;            
            this._myService = this.serviceResolver(ServiceType.Email);
            Console.WriteLine("EmailController");
        }

        [HttpGet]
        [Route("GetMyService")]
        public string GetMyService()
        {            
            return this._myService.SendReminder();
        }

    }
}
