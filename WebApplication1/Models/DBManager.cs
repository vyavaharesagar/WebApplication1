using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace WebApplication1.Models
{
    public class DBManager
    {
        public static UserDTO Validate(String Login,String Password)
        {
            String connString = @"Server=localhost:3306;Database=PMS;User Id=root;Password=;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    String sqlQuery = String.Format("Select UserID, Login, IsAdmin from dbo.Users where Login = '{0}' and Password = '{1}'", Login, Password);
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.Read() == true)
                    {
                        UserDTO dto = new UserDTO();
                        dto.UserID = reader.GetInt32(0);
                        dto.Login = reader.GetString(1);
                        dto.IsAdmin = reader.GetBoolean(2);
                        return dto;
                    }
                    return null;
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
                //if (Login == "admin" && Password == "admin")
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
        }

        public static List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student() { ID = "1", Name = "Bilal 1" });
            students.Add(new Student() { ID = "2", Name = "Bilal 2" });
            students.Add(new Student() { ID = "3", Name = "Bilal 3" });
            students.Add(new Student() { ID = "4", Name = "Bilal 4" });
            students.Add(new Student() { ID = "5", Name = "Bilal 5" });

            return students;
        }

        public static List<ProductDTO> GetProducts()
        {
            String connString = @"Server=localhost:3306;Database=PMS;User Id=root;Password=;";
            
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    String sqlQuery = String.Format("Select * from dbo.Products");
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    List<ProductDTO> list = new List<ProductDTO>();
                    while (reader.Read() == true)
                    {
                        ProductDTO dto = new ProductDTO();
                        dto.ProductID = reader.GetInt32(0);
                        dto.Name = reader.GetString(1);
                        dto.Price = reader.GetDouble(2);
                        dto.CreatedOn = reader.GetDateTime(3);
                        dto.CreatedBy = reader.GetInt32(4);
                        list.Add(dto);
                    }
                    return list;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
          
        }

    }
}