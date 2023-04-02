
public class ProcessBusinessLogic2
{
    //private const int a = 10;
    public event EventHandler<bool> ProcessCompleted; // event

    public void StartProcess()
    {
        try
        {
            Console.WriteLine("Process Started!");

            // some code here

            OnProcessCompleted(true);
        }
        catch(Exception ex)
        {
            OnProcessCompleted(false);
        }
    }
    
    protected virtual void OnProcessCompleted(bool IsSuccessful)
    {
        ProcessCompleted?.Invoke(this, IsSuccessful);
    }
    
}