using Microsoft.AspNetCore.Mvc;
using MultipleImplementationsDependencyInjection.ServiceManager;
using MultipleImplementationsDependencyInjection.Services.Common;

namespace MultipleImplementationsDependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IReminderServiceResolver serviceResolver;
        private readonly IReminderService _myService;
        private readonly IMyServiceManager _bashProcessManager;
        readonly ILogger<EmailController> _logger;
        public EmailController(IReminderServiceResolver serviceResolver, IMyServiceManager bashProcessManager,
            ILogger<EmailController> logger)
        {
            this._logger = logger;
            this.serviceResolver = serviceResolver;
            this._myService = this.serviceResolver(ServiceType.Email);
            Console.WriteLine("EmailController");
            this._bashProcessManager = bashProcessManager;
        }

        [HttpGet]
        [Route("GetMyService")]
        public string GetMyService()
        {
            return this._bashProcessManager.StartProcess("ls");
            //return this._myService.SendReminder();
        }

    }
}
