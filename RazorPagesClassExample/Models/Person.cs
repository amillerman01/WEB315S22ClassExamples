namespace RazorPagesClassExample.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string somename, int someage){
            this.Name = somename;
            this.Age = someage;
        }
    }
}