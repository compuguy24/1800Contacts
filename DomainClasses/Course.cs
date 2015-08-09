namespace DomainClasses
{
    public class Course
    {
        public string Title { get; private set; }
        public Course Dependency { get; set; }

        public Course(string title, Course dependency)
        {
            Title = title;
            Dependency = dependency;
        }
    }
}
