using ServiceScopeTest.Services.Interfaces;
using System.Text;

namespace ServiceScopeTest.Services
{
    public class MyTransient : IMyTransient, IDisposable

    {
        private bool disposedValue;
        private readonly HttpContext? httpContext;
        private readonly IMyScoped _myScoped;
        private readonly ILogger<MyTransient> _logger;

        public MyTransient(IHttpContextAccessor httpContextAccessor, IMyScoped myScoped, ILogger<MyTransient> logger)
        {
            httpContext = httpContextAccessor.HttpContext;       
            _myScoped= myScoped;
            _logger = logger;
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _logger.LogInformation("Disposing MyTransient ({hash}): managed state", GetHashCode() );
                }
                _logger.LogInformation("Disposing MyTransient ({hash}): unmanaged state", GetHashCode());

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~MyScoped()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public string GetMyName()
        {
            StringBuilder _sb = new StringBuilder();
            
            _sb.AppendLine(httpContext?.Request.Path.ToString());
            _sb.AppendLine($"MyTransient ({GetHashCode().ToString()})");
            _sb.AppendLine($"{_myScoped.GetMyName()}");
            return _sb.ToString();
        }
    }

    public class MyTransientPhaseI
    {
        private readonly IMyTransient _transient;
        private readonly IMyScoped _myScoped;

        public MyTransientPhaseI(IMyTransient transient, IMyScoped myScoped)
        {
            _transient = transient;
            _myScoped = myScoped;
        }

        public string GetMyName()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine($"MyTransientPhaseI - {_transient.GetMyName()} ");
            _sb.AppendLine($"{_myScoped.GetMyName()}");
            return _sb.ToString();
        }

    }
    public class MyTransientPhaseII
    {
        private readonly IMyTransient _transient;
        private readonly IMyScoped _myScoped;

        public MyTransientPhaseII(IMyTransient transient, IMyScoped myScoped)
        {
            _transient = transient;
            _myScoped = myScoped;
        }

        public string GetMyName()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine($"MyTransientPhaseII - {_transient.GetMyName()} ");
            _sb.AppendLine($"{_myScoped.GetMyName()}");
            return _sb.ToString();
        }

    }

}
