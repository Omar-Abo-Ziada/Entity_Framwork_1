using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Deployment.Internal;

namespace Task2
{
    internal static class DataAccessLayer
    {
        public static Company_SDEntities context { get; set; } = new Company_SDEntities();

        //=======================================

        //Company_SDEntities context = new Company_SDEntities();

        //var query = context.Departments.Where(q => q.Employees.Count() > 1).Select(q => new {q.Dnum , q.Dname} );
        //context.Database.Log = log => Debug.WriteLine(log);

        //foreach (var department in query) 
        //{
        //    Console.WriteLine(department);
        //}

        //var query = context.Departments.Where(q => q.Dnum>1).Select(q => new { q.Dnum, q.Dname });
        //context.Database.Log = log => Debug.WriteLine(log);

        //foreach (var department in query)
        //{
        //    Console.WriteLine(department);
        //}

        //var query = 
        //    from dep in context.Departments
        //    where dep.Dnum > 1 && dep.Dname.StartsWith("S")
        //    select dep;

        //foreach (var department in query)
        //{
        //    Console.WriteLine(department.Dname);
        //}
        //Console.ReadLine();

        //int id = int.Parse("1");

        //var query = 
        //    from dep in context.Departments
        //    where dep.Dnum > id && dep.Dname.Contains("s")
        //    select dep;

        //foreach (var department in query)
        //{
        //    Console.WriteLine(department.Dname);
        //}
        //Console.ReadLine();


        //Department dep = context.Departments.First();
        //dep.Dname = "Human Resources";

        //context.SaveChanges();

        //Console.WriteLine(dep.Dname);

        //========================================
        //private static SqlConnection sqlConnection;
        //private static SqlCommand sqlCommand;
        //private static SqlDataAdapter sqlAdapter;

        //static DataAccessLayer()
        //{
        //    sqlConnection = new SqlConnection("Data Source=DESKTOP-2U2SE1A;Initial Catalog=Company_SD;Integrated Security=True;");
        //    sqlCommand = new SqlCommand();
        //    sqlAdapter = new SqlDataAdapter(sqlCommand);
        //    sqlCommand.Connection = sqlConnection;
        //}

        internal static List<Department> GetDepartments()
        {
            IQueryable<Department> query = context.Departments.Select(d => d);

            List<Department> departments = new List<Department>();

            foreach (Department dep in query)
            {
                departments.Add(dep);
            }

            return departments;
        }

        internal static Department GetDepartment(int _dno)
        {
            IQueryable<Department> dep = context.Departments.Where(d => d.Dnum == _dno);

            return dep.FirstOrDefault();
        }

        internal static List<Employee> GetDepartmentEmployees(int _dno)
        {
            IQueryable<Employee> Emps = context.Employees.Where(e => e.Dno == _dno);

            List<Employee> employees = new List<Employee>();

            foreach (Employee emp in Emps)
            {
                employees.Add(emp);
            }

            return employees;
        }


        internal static Employee GetEmployee(int _SSN)
        {
            IQueryable<Employee> query = context.Employees.Where(e => e.SSN == _SSN);

            return query.FirstOrDefault();
        }

        internal static void AddEmployee(Employee emp)
        {
            Employee employee = new Employee();

            employee.Fname = emp.Fname;
            employee.Lname = emp.Lname;
            employee.Address = emp.Address;
            employee.Salary = emp.Salary;
            employee.SSN = emp.SSN;
            employee.Bdate = emp.Bdate;
            employee.Dno = emp.Dno;
            employee.Department = emp.Department;
            employee.Sex = emp.Sex;
            employee.Superssn = emp.Superssn;

            context.Employees.Add(employee);

            context.SaveChanges();
        }

        internal static void DeleteEmployee(int _SSN)
        {
            Employee emp = GetEmployee(_SSN);

            context.Employees.Remove(emp);

            context.SaveChanges();

        }

        internal static void UpdateEmployee(int _SSN, Employee updatedEmp , int targetDepNum)
        {
            Employee employee = GetEmployee(_SSN);
            Department targetDep = GetDepartment(targetDepNum);

            employee.Fname = updatedEmp.Fname;
            employee.Lname = updatedEmp.Lname;
            employee.Address = updatedEmp.Address;
            employee.Salary = updatedEmp.Salary;
            employee.SSN = updatedEmp.SSN;
            employee.Bdate = updatedEmp.Bdate;
            employee.Department = targetDep;
            employee.Dno = targetDepNum;
            employee.Department = updatedEmp.Department;
            employee.Sex = updatedEmp.Sex;
            employee.Superssn = updatedEmp.Superssn;

            context.SaveChanges();
        }

        internal static bool IsRepeatedSSN(int _SSN)
        {
            List<int> SSNs = new List<int>();

            IQueryable<int> query = context.Employees.Select(x => x.SSN );

            foreach (int SSN in query)
            {
                if(SSN == _SSN)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
