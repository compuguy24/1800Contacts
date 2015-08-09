using System;
using System.Linq;
using DomainLogic;

namespace CourseScheduleConsole
{
    public class Program
    {
        private static readonly string[] TestListOfCourses = {
            "Introduction to Paper Airplanes: ",
            "Advanced Throwing Techniques: Introduction to Paper Airplanes",
            "History of Cubicle Siege Engines: Rubber Band Catapults 101",
            "Advanced Office Warfare: History of Cubicle Siege Engines",
            "Rubber Band Catapults 101: ",
            "Paper Jet Engines: Introduction to Paper Airplanes"
        };

        //Notes: 

        // o I'm including a reference project "ReferenceTopologicalSort" that I used to research topological sort (CodeProject)
        // o Referenced http://www.codeproject.com/Articles/869059/Topological-sorting-in-Csharp

        // o The above input is included along with this console project for convenience
        // o The output of this application did not match that listed on the syllabus but I believe it's still topologically correct
        
        // o All prerequits list in a correct order 
        // o Syllabus = A, D, F, B, C, E (all dependency vectors point right)
        // o This App = A, B, D, C, E, F (all dependency vectors point right)
        
        //   - Where:
        //   - A = Introduction to Paper Airplanes
        //   - B = Advanced Throwing Techniques
        //   - C = History of Cubicle Siege Engines
        //   - D = Rubber Band Catapults 101
        //   - E = Advanced Office Warfare
        //   - F = Paper Jet Engines
        
        //   - Thus:
        //   - A: _
        //   - B: A 
        //   - C: D 
        //   - E: C
        //   - D: _
        //   - F: A

        //   - The linked list graph came out like this
        //   - B, A, null
        //   - E, C, D, null
        //   - F, A
        
        // o I think i could have improved the AddCourse function but I let it stand as it evolved during TDD

        // o I studied the reference project that I included and paired it down to what I needed specifically 
        //   for this project. I kept the visited Dictionary although I experimented with other methods of 
        //   flagging visits but ended up liking it the best. Also, I specifically tested without removing 
        //   the flag just before including the course in the sorted list and I found no difference for the 
        //   purposes of this algorithm.

        // o As this is non-production code, I make no appology for the huge comment block although I agree
        //   with "Uncle" Bob Martin as I'm sure that by the time I commit this, they will have already lied.

        static void Main(string[] args)
        {
            var consoleClassSchedule = (!args.Any()) ? new ClassSchedule(TestListOfCourses) : new ClassSchedule(args);
            Console.WriteLine(consoleClassSchedule.GetSortedClassSchedule());
            Console.ReadLine();
        }
    }
}
