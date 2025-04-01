using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace ProjectAAS
{
    public class Configurator
    {
        private DBManipulator manipulator;

        public Configurator()
        {
            this.manipulator = new DBManipulator();
        }
        public bool CheckLogin(string username, string password)
        {
            bool result = false;
            SqlConnection connection = this.manipulator.GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = this.manipulator.GetCommand();
                command.CommandText = "SELECT id FROM Login WHERE username = @username AND password = @password";
                SqlParameter param = null;

                param = new SqlParameter("@username", SqlDbType.VarChar);
                param.Value = username;
                command.Parameters.Add(param);
                param = new SqlParameter("@password", SqlDbType.VarChar);
                param.Value = password;
                command.Parameters.Add(param);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    if (reader.Read())
                    {
                        result = true;
                    }
                }
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public DataTable LoadSpecialties()
        {
            DataTable result = new DataTable();
            result.Columns.Add("id");
            result.Columns.Add("name");
            SqlConnection connection = this.manipulator.GetConnection();
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "SELECT SpecialtyId, Name FROM Specialty ORDER BY Name ASC";
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["SpecialtyId"]);
                    string name = Convert.ToString(reader["Name"]);
                    DataRow row = result.NewRow();
                    row[0] = id;
                    row[1] = name;
                    result.Rows.Add(row);
                }
            }
            connection.Close();
            return result;
        }
        public Specialty LoadSpecialtyById(int id)
        {
            Specialty result = null;
            SqlConnection connection = this.manipulator.GetConnection();
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "SELECT * FROM Specialty WHERE SpecialtyId = @SpecialtyId";
            SqlParameter param = null;
            param = new SqlParameter("@SpecialtyId", SqlDbType.Int);
            param.Value = id;
            command.Parameters.Add(param);
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                if (reader.Read())
                {
                    result = new Specialty();
                    string name = Convert.ToString(reader["Name"]);
                    result.Id = id;
                    result.Name = name;
                }
            }
            connection.Close();
            return result;
        }
        public void UpdateSpecialty(int id, string name)
        {
            SqlConnection connection = this.manipulator.GetConnection();
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "UPDATE Specialty SET Name = @Name WHERE SpecialtyId = @SpecialtyId";
            SqlParameter param = null;
            param = new SqlParameter("@SpecialtyId", SqlDbType.Int);
            param.Value = id;
            command.Parameters.Add(param);
            param = new SqlParameter("@Name", SqlDbType.VarChar);
            param.Value = name;
            command.Parameters.Add(param);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable LoadSubjects()
        {
            DataTable result = new DataTable();
            result.Columns.Add("id");
            result.Columns.Add("name");
            SqlConnection connection = this.manipulator.GetConnection();
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "SELECT SubjectId, Name FROM Subject ORDER BY Name ASC";
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["SubjectId"]);
                    string name = Convert.ToString(reader["Name"]);
                    DataRow row = result.NewRow();
                    row[0] = id;
                    row[1] = name;
                    result.Rows.Add(row);
                }
            }
            connection.Close();
            return result;
        }
        public Subject LoadSubjectById(int id)
        {
            Subject result = null;
            SqlConnection connection = this.manipulator.GetConnection();
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "SELECT * FROM Subject WHERE SubjectId = @SubjectId";
            SqlParameter param = null;
            param = new SqlParameter("@SubjectId", SqlDbType.Int);
            param.Value = id;
            command.Parameters.Add(param);
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                if (reader.Read())
                {
                    result = new Subject();
                    string name = Convert.ToString(reader["Name"]);
                    result.Id = id;
                    result.Name = name;
                }
            }
            connection.Close();
            return result;
        }
        public void UpdateSubject(int id, string name)
        {
            SqlConnection connection = this.manipulator.GetConnection();
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "UPDATE Subject SET Name = @Name WHERE SubjectId = @SubjectId";
            SqlParameter param = null;
            param = new SqlParameter("@SubjectId", SqlDbType.Int);
            param.Value = id;
            command.Parameters.Add(param);
            param = new SqlParameter("@Name", SqlDbType.VarChar);
            param.Value = name;
            command.Parameters.Add(param);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable LoadStudents()
        {
            DataTable result = new DataTable();
            result.Columns.Add("fnumber");
            result.Columns.Add("SpecialtyId");
            result.Columns.Add("fname");
            result.Columns.Add("mname");
            result.Columns.Add("lname");
            result.Columns.Add("address");
            result.Columns.Add("phone");
            result.Columns.Add("email");
                

            SqlConnection connection = this.manipulator.GetConnection();
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "SELECT * FROM Student ORDER BY FNumber ASC";
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    int fNumber = Convert.ToInt32(reader["FNumber"]);
                    int specialtyId = Convert.ToInt32(reader["SpecialtyId"]);
                    string fName = Convert.ToString(reader["FName"]);
                    string mName = Convert.ToString(reader["MName"]);
                    string lName = Convert.ToString(reader["LName"]);
                    string address = Convert.ToString(reader["Address"]);
                    string phone = Convert.ToString(reader["Phone"]);
                    string email = Convert.ToString(reader["EMail"]);

                    DataRow row = result.NewRow();
                    row[0] = fNumber;
                    row[1] = specialtyId;
                    row[2] = fName;
                    row[3] = mName;
                    row[4] = lName;
                    row[5] = address;
                    row[6] = phone;
                    row[7] = email;

                    result.Rows.Add(row);
                }
            }
            connection.Close();
            return result;
        }
        public Student LoadStudentByFacultyNumber(int facultyNumber)
        {
            Student result = null;
            SqlConnection connection = this.manipulator.GetConnection();
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "SELECT * FROM Student WHERE FNumber = @FNumber";
            SqlParameter param = null;
            param = new SqlParameter("@FNumber", SqlDbType.Int);
            param.Value = facultyNumber;
            command.Parameters.Add(param);
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                if (reader.Read())
                {
                    result = new Student();

                    int fNumber = Convert.ToInt32(reader["FNumber"]);
                    int specialtyId = Convert.ToInt32(reader["SpecialtyId"]);
                    string fName = Convert.ToString(reader["FName"]);
                    string mName = Convert.ToString(reader["MName"]);
                    string lName = Convert.ToString(reader["LName"]);
                    string address = Convert.ToString(reader["Address"]);
                    string phone = Convert.ToString(reader["Phone"]);
                    string email = Convert.ToString(reader["EMail"]);

                    result.FNumber = fNumber;
                    result.SpecialtyId = specialtyId;
                    result.FName = fName;
                    result.MName = mName;
                    result.LName = lName;
                    result.Address = address;
                    result.Phone = phone;
                    result.Email = email;
                    result.Address = address;
                    result.Phone = phone;
                    result.Email = email;
                }
            }
            connection.Close();
            return result;
        }
        public void UpdateStudent(int fNumber, int specialtyId, string fName, string mName, string lName, string address, string phone, string email)
        {
            SqlConnection connection = this.manipulator.GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = this.manipulator.GetCommand();
                command.CommandText = @"UPDATE Student 
                                SET SpecialtyId = @SpecialtyId, 
                                    FName = @FName, 
                                    MName = @MName, 
                                    LName = @LName, 
                                    Address = @Address, 
                                    Phone = @Phone, 
                                    EMail = @Email 
                                WHERE FNumber = @FNumber";

                command.Parameters.AddWithValue("@FNumber", fNumber);
                command.Parameters.AddWithValue("@SpecialtyId", specialtyId);
                command.Parameters.AddWithValue("@FName", fName);
                command.Parameters.AddWithValue("@MName", mName ?? (object)DBNull.Value);  // Allow NULL values
                command.Parameters.AddWithValue("@LName", lName);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Email", email);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating student: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable LoadGrades()
        {
            DataTable result = new DataTable();
            result.Columns.Add("fnumber");
            result.Columns.Add("subjectId");
            result.Columns.Add("finalGrade");


            SqlConnection connection = this.manipulator.GetConnection();
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "SELECT * FROM StudentSubject ORDER BY FinalGrade DESC";
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    int fNumber = Convert.ToInt32(reader["FNumber"]);
                    int subjectId = Convert.ToInt32(reader["SubjectId"]);
                    int finalGrade = Convert.ToInt32(reader["FinalGrade"]);

                    DataRow row = result.NewRow();
                    row[0] = fNumber;
                    row[1] = subjectId;
                    row[2] = finalGrade;

                    result.Rows.Add(row);
                }
            }
            connection.Close();
            return result;
        }

        public Grade LoadGradesByFacultyNumber(int fNumber)
        {
            Grade result = null;
            SqlConnection connection = this.manipulator.GetConnection();
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "SELECT * FROM StudentSubject WHERE FNumber = @FNumber";
            SqlParameter param = null;
            param = new SqlParameter("@FNumber", SqlDbType.Int);
            param.Value = fNumber;
            command.Parameters.Add(param);
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                if (reader.Read())
                {
                    result = new Grade();

                    int subjectId = Convert.ToInt32(reader["SubjectId"]);
                    int finalGrade = Convert.ToInt32(reader["FinalGrade"]);

                    result.FNumber = fNumber;
                    result.SubjectId = subjectId;
                    result.FinalGrade = finalGrade;
                }
            }
            connection.Close();
            return result;
        }
        public void UpdateGrade(int fNumber, int finalGrade)
        {
            SqlConnection connection = this.manipulator.GetConnection();
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "UPDATE StudentSubject SET FinalGrade = @FinalGrade WHERE FNumber = @FNumber";
            SqlParameter param = null;
            param = new SqlParameter("@FNumber", SqlDbType.Int);
            param.Value = fNumber;
            command.Parameters.Add(param);

            param = new SqlParameter("@FinalGrade", SqlDbType.Int);
            param.Value = finalGrade;

            command.Parameters.Add(param);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}

    


