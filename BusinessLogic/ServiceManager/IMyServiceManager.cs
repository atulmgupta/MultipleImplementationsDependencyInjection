namespace MultipleImplementationsDependencyInjection.ServiceManager
{
    public interface IMyServiceManager : IDisposable
    {
        string StartProcess(string command);
    }
}
