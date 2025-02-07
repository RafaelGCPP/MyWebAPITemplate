using Microsoft.AspNetCore.Mvc;
using ServiceScopeTest.Services.Interfaces;
using System.Text;

namespace ServiceScopeTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingletonControllerII : ControllerBase
    {
        private readonly IEnumerable<IMySingleton> _mySingletons;
        public SingletonControllerII(IEnumerable<IMySingleton> mySingletons)
        {
            _mySingletons = mySingletons;
        }
        [HttpGet]
        public string Get()
        {
            StringBuilder _sb = new StringBuilder();
            int i = 0;
            foreach (var _mySingleton in _mySingletons)
            {
                _sb.AppendLine($"[{i++}]:" + _mySingleton.GetMyName());
            }
            return _sb.ToString();
        }
    }
}
