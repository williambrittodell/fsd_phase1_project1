using ProjectPhase1.Builders;
using ProjectPhase1.Repositories;
using ProjectPhase1.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPhase1.Templates
{
    public class ConcreteTeacherManagementApp : AbstractTeacherAppTemplate
    {
        protected override void loadTeachers()
        {
            var teachersRepository = new PipeDelimitedFileTeachersRepository("teachers.txt");
            var teachersAsList = teachersRepository.Load();
            _teachers = teachersAsList.ToDictionary(t => t.ID); //it means which value represents the key
            Console.WriteLine($"Loaded {_teachers.Count} teachers");
        }

        protected override void saveTeachers(IEnumerable<Teacher> teachers)
        {
            // TODO: Save teachers using the repository DONE
            var teachersRepository = new PipeDelimitedFileTeachersRepository("teachers.txt");            
            teachersRepository.Save(teachers);            
        }

        protected override int getOption()
        {
            // TODO: Get rid of exception DONE
            //throw new NotImplementedException();
            // TODO: Read user input from console, convert to int and return DONE
            var input = Console.ReadLine();
            return int.Parse(input);
        }

        protected override void addTeacher()
        {
            var teacherBuilder = new ConcreteTeacherBuilder();
            var teacher = teacherBuilder.Build();
            _teachers[teacher.ID] = teacher;
        }

        protected override void deleteTeacher()
        {
            Console.WriteLine("Enter ID of teacher to delete");
            var id = int.Parse(Console.ReadLine());

            // TODO: first check if teacher is in dictionary using the id DONE
            if (!_teachers.ContainsKey(id))
            {
                Console.WriteLine($"Teacher with id {id} not found");
            }
            else
            {
                // TODO: remove teacher from dictionary DONE
                _teachers.Remove(id);
                Console.WriteLine("Removed teacher");
            }
        }

        protected override void findTeacher()
        {
            Console.WriteLine("Enter ID of teacher to find");
            var id = int.Parse(Console.ReadLine());

            // TODO: check if teacher not in dictionary DONE
            if (!_teachers.ContainsKey(id))
            {
                Console.WriteLine($"Teacher with id {id} not found");
            }
            else
            {
                // TODO: Write teacher the console DONE
                foreach(var teacher in _teachers)
                {
                    if (teacher.Key == id)
                    {
                        Console.WriteLine($"ID: {teacher.Key}, Full name: {teacher.Value.FirstName} {teacher.Value.LastName}");
                    }
                }
            }            
        }

        protected override void listTeachers(IEnumerable<Teacher> teachers)
        {
            // TODO: loop through all teachers passed as a parameter and write them to the console DONE
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"ID: {teacher.ID}, First name: {teacher.FirstName}, Last name: {teacher.LastName}");
            }
        }

        protected override void sortTeachers()
        {
            Console.WriteLine("You chose to sort teachers");
            Console.WriteLine("How would you like to sort them?");
            Console.WriteLine("1) ID");
            Console.WriteLine("2) Last Name");
            Console.WriteLine("3) First Name");
            
            var option = int.Parse(Console.ReadLine());
            ISortTeachersStrategy sortStrategy = null;
            switch (option)
            {
                //TODO...
                case 1: sortStrategy = new SortTeachersByIDStrategy(); break; // create new strategy to sort by id
                //TODO...
                case 2: sortStrategy = new SortTeachersByLastNameStrategy(); break; // create new strategy to sort by first name (Last name)
                case 3: sortStrategy = new SortTeachersByFirstNameStrategy(); break;
            }

            var sorted = sortStrategy.Sort(_teachers.Values);
            listTeachers(sorted);
        }

        protected override void updateTeacher()
        {
            Console.WriteLine("Enter ID of teacher to update");
            var id = int.Parse(Console.ReadLine());
            if (!_teachers.ContainsKey(id))
            {
                Console.WriteLine($"Did not find teacher with id: {id}");
                return;
            }

            var teacher = _teachers[id];
            Console.WriteLine("You selected...");
            Console.WriteLine(teacher);

            // TODO... read and assign new values for first and last name
                        
            // TODO: read first name DONE
            Console.WriteLine($"This is the first name: {teacher.FirstName}");
            // TODO: update first name of teacher DONE
            Console.WriteLine("Provide a new first name.");
            var firstName = Console.ReadLine();
            teacher.FirstName = firstName;

            // TODO: read last name DONE
            Console.WriteLine($"This is the last name: {teacher.LastName}");
            // TODO: update last name of teacher DONE
            Console.WriteLine("Provide a new last name.");
            var lastName = Console.ReadLine();
            teacher.LastName = lastName;
        }
    }
}
