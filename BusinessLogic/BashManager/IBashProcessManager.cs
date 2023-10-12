namespace BusinessLogic.BashManager
{
    public interface IBashProcessManager
    {
        string StartBashProcessManager(string command);

        string GetExecutionStatus(string command);
    }
}
