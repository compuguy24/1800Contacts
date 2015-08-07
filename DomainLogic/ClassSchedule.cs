namespace DomainLogic
{
    public class ClassSchedule
    {
        public ClassSchedule(string[] listOfCourses)
        {
            ListOfCourses = listOfCourses;
        }

        public string[] ListOfCourses { get; set; }
    }
}
