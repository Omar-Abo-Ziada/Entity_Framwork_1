using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Program
    {
        class CrsData
        {
            public int Hours { get; set; }
            public string Name { get; set; }
        }

        static CrsData GetName(Course crs)
        {
            return new CrsData { Name = crs.Name, Hours = crs.Hours};
        }

        static void Main(string[] args)
        {
            #region LINQ in Action
            //IEnumerable<Course> courses =
            //    SampleData.Courses.Filter(c => c.Hours > 30);

            //foreach (Course crs in courses)
            //{
            //    Console.WriteLine($"Name: {crs.Name} \t Hours: {crs.Hours}");
            //}

            //IEnumerable<string> names = SampleData.Courses.Choose(GetName);
            //IEnumerable<CrsData> names = SampleData.Courses.Choose(GetName);

            //var courses = SampleData.Courses.Choose(c => new { Name = c.Name, Hours = c.Hours });

            //IEnumerable<Course> courses =
            //    SampleData.Courses.Where(c => c.Hours > 30);

            //var courses = SampleData.Courses.Select(c => new { Name = c.Name, Hours = c.Hours }); 
            #endregion

            #region Pipeline
            //IEnumerable<Course> courses =
            //    SampleData.Courses.Filter(c => c.Hours > 30);
            //IEnumerable<string> names = courses.Choose(c => c.Name);

            //IEnumerable<string> names =
            //    SampleData.Courses.Filter(c => c.Hours > 30)
            //    .Choose(c => c.Name);

            //foreach (string c in names)
            //{
            //    Console.WriteLine(c);
            //} 
            #endregion

            #region Query Expression
            //IEnumerable<string> names =
            //    from crs in SampleData.Courses
            //    where crs.Hours > 30
            //    select crs.Name; 
            #endregion

            #region Take / Skip
            //var query =
            //    SampleData.Courses.Where(crs => crs.Hours >= 20).Skip(3);//.Take(3);
            //    SampleData.Courses.SkipWhile(c => c.Hours <= 20); //.TakeWhile(c => c.Hours > 20); 
            #endregion

            #region Firs/Last OrDefault
            //Course crs = SampleData.Courses.Last();//.First();
            //Course crs =
            //    SampleData.Courses.Where(c => c.Hours > 30).LastOrDefault(); //.FirstOrDefault();

            //Course c =
            //    (from cs in SampleData.Courses
            //     where cs.Hours > 30
            //     select cs).FirstOrDefault(); 
            #endregion

            #region Eager Execution
            //var query =
            //    SampleData.Courses.Where(c => c.Hours > 30)
            //    .Select(c => new { c.Name, c.Hours }).ToList();

            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //} 
            #endregion

            #region OrderBy
            //var query =
            //    SampleData.Courses
            //    .Where(c => c.Hours > 30)
            //    .OrderBy(c => c.Name)
            //    .Select(c => new { c.Name, c.Hours});

            //var query =
            //    from c in SampleData.Courses
            //    where c.Hours > 30
            //    orderby c.Name descending
            //    select new { c.Name, c.Hours };

            //var query =
            //    from c in SampleData.Courses
            //    where c.Hours > 30
            //    orderby c.Hours, c.Name
            //    select new { c.Name, c.Hours };

            //var query =
            //    SampleData.Courses
            //    .Where(c => c.Hours > 30)
            //    .OrderBy(c => c.Hours)
            //    .ThenBy(c => c.Name)
            //    .Select(c => new { c.Name, c.Hours });

            //foreach (var c in query)
            //{
            //    Console.WriteLine(c);
            //} 
            #endregion

            #region Aggregate Functions
            //int count = SampleData.Courses.Count();
            //int count = SampleData.Courses.Where(c=>c.Hours > 30).Count();
            //int count = SampleData.Courses.Count(c => c.Hours > 30);

            //int totalHours = SampleData.Courses.Sum(c => c.Hours);

            //int maxHours = SampleData.Courses.Max(c => c.Hours);
            //var course = SampleData.Courses.Max(); // will throw exception, must implement IComparable

            //var crs = 
            //    SampleData.Courses.Where(c => c.Hours == maxHours); 
            #endregion

            #region SubQuery
            //var query =
            //    from s in SampleData.Subjects
            //    select new
            //    {
            //        SubName = s.Name,
            //        Courses =
            //            from c in SampleData.Courses
            //            where s.Name == c.Subject.Name
            //            select c
            //    };

            //foreach (var item in query)
            //{
            //    Console.WriteLine($"Subject: {item.SubName} \t TotalHours: {item.Courses.Sum(c => c.Hours)}");

            //    foreach (var crs in item.Courses)
            //    {
            //        Console.WriteLine($"Name: {crs.Name} \t Hours: {crs.Hours}");
            //    }

            //    Console.WriteLine("===================");
            //} 
            #endregion

            #region Group By
            //IEnumerable<IGrouping<string, Course>> query =
            //    //SampleData.Courses.GroupBy(c => c.Subject.Name);
            //    from c in SampleData.Courses
            //    group c by c.Subject.Name;

            //foreach (var item in query)
            //{
            //    Console.WriteLine($"Subject: {item.Key} \t TotalHours: {item.Sum(c => c.Hours)}");

            //    foreach (var crs in item)
            //    {
            //        Console.WriteLine($"Name: {crs.Name} \t Hours: {crs.Hours}");
            //    }

            //    Console.WriteLine("===================");
            //}

            //var query =
            //   from c in SampleData.Courses
            //   group c by c.Subject.Name into grp
            //   where grp.Count() > 2
            //   select grp;
            //select new { SubName = grp.Key, TotalHours = grp.Sum(c => c.Hours) };


            //foreach (var item in query)
            //{
            //    Console.WriteLine($"Subject: {item.Key} \t TotalHours: {item.Sum(c => c.Hours)}");

            //    foreach (var crs in item)
            //    {
            //        Console.WriteLine($"Name: {crs.Name} \t Hours: {crs.Hours}");
            //    }

            //    Console.WriteLine("===================");
            //} 
            #endregion

            #region Dealing with Non-Generic IEnumerable
            //var query =
            //    from Course c in SampleData.GetCourses()
            //    select c;

            //var query =
            //    from c in SampleData.GetCourses().Cast<Course>()
            //    select c;

            //var query =
            //    from c in SampleData.GetCourses().OfType<Course>()
            //    select c;

            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //} 
            #endregion
        }
    }
}
