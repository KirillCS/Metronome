using System;

namespace Metronome.UI.Exceptions
{
    public class ServiceNotConfiguredException : Exception
    {
        public ServiceNotConfiguredException()
            : base("Service is not configured")
        {
        }

        public ServiceNotConfiguredException(string serviceTypeName)
            : this(serviceTypeName, $"Service with type {serviceTypeName} is not configured")
        {
        }

        public ServiceNotConfiguredException(string serviceTypeName, string message)
            : base(message)
        {
            this.ServiceTypeName = serviceTypeName ?? string.Empty;
        }

        public string ServiceTypeName { get; }
    }
}
