public class TodoItem
{
    public TodoItem(){
        System.Console.WriteLine("Created a new instance of a TodoItem");
    }
    public string Title { get; set; }
    public bool IsDone { get; set; }
}