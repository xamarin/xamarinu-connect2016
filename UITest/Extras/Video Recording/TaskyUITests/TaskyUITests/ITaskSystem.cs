namespace TaskyUITests
{
    public interface ITaskSystem
    {
    	ITaskSystem Add();
        ITaskSystem Delete(string name);

    	ITaskSystem SetName(string name);
    	ITaskSystem SetNotes (string notes);
    	ITaskSystem Save();
    	ITaskSystem Cancel();

    	bool HasItem(string itemName);
    }
}

