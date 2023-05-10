using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace LR7_CSH
{
    class StudentsSubjDBA
    {
        private const string _connectionStr = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=studentsDB;Integrated Security=True";
        public static List<SubjectStatus> ListOfChangesSubs { get; set; } = new List<SubjectStatus>();
        public static bool ClearDataBase()
        {
            bool status = true;
            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"DELETE FROM Students;
                                        DBCC CHECKIDENT('Students', RESEED, 0)
                                    DELETE FROM SubjectsHold;
                                    DELETE FROM Subjects; 
                                        DBCC CHECKIDENT('Subjects', RESEED, 0)";
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error");
                    status = false;
                }
            }
            return status;
        }
        public static bool SaveDataFromJSON()
        {
            bool status = true;
            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "dbo.uspInsertFromJSON";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@jsonData", SqlDbType.NVarChar, -1).Value = FileReader.ReadFromJSON();
                using (SqlCommand sqlCommand = new SqlCommand("Select COUNT(*) From Students", connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        var res = sqlCommand.ExecuteScalar();
                        MessageBox.Show($"{res} - records has been submitted.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"SQL Server error:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        status = false;
                    }
                }
            }
            return status;
        }
        public static bool LoadData()
        {
            if (!IsDBEmpty())
            {
                bool status = false;
                var students = new List<Student>();
                using (var connection = new SqlConnection(_connectionStr))
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM Students";
                    SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Students");
                    DataTable dataTable = dataSet.Tables["Students"];
                    var rows = dataTable.Rows;
                    var command = new SqlCommand("SELECT s.given_id, s.name, s.lastname, s.group_number, " +
                        "su.idSubjects, su.Caption, su.Grade " +
                        "FROM Students s " +
                        "INNER JOIN Subjects su ON s.given_id = su.idStudent", connection);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var studentId = reader.GetInt32(0);
                        var student = Group.Students.FirstOrDefault(s => s.GetIdForDB() == studentId);//Check list
                        if (student == null)
                        {
                            student = new Student
                            {
                                Id = studentId.ToString(),
                                Name = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Groupnumber = reader.GetDecimal(3),
                                Subjects = new List<Subject>()
                            };
                            Group.Students.Add(student);
                        }
                        var subjectId = reader.GetInt32(4);
                        var subject = new Subject
                        {
                            Caption = reader.GetString(5),
                            Grade = Convert.ToUInt32(reader.GetInt32(6))
                        };
                        student.Subjects.Add(subject);
                        status = true;
                    }
                    reader.Close();
                    connection.Close();
                }
                return status;
            }
            else
            {
                MessageBox.Show("The data base is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool SaveDataFromCurrentSession()
        {
            bool status = true;
            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                try
                {
                    connection.Open();
                    if (!InsertStudentTable(connection))
                    {
                        status = false;
                        MessageBox.Show("Students saving failed", "Error");

                    }
                    if (!InsertSubjectsTable(connection))
                    {
                        status = false;
                        MessageBox.Show("Subjects saving failed", "Error");
                    }
                    if (!InsertOnRelation(connection))
                    {
                        status = false;
                        MessageBox.Show("Relations saving failed", "Error");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error");
                }
            }
            return status;
        }
        private static bool InsertOnRelation(SqlConnection connection)
        {
            string query = @"INSERT INTO Students_has_Subjects 
                            SELECT Students.idStudents, Subjects.idSubjects
                            FROM Students
                            INNER JOIN Subjects ON Students.given_id = Subjects.idStudent;";

            using (var command = new SqlCommand(query, connection))
            {
                try
                {
                    command.ExecuteNonQuery();
                    SqlCommand checkCommand = new SqlCommand("Select COUNT(*) From Students_has_Subjects", connection);
                    var numberOfRows = checkCommand.ExecuteScalar();
                    MessageBox.Show($"Junction table consist of {numberOfRows} number of rows.", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
            return true;
        }
        private static bool InsertSubjectsTable(SqlConnection connection)
        {
            foreach (var student in Group.Students)
            {
                foreach (var subject in student.Subjects)
                {
                    using (SqlCommand sqlCommand = new SqlCommand("dbo.uspNewSubject", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@caption", SqlDbType.NVarChar, 100));
                        sqlCommand.Parameters["@caption"].Value = subject.Caption;

                        sqlCommand.Parameters.Add(new SqlParameter("@grade", SqlDbType.Int));
                        sqlCommand.Parameters["@grade"].Value = subject.Grade;

                        sqlCommand.Parameters.Add(new SqlParameter("@idStudent", SqlDbType.Int));
                        sqlCommand.Parameters["@idStudent"].Value = student.Id;

                        try
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Error");
                            return false;
                        }
                    }
                }
                using (SqlCommand checkCommand = new SqlCommand("Select COUNT(*) From Subjects", connection))
                {
                    var numberOfRows = checkCommand.ExecuteScalar();
                    MessageBox.Show($"Subjects table consist of {numberOfRows} number of rows.", "info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return true;
        }
        private static bool InsertStudentTable(SqlConnection connection)
        {
            foreach (var student in Group.Students)
            {
                using (SqlCommand sqlCommand = new SqlCommand("dbo.uspNewStudent", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@given_id", SqlDbType.Int));
                    sqlCommand.Parameters["@given_id"].Value = student.Id;
                    sqlCommand.Parameters.Add(new SqlParameter("@group_number", SqlDbType.Real));
                    sqlCommand.Parameters["@group_number"].Value = student.Groupnumber;
                    sqlCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 20));
                    sqlCommand.Parameters["@name"].Value = student.Name;
                    sqlCommand.Parameters.Add(new SqlParameter("@lastname", SqlDbType.VarChar, 45));
                    sqlCommand.Parameters["@lastname"].Value = student.LastName;
                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error");
                        return false;
                    }
                }
            }
            using (SqlCommand checkCommand = new SqlCommand("Select COUNT(*) From Students", connection))
            {
                var numberOfRows = checkCommand.ExecuteScalar();
                MessageBox.Show($"Student table consist of {numberOfRows} number of rows.", "info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return true;
        }
        public static bool UpdateStudentDataBase(IEnumerable<string> idOfChangedStudents)
        {
            var group = Group.Groupnumber;
            var query = @"UPDATE Students
                            SET name = @newName, lastname = @newLastName
                            WHERE given_id = @id AND group_number= @group ";
            if (!IsDBEmpty())
            {
                using (SqlConnection connection = new SqlConnection(_connectionStr))
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        var dataToChange = Group.Students.Where(s => idOfChangedStudents.Contains(s.Id));
                        foreach (var student in dataToChange)
                        {
                            command.Parameters.Add("@newName", SqlDbType.VarChar, 20).Value = student.Name;
                            command.Parameters.Add("@newLastName", SqlDbType.VarChar, 45).Value = student.LastName;
                            command.Parameters.Add("@id", SqlDbType.Int).Value = student.Id;
                            command.Parameters.Add("@group", SqlDbType.Real).Value = student.Groupnumber;
                        }
                        command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("DB is empty.");
            }

            return true;
        }
        public static bool StudentDBAddStudents(IEnumerable<Student> AddedStudents)
        {
            if (!IsDBEmpty())
            {
                using (SqlConnection connection = new SqlConnection(_connectionStr))
                {
                    connection.Open();
                    foreach (var student in AddedStudents)
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("dbo.uspNewStudent", connection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            sqlCommand.Parameters.Add(new SqlParameter("@given_id", SqlDbType.Int));
                            sqlCommand.Parameters["@given_id"].Value = student.Id;
                            sqlCommand.Parameters.Add(new SqlParameter("@group_number", SqlDbType.Real));
                            sqlCommand.Parameters["@group_number"].Value = student.Groupnumber;
                            sqlCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 20));
                            sqlCommand.Parameters["@name"].Value = student.Name;
                            sqlCommand.Parameters.Add(new SqlParameter("@lastname", SqlDbType.VarChar, 45));
                            sqlCommand.Parameters["@lastname"].Value = student.LastName;
                            try
                            {
                                sqlCommand.ExecuteNonQuery();
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message, "Error");
                                return false;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("DB is empty.");
            }
            return true;
        }
        public static bool UpdateSubjectsDBModifyGrade(int id)
        {
            var query = @"UPDATE Subjects
                            SET grade = @newGrade
                            WHERE idStudent = @id AND caption = @chosenSub";
            if (!IsDBEmpty())
            {
                foreach (var sub in ListOfChangesSubs)
                {
                    if (sub.InnitialSub == "ForGrade")
                        using (SqlConnection connection = new SqlConnection(_connectionStr))
                        {
                            try
                            {
                                SqlCommand command = new SqlCommand(query, connection);
                                connection.Open();
                                command.Parameters.Add("@chosenSub", SqlDbType.NVarChar, 100).Value = sub.SubjectToChange.Caption;
                                command.Parameters.Add("@newGrade", SqlDbType.Int).Value = sub.SubjectToChange.Grade;
                                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                                command.ExecuteNonQuery();
                                MessageBox.Show($"Data base updated with new grade successfully.", "Success");
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                }
            }
            else
            {
                MessageBox.Show("DB is empty.");
            }
            return true;
        }
        public static void UpdateSubjectsDBModifyName(int id)
        {
            bool subjectsExist = true;
            var query = @"UPDATE Subjects
                            SET caption = @newCaption
                            WHERE idStudent = @id AND caption = @initialC";
            if (!IsDBEmpty() && subjectsExist)
            {
                using (SqlConnection connection = new SqlConnection(_connectionStr))
                {
                    connection.Open();
                    foreach (var sub in ListOfChangesSubs)
                    {
                        if (sub.InnitialSub != sub.FormattedSub)
                        {
                            try
                            {
                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.Add("@initialC", SqlDbType.NVarChar, 100).Value = sub.InnitialSub;
                                command.Parameters.Add("@newCaption", SqlDbType.NVarChar, 100).Value = sub.FormattedSub;
                                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                                command.ExecuteNonQuery();
                                sub.InnitialSub = sub.FormattedSub;
                                MessageBox.Show($"Data base updated with subject value {sub.FormattedSub} successfully.", "Success");
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("DB is empty.");
            }
        }
        public static bool SubjectsDBAddSubject(int id)
        {
            bool status = true;
            if (!IsDBEmpty())
            {
                var connection = new SqlConnection(_connectionStr);
                connection.Open();
                foreach (var sub in ListOfChangesSubs)
                {
                    if (sub.InnitialSub == "NewSub")
                    {
                        using (var sqlCommand = new SqlCommand("dbo.uspNewSubject", connection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.Add("@caption", SqlDbType.NVarChar, 100).Value = sub.SubjectToChange.Caption;
                            sqlCommand.Parameters.Add("@grade", SqlDbType.Int).Value = sub.SubjectToChange.Grade;
                            sqlCommand.Parameters.Add("@idStudent", SqlDbType.Int).Value = id;
                            try
                            {
                                sqlCommand.ExecuteNonQuery();
                                AddNewRelation(ref connection, id);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                status = false;
                            }
                        }
                    }
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("DB is empty.");
            }
            return status;
        }
        public static bool SubjectsDBDeleteSubject(object id, Subject subject)
        {
            var query = @"DELETE SB
                    FROM Subjects SB
                    INNER JOIN Students S ON SB.idStudent = S.given_id
                    WHERE SB.idStudent = @id AND SB.caption = @chosenSub 
                    AND S.group_number = @group";
            if (!IsDBEmpty())
            {
                using (SqlConnection connection = new SqlConnection(_connectionStr))
                {
                    connection.Open();
                    try
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.Add("@chosenSub", SqlDbType.NVarChar, 100).Value = subject.Caption;
                        command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        command.Parameters.Add("@group", SqlDbType.Int).Value = Group.Groupnumber;
                        command.ExecuteNonQuery();
                        MessageBox.Show($"Subject {subject.Caption} was deleted successfully.", "Success");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("DB is empty.");
            }
            return true;
        }
        public static void AddNewRelation(ref SqlConnection connection, int id)
        {
            string query = @"INSERT INTO Students_has_Subjects
                        SELECT s.idStudents, su.idSubjects
                        FROM Students s
                        INNER JOIN Subjects su ON s.given_id = su.idStudent
                        WHERE s.given_id = @id AND s.group_number = @group
                        AND NOT EXISTS (
                            SELECT * FROM Students_has_Subjects ss 
                            WHERE ss.Students_idStudents = s.idStudents AND ss.Subjects_id = su.idSubjects
                        );";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.Parameters.Add("@group", SqlDbType.Int).Value = Group.Groupnumber;
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show($"Junction table was updated.", "info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

        }
        public static bool IsDBEmpty()
        {
            bool status = true;
            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                SqlCommand command = new SqlCommand(
                   "SELECT * FROM Students;", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows) status = false;
            }
            return status;
        }
    }
}
