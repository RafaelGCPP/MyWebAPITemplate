using Microsoft.AspNetCore.Mvc;
using ServiceScopeTest.Services.Interfaces;

namespace ServiceScopeTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingletonController : ControllerBase
    {
        private readonly IMySingleton _mySingleton;
        public SingletonController(IMySingleton mySingleton)
        {
            _mySingleton = mySingleton;
        }
        [HttpGet]
        public string Get()
        {
            return _mySingleton.GetMyName();
        }
    }
}
