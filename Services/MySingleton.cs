using ServiceScopeTest.Services.Interfaces;

namespace ServiceScopeTest.Services

{
    public abstract class MySingleton : IMySingleton, IDisposable
    {
        ILogger<MySingleton> logger;
        private bool disposedValue;

        protected MySingleton(ILogger<MySingleton> logger)
        {
            this.logger = logger;
            logger.LogInformation("Creating MySingleton Base");

        }

        public abstract string GetMyName();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    logger.LogInformation("Disposing MySingleton Base: Managed state");
                }
                logger.LogInformation("Disposing MySingleton Base: Unmanaged state");
                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~MySingleton()
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
    }
    public class MySingletonTypeI : MySingleton, IMySingleton
    {
        private readonly ILogger<MySingletonTypeI> logger;
        private bool disposedValue;

        public MySingletonTypeI(ILogger<MySingletonTypeI> logger) : base(logger)
        {
            this.logger = logger;
            logger.LogInformation("Creating MySingleton Type I");
        }

        public override string GetMyName()
        {
            return "MySingleton Type I (" + GetHashCode().ToString() + ")";
        }
        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    logger.LogInformation("Disposing MySingleton TypeI: Managed state");
                }
                logger.LogInformation("Disposing MySingleton TypeI: Unmanaged state");
                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }
    }

    public class MySingletonTypeII : MySingleton, IMySingleton
    {
        private readonly ILogger<MySingletonTypeII> logger;
        private bool disposedValue;

        public MySingletonTypeII(ILogger<MySingletonTypeII> logger) : base(logger)
        {
            this.logger = logger;
            logger.LogInformation("Creating MySingleton Type II");
        }

        public override string GetMyName()
        {
            return "MySingleton Type II (" + GetHashCode().ToString() + ")";
        }
        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    logger.LogInformation("Disposing MySingleton TypeII: Managed state");
                }
                logger.LogInformation("Disposing MySingleton TypeII: Unmanaged state");
                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }

        }
    }
}
