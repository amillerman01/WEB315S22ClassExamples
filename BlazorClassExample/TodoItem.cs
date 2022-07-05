public class TodoItem
{
    // we can declare the constructor here it we want to do something in it
    public TodoItem(){
        System.Console.WriteLine("Created a new instance of a TodoItem");
    }

    // a second constructor that can take a custom string value, and will set the isDone value to true by default
    public TodoItem(string title){
        Title = title;
        IsDone = true;
        System.Console.WriteLine("Created a new instance of a TodoItem, with a custom string");
    }

    public string Title { get; set; }
    public bool IsDone { get; set; }
}