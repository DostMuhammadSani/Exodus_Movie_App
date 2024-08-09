using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ClassLibraryModel;


namespace ClassLibrarydal
{
    public class DALClass
    {
        public static void SaveInformation(ModelUser ms)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SaveUserss", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", ms.Name);
            cmd.Parameters.AddWithValue("@EmailAddress", ms.EmailAddress);
            cmd.Parameters.AddWithValue("@pass", ms.pass);
            cmd.ExecuteNonQuery();
            con.Close();
        }
     
        public static List<ModelUser> GetInformation()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("GetUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<ModelUser> ListUser = new List<ModelUser>();
            while (reader.Read())
            {
                ModelUser student = new ModelUser();
                student.Id = Convert.ToInt32(reader["Id"]);
                student.Name = reader["Name"].ToString();
                student.EmailAddress = reader["EmailAddress"].ToString();
                student.pass = reader["pass"].ToString();
                ListUser.Add(student);
            }
            con.Close();
            return ListUser;
        }

        public static void SaveInformation2(ModelReview ms)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("savereview", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", ms.UserName);
            cmd.Parameters.AddWithValue("@Review", ms.Review);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static List<ModelReview> GetInformation2()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("getreview", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<ModelReview> ListReview = new List<ModelReview>();
            while (reader.Read())
            {
                ModelReview student = new ModelReview();

                student.UserName = reader["UserName"].ToString();
                student.Review = reader["Review"].ToString();

                ListReview.Add(student);
            }
            con.Close();
            return ListReview;
        }
    }

}