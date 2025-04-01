using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
public class Configurator
{
    private DBManipulator manipulator;
    public Configurator() { this.manipulator = new DBManipulator(); }



    public void SaveSpecialty(int id, string name)
    {
        SqlConnection connection = this.manipulator.GetConnection();
        try
        {
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "INSERT INTO Specialty (SpecialtyId, Name) VALUES (@SpecialtyId, @Name)";
            SqlParameter param = null;
            param = new SqlParameter("@SpecialtyId", SqlDbType.Int); param.Value = id; command.Parameters.Add(param);
            param = new SqlParameter("@Name", SqlDbType.VarChar); param.Value = name; command.Parameters.Add(param);
            command.ExecuteNonQuery();
        }
        catch (Exception e) { MessageBox.Show(e.ToString()); }
        finally { connection.Close(); }
    }

    public void SaveSubject(int id, string name)
    {
        SqlConnection connection = this.manipulator.GetConnection();
        try
        {
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "INSERT INTO Subject (SubjectId, Name) VALUES (@SubjectId, @Name)";
            SqlParameter param = null;
            param = new SqlParameter("@SubjectId", SqlDbType.Int); param.Value = id; command.Parameters.Add(param);
            param = new SqlParameter("@Name", SqlDbType.VarChar); param.Value = name; command.Parameters.Add(param);
            command.ExecuteNonQuery();
        }
        catch (Exception e) { MessageBox.Show(e.ToString()); }
        finally { connection.Close(); }
    }

    public void SaveStudent(int fNumber, int specialtyId, string fName, string mName, string lName, string address, string phone, string eMail)
    {
        SqlConnection connection = this.manipulator.GetConnection();
        try
        {
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "INSERT INTO Student (FNumber, SpecialtyId, FName, MName, LName, Address, Phone, EMail) VALUES (@FNumber, @SpecialtyId, @FName, @MName, @LName, @Address, @Phone, @EMail)";
            SqlParameter param = null;
            param = new SqlParameter("@FNumber", SqlDbType.Int); param.Value = fNumber; command.Parameters.Add(param);
            param = new SqlParameter("@SpecialtyId", SqlDbType.Int); param.Value = specialtyId; command.Parameters.Add(param);
            param = new SqlParameter("@FName", SqlDbType.VarChar); param.Value = fName; command.Parameters.Add(param);
            param = new SqlParameter("@MName", SqlDbType.VarChar); param.Value = mName; command.Parameters.Add(param);
            param = new SqlParameter("@LName", SqlDbType.VarChar); param.Value = lName; command.Parameters.Add(param);
            param = new SqlParameter("@Address", SqlDbType.VarChar); param.Value = address; command.Parameters.Add(param);
            param = new SqlParameter("@Phone", SqlDbType.VarChar); param.Value = phone; command.Parameters.Add(param);
            param = new SqlParameter("@EMail", SqlDbType.VarChar); param.Value = eMail; command.Parameters.Add(param);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
        }
        finally { connection.Close(); }
    }
    public DataTable LoadSpecialties()
    {
        DataTable result = new DataTable();
        result.Columns.Add("id"); result.Columns.Add("name");
        SqlConnection connection = this.manipulator.GetConnection();
        try
        {
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "SELECT SpecialtyId, Name FROM Specialty ORDER BY Name ASC";
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["SpecialtyId"]); string name = Convert.ToString(reader["Name"]);
                    DataRow row = result.NewRow();
                    row[0] = id; row[1] = name;
                    result.Rows.Add(row);
                }
            }
        }
        catch (Exception e) { MessageBox.Show(e.ToString()); }
        finally { connection.Close(); }
        return result;
    }

    public void SaveGrade(int fNumber, int subjectId, int finalGrade)
    {
        SqlConnection connection = this.manipulator.GetConnection();
        try
        {
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "INSERT INTO StudentSubject (FNumber, SubjectId, FinalGrade) VALUES (@FNumber, @SubjectId, @FinalGrade)";
            SqlParameter param = null;
            param = new SqlParameter("@FNumber", SqlDbType.Int); param.Value = fNumber; command.Parameters.Add(param);
            param = new SqlParameter("@SubjectId", SqlDbType.Int); param.Value = subjectId; command.Parameters.Add(param);
            param = new SqlParameter("@FinalGrade", SqlDbType.Int); param.Value = finalGrade; command.Parameters.Add(param);
            command.ExecuteNonQuery();
        }
        catch (Exception e) { MessageBox.Show(e.ToString()); }
        finally { connection.Close(); }
    }
    // I had to make additional changes to the LoadStudents in order to work properly since it was giving errors when copying the code from the document. I added more columns. 
    public DataTable LoadStudents()
    {
        DataTable result = new DataTable();
        result.Columns.Add("fnumber");
        result.Columns.Add("specialtyId");
        result.Columns.Add("fname");
        result.Columns.Add("mname");
        result.Columns.Add("lname");
        result.Columns.Add("address");
        result.Columns.Add("phone");
        result.Columns.Add("email");

        SqlConnection connection = this.manipulator.GetConnection();
        try
        {
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "SELECT * FROM Student ORDER BY FNumber ASC";
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    int fNumber = Convert.ToInt32(reader["FNumber"]);
                    int SpecialtyId = Convert.ToInt32(reader["SpecialtyId"]);
                    string fName = Convert.ToString(reader["FName"]);
                    string mName = Convert.ToString(reader["MName"]);
                    string lName = Convert.ToString(reader["LName"]);
                    string address = Convert.ToString(reader["Address"]);
                    string phone = Convert.ToString(reader["Phone"]);
                    string email = Convert.ToString(reader["EMail"]);

                    DataRow row = result.NewRow();
                    row[0] = fNumber;
                    row[1] = SpecialtyId;
                    row[2] = fName;
                    row[3] = mName;
                    row[4] = lName;
                    row[5] = address;
                    row[6] = phone;
                    row[7] = email;

                    result.Rows.Add(row);
                }
            }
        }
        catch (Exception e) { MessageBox.Show(e.ToString()); }
        finally { connection.Close(); }
        return result;
    }
    public DataTable LoadSubjects()
    {
        DataTable result = new DataTable();
        result.Columns.Add("id"); result.Columns.Add("name");
        SqlConnection connection = this.manipulator.GetConnection();
        try
        {
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "SELECT SubjectId, Name FROM Subject ORDER BY Name ASC";
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["SubjectId"]); string name = Convert.ToString(reader["Name"]);
                    DataRow row = result.NewRow();
                    row[0] = id; row[1] = name;
                    result.Rows.Add(row);
                }
            }
        }
        catch (Exception e) { MessageBox.Show(e.ToString()); }
        finally { connection.Close(); }
        return result;
    }

    public DataTable LoadGrades()
    {
        DataTable result = new DataTable();
        result.Columns.Add("fNumber"); 
        result.Columns.Add("subjectId");
        result.Columns.Add("finalGrade");
        SqlConnection connection = this.manipulator.GetConnection();
        try
        {
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
        }
        catch (Exception e) { MessageBox.Show(e.ToString()); }
        finally { connection.Close(); }
        return result;
    }

    public void UpdateSpecialty(int originalId, int id, string name)
    {
        SqlConnection connection = this.manipulator.GetConnection();
        try
        {
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "UPDATE Specialty SET SpecialtyId = @SpecialtyId, Name = @Name WHERE SpecialtyId = @OriginalId";
            SqlParameter param = null;
            param = new SqlParameter("@SpecialtyId", SqlDbType.Int);
            param.Value = id;
            command.Parameters.Add(param);
            param = new SqlParameter("@Name", SqlDbType.VarChar);
            param.Value = name;
            command.Parameters.Add(param);
            param = new SqlParameter("@OriginalId", SqlDbType.Int);
            param.Value = originalId;
            command.Parameters.Add(param);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
        }
        finally
        {
            connection.Close();
        }
    }

    public void UpdateSubject(int originalId, int id, string name)
    {
        SqlConnection connection = this.manipulator.GetConnection();
        try
        {
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "UPDATE Subject SET SubjectId = @SubjectId, Name = @Name WHERE SubjectId = @OriginalId";
            SqlParameter param = null;
            param = new SqlParameter("@SubjectId", SqlDbType.Int);
            param.Value = id;
            command.Parameters.Add(param);
            param = new SqlParameter("@Name", SqlDbType.VarChar);
            param.Value = name;
            command.Parameters.Add(param);
            param = new SqlParameter("@OriginalId", SqlDbType.Int);
            param.Value = originalId;
            command.Parameters.Add(param);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
        }
        finally
        {
            connection.Close();
        }
    }

    public void UpdateGrade(int fNumber, int subjectId, int finalGrade)
    {
        SqlConnection connection = this.manipulator.GetConnection();
        try
        {
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "UPDATE StudentSubject SET FinalGrade = @FinalGrade WHERE FNumber = @FNumber AND SubjectId = @SubjectId";
            SqlParameter param = null;

            param = new SqlParameter("@FinalGrade", SqlDbType.Int);
            param.Value = finalGrade;
            command.Parameters.Add(param);

            param = new SqlParameter("@FNumber", SqlDbType.Int);
            param.Value = fNumber;
            command.Parameters.Add(param);

            param = new SqlParameter("@SubjectId", SqlDbType.Int);
            param.Value = subjectId;
            command.Parameters.Add(param);

            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
        }
        finally
        {
            connection.Close();
        }
    }

    public void UpdateStudent(int originalFNumber, int fNumber, int specialtyId, string fName, string mName, string lName, string address, string phone, string eMail)
    {
        SqlConnection connection = this.manipulator.GetConnection();
        try
        {
            connection.Open();
            SqlCommand command = this.manipulator.GetCommand();
            command.CommandText = "UPDATE Student SET FNumber = @FNumber, SpecialtyId = @SpecialtyId, FName = @FName, MName = @MName, LName = @LName, Address = @Address, Phone = @Phone, EMail = @EMail WHERE FNumber = @OriginalFNumber";
            SqlParameter param = null;
            param = new SqlParameter("@FNumber", SqlDbType.Int);
            param.Value = fNumber;
            command.Parameters.Add(param);
            param = new SqlParameter("@SpecialtyId", SqlDbType.Int);
            param.Value = specialtyId;
            command.Parameters.Add(param);
            param = new SqlParameter("@FName", SqlDbType.VarChar);
            param.Value = fName;
            command.Parameters.Add(param);
            param = new SqlParameter("@MName", SqlDbType.VarChar);
            param.Value = mName;
            command.Parameters.Add(param);
            param = new SqlParameter("@LName", SqlDbType.VarChar);
            param.Value = lName;
            command.Parameters.Add(param);
            param = new SqlParameter("@Address", SqlDbType.VarChar);
            param.Value = address;
            command.Parameters.Add(param);
            param = new SqlParameter("@Phone", SqlDbType.VarChar);
            param.Value = phone;
            command.Parameters.Add(param);
            param = new SqlParameter("@EMail", SqlDbType.VarChar);
            param.Value = eMail;
            command.Parameters.Add(param);
            param = new SqlParameter("@OriginalFNumber", SqlDbType.Int);
            param.Value = originalFNumber;
            command.Parameters.Add(param);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
        }
        finally
        {
            connection.Close();
        }
    }
}

