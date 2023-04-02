public delegate void Notify(); // delegate

public class ProcessBusinessLogic
{
    //private const int a = 10;
    public event Notify ProcessCompleted; // event

    public void StartProcess()
    {
        Console.WriteLine("Process Completed!");
        // some code here
        OnProcessCompleted();
        //ProcessCompleted?.Invoke();
    }
    
    protected virtual void OnProcessCompleted()
    {
        ProcessCompleted?.Invoke();
    }
    
}