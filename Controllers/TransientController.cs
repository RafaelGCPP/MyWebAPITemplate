using Microsoft.AspNetCore.Mvc;
using ServiceScopeTest.Services;
using ServiceScopeTest.Services.Interfaces;
using System.Text;

namespace ServiceScopeTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransientController : ControllerBase
    {
        private readonly IMyTransient _transient;
        private readonly MyTransientPhaseI _phaseI;
        private readonly MyTransientPhaseII _phaseII;
        public TransientController(IMyTransient transient, MyTransientPhaseI phaseI, MyTransientPhaseII phaseII)
        {
            _transient = transient;
            _phaseI = phaseI;
            _phaseII = phaseII;

        }

        [HttpGet]
        public string Get()
        {
            StringBuilder _sb = new();
            _sb.AppendLine(_transient.GetMyName());
            _sb.AppendLine(_phaseI.GetMyName());
            _sb.AppendLine(_phaseII.GetMyName());

            return _sb.ToString();
        }
    }
}
