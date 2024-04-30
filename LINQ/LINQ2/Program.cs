namespace LINQ2
{
    internal class Program
    {
        static MiniCourse GetData(Course c)
        {
            return new MiniCourse { Name = c.Name, Hours = c.Hours };
        }

        static void Main(string[] args)
        {
            #region LINQ in Action
            //List<int> myList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //IEnumerable<int> newList = myList.Filter(x => x > 4);

            //foreach (var item in newList)
            //{
            //    Console.WriteLine(item);
            //}

            //IEnumerable<Course> query =
            //    SampleData.Courses.Where(c => c.Hours > 30);

            //IEnumerable<MiniCourse> query =
            //    SampleData.Courses.GetMini(GetData);

            //var query =
            //    SampleData.Courses.Select(c => new { c.Name, c.Hours });


            //IEnumerable<Course> courses =
            //    SampleData.Courses.Filter(c => c.Hours > 30);

            //var query = courses.Choose(c => new { c.Name, c.Hours });

            //var query =
            //    SampleData.Courses.Where(c => c.Hours > 30)
            //    .Select(c => new { c.Name, c.Hours }); 
            #endregion

            #region Query Expressions
            //var query =
            //    from c in SampleData.Courses
            //    where c.Hours > 30
            //    select new { c.Name, c.Hours }; 
            #endregion

            #region First / Last (OrDefault)
            //Course crs = SampleData.Courses.Where(c => c.Hours > 30).FirstOrDefault(); //.First();
            //Course crs = SampleData.Courses.Where(c => c.Hours > 30).LastOrDefault(); //.Last();

            //Course crs =
            //    (from c in SampleData.Courses
            //    where c.Hours > 30
            //    select c).FirstOrDefault(); 
            #endregion

            #region Aggregate Functions
            //int totalHours =
            //    SampleData.Courses
            //    .Sum(c => c.Hours);
            //    //.Select(c=>c.Hours)
            //    //.Sum();

            //Course crs =
            //    SampleData.Courses
            //    .MaxBy(c => c.Hours); 
            #endregion

            #region Eager Execution
            //IEnumerable<Course> courses =
            //    SampleData.Courses
            //    .Where(c => c.Hours > 30)
            //    .ToList(); 
            #endregion

            #region Order By
            //var query =
            //    SampleData.Courses
            //    .Where(c => c.Hours > 30)
            //    .OrderByDescending(c => c.Name)
            //    .ThenBy(c => c.Hours)
            //    .Select(c => new { c.Name, c.Hours });
            //from c in SampleData.Courses
            //where c.Hours > 30
            //orderby c.Name descending, c.Hours ascending
            //select new { c.Name, c.Hours }; 
            #endregion

            #region Join
            //var query =
            //    from c in SampleData.Courses
            //    join s in SampleData.Subjects
            //    on c.Subject.Name equals s.Name
            //    select new { c.Name, Sub = s.Name };

            #endregion

            var query =
                //from c in SampleData.Courses
                //group c by c.Subject.Name;
                from c in SampleData.Courses
                    //group c by c.Subject.Name into grp
                group c by new { Sub = c.Subject.Name, Dept = c.Department.Name } into grp
                //where grp.Count() > 2
                select new
                {
                    SubName = grp.Key,
                    TotalHours = grp.Sum(c => c.Hours),
                    Count = grp.Count()
                };

            foreach (var grp in query)
            {
                Console.WriteLine($"Subject: {grp.Key} \t TotalHours {grp.Sum(c => c.Hours)}");
                foreach (var crs in grp)
                {
                    Console.WriteLine($"Name: {crs.Name} \t Hours:{crs.Hours}");
                }
                Console.WriteLine("===================");
            }


        }
    }
}