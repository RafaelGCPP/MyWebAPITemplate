using ServiceScopeTest.Services.Interfaces;
using System.Text;

namespace ServiceScopeTest.Services
{
    public class MyScoped : IMyScoped, IDisposable

    {
        private bool disposedValue;
        private readonly HttpContext? httpContext;
        private readonly ILogger<MyScoped> logger;

        public MyScoped(IHttpContextAccessor httpContextAccessor, ILogger<MyScoped> logger)
        {
            httpContext = httpContextAccessor.HttpContext;
            this.logger = logger;
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                   logger.LogInformation("Disposing MyScoped ({hash}): Managed state", GetHashCode());
                }

                logger.LogInformation("Disposing MyScoped ({hash}): Unmanaged state", GetHashCode());
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
            _sb.AppendLine($"MyScoped ({GetHashCode().ToString()})");
            return _sb.ToString();
        }
    }

    public class MyScopedPhaseI
    {
        private readonly IMyScoped _scoped;
        public MyScopedPhaseI(IMyScoped scoped)
        {
            _scoped = scoped;
        }

        public string GetMyName()
        {
            return $"MyScopedPhaseI - {_scoped.GetMyName()} ";
        }

    }
    public class MyScopedPhaseII
    {
        private readonly IMyScoped _scoped;
        public MyScopedPhaseII(IMyScoped scoped)
        {
            _scoped = scoped;
        }

        public string GetMyName()
        {
            return $"MyScopedPhaseII - {_scoped.GetMyName()} ";
        }

    }
}
