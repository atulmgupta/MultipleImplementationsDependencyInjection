using MultipleImplementationsDependencyInjection.Services;
using MultipleImplementationsDependencyInjection.Services.Common;

namespace MultipleImplementationsDependencyInjection
{
    public delegate IReminderService ServiceResolver(ServiceType serviceType);
}
