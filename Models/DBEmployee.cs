using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace MVC_Demo.Models
{
    public class DBEmployee
    {
        string constr = ConfigurationManager.ConnectionStrings["InventoryString"].ConnectionString;

        public List<Employee> GetEmployee()
        {
            List<Employee> Employeelist = new List<Employee>();
            SqlConnection conn = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("spGetEmployee" , conn);
            cmd.CommandType = CommandType.StoredProcedure;
           conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Employee employee = new Employee();

                employee.EmployeeID = Convert.ToInt32(reader.GetValue(0).ToString());
                employee.FirstName = reader.GetValue(1).ToString();
                employee.LastName = reader.GetValue(2).ToString();
                employee.Contact = reader.GetValue(3).ToString();
                employee.DateOfBirth = Convert.ToDateTime(reader.GetValue(4).ToString());
                employee.DepartmentName = reader.GetValue(5).ToString();

                Employeelist.Add(employee);
            }
            conn.Close();


            return Employeelist;
        }
        public bool AddEmployee(Employee employee)
        {
              SqlConnection conn = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("spADDEmployee" , conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", employee.LastName);
            cmd.Parameters.AddWithValue("@Contact", employee.Contact);
            cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
            cmd.Parameters.AddWithValue("@DepartmentName", employee.DepartmentName);
            conn.Open();

            int i = cmd.ExecuteNonQuery();
            if (i > 0) return true;
            else return false;
        }
        public bool UpdateEmployee(Employee employee)
        {
            SqlConnection conn = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("spUpdateEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
            cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", employee.LastName);
            cmd.Parameters.AddWithValue("@Contact", employee.Contact);
            cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
            cmd.Parameters.AddWithValue("@DepartmentName", employee.DepartmentName);
            conn.Open();

            int i = cmd.ExecuteNonQuery();
            if (i > 0) return true;
            else return false;
        }
    }
}