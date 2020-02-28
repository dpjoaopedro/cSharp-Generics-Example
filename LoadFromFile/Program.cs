using System;

namespace LoadFromFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\dpjoa\Desktop\Persons.txt";
            var loadFromFile = new LoadObjectFromFile<Person>();

            var personList = loadFromFile.LoadToList(path);

            foreach (var person in personList)
            {
                Console.WriteLine(person.Name);
            }

            Console.ReadLine();
        }
    }
}
