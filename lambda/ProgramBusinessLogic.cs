ProcessBusinessLogic b1 = new ProcessBusinessLogic();
b1.ProcessCompleted += b1_ProcessComplete;
b1.StartProcess();

ProcessBusinessLogic2 b2 = new ProcessBusinessLogic2();
b2.ProcessCompleted += b2_ProcessCompleted; // register with an event
b2.StartProcess();

void b1_ProcessComplete()
{
    Console.WriteLine("Process Completed");
}

void b2_ProcessCompleted(object sender, bool IsSuccessful)
{
    Console.WriteLine("Process " + (IsSuccessful? "Completed Successfully": "failed"));
}