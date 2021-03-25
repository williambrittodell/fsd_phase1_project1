using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPhase1.Builders
{
    public class ConcreteTeacherBuilder : AbstractTeacherBuilder
    {
        protected override void BuildID(Teacher teacher)
        {
            Console.WriteLine("Enter an ID for the teacher");
            var idAsText = Console.ReadLine();
            teacher.ID = int.Parse(idAsText);
        }

        protected override void BuildFirstName(Teacher teacher)
        {
            // TODO: prompt, read and assign first name DONE
            Console.WriteLine("Enter a first name for the teacher");
            var firstName = Console.ReadLine();
            teacher.FirstName = firstName;
        }

        // TODO add a builder method for last name (with prompt) DONE
        protected override void BuildLastName(Teacher teacher)
        {
            // TODO: read lastname and assign to teacher property last name DONE
            Console.WriteLine("Enter a last name for the teacher");
            var lastName = Console.ReadLine();
            teacher.LastName = lastName;
        }
    }
}
