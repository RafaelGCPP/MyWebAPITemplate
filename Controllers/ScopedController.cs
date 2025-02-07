using Microsoft.AspNetCore.Mvc;
using ServiceScopeTest.Services;
using ServiceScopeTest.Services.Interfaces;
using System.Text;

namespace ServiceScopeTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScopedController : ControllerBase
    {
        private readonly IMyScoped _myScoped;
        private readonly MyScopedPhaseI _phaseI;
        private readonly MyScopedPhaseII _phaseII;
        public ScopedController(IMyScoped myScoped, MyScopedPhaseI phaseI, MyScopedPhaseII phaseII)
        {
            _myScoped = myScoped;
            _phaseI = phaseI;
            _phaseII = phaseII;

        }

        [HttpGet]
        public string Get()
        {
            StringBuilder _sb = new();
            _sb.AppendLine(_myScoped.GetMyName());
            _sb.AppendLine(_phaseI.GetMyName());
            _sb.AppendLine(_phaseII.GetMyName());

            return _sb.ToString();
        }
    }
}
