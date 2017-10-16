using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesInPraxis
{
    internal delegate bool MyDelegate(Employee e);
    // Action       -> void
    // Prediacte    -> bool
    // Func

    class Program
    {
        static void Main(string[] args)
        {
            var employees = GetData();

            //MyDelegate del = new MyDelegate(Bedingung);
            //Func<Employee, bool> del = new Func<Employee, bool>(Bedingung);
            //var del = new Func<Employee, bool>(Bedingung);
            //Func<Employee, bool> del = Bedingung;
            //var query = Abfrage(employees, del);

            //var query = Abfrage(employees, Bedingung);

            //var query = Abfrage(employees, delegate (Employee e)
            //{
            //    return e.Name.StartsWith("A");
            //});

            //var query = Abfrage(employees, (Employee e) =>
            //{
            //    return e.Name.StartsWith("A");
            //});

            //var query = Abfrage(employees, (e) =>
            //{
            //    return e.Name.StartsWith("A");
            //});

            //var query = Abfrage(employees, (e) => e.Name.StartsWith("A"));
            //var query = Abfrage(employees, e => e.Name.StartsWith("A"));
            var query = employees.Abfrage(e => e.Name.StartsWith("A"));
            var linqquery = employees.Where(e => e.Name.StartsWith("A"));
            var linqquery2 = employees.Where(Bedingung);

            foreach (var e in query)
                Console.WriteLine($"Id: {e.Id,-2} | {e.Name,10} | {e.Experience}");

            employees
                .Where(e => e.Experience > 6)
                .Select(e =>
                {
                    Console.WriteLine($"Id: {e.Id,-2} | {e.Name,10} | {e.Experience}");
                    return e;
                });

            Console.ReadLine();
        }

        private static bool Bedingung(Employee e)
        {
            return e.Name.StartsWith("A");
        }


        private static IEnumerable<Employee> GetData() => new[]
        {
            new Employee { Id = 1, Name = "Stanislaus", Experience = 7 },
            new Employee { Id = 2, Name = "Lisa", Experience = 4 },
            new Employee { Id = 3, Name = "Markus", Experience = 6 },
            new Employee { Id = 4, Name = "Maria", Experience = 2 },
            new Employee { Id = 5, Name = "Luis", Experience = 8 },
            new Employee { Id = 6, Name = "Andreas", Experience = 1 },
        };
    }

    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action.Invoke(item);
        }

        public static IEnumerable<T> Abfrage<T>(
            this IEnumerable<T> source,
            Func<T, bool> predicate)
        {
            foreach (var i in source)
                if (predicate(i))
                    yield return i;
        }
    }
}
