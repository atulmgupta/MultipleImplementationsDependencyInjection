using MultipleImplementationsDependencyInjection.Services;
using MultipleImplementationsDependencyInjection.Services.Common;

namespace MultipleImplementationsDependencyInjection
{
    public delegate IReminderService IReminderServiceResolver(ServiceType key);
}
