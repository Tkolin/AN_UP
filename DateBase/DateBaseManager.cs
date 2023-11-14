using System.Collections.Generic;
using MySqlConnector;

namespace AN_UP.DateBase;

public class DateBaseManager
{
    /// Настройки подключения
    public static MySqlConnectionStringBuilder ConnectionString =
        new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            Database = "mdk",
            UserID = "root",
            Password = "tkl909"// "tkl909"//"nrjkby99"
        };
    // Получение
    public static List<Disease> GetDiseases()
    {
        List<Disease> data = new List<Disease>();

        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();

            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM Disease";

                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new Disease(
                                reader.GetInt32("ID"),
                                reader.GetString("Name"),
                                reader.GetInt32("DurationLiness")
                            )
                        );
                    }
                }
            }
            connection.Close();
        }
        return data;
    }
    public static List<DiseaseRecord> GetDiseaseRecords()
    {
        List<DiseaseRecord> data = new List<DiseaseRecord>();

        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();

            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM DiseaseRecord";

                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new DiseaseRecord(
                                reader.GetInt32("ID"),
                                reader.GetInt32("PatientID"),
                                reader.GetDecimal("FinalPrice"),
                                reader.GetDateTime("DateStart"),
                                reader.GetDateTime("DateEnd"),
                                reader.GetInt32("StatusID"),
                                reader.GetInt32("AttendingDoctorID"),
                                reader.GetInt32("DiseaseID")
                            )
                        );
                    }
                }
            }
            connection.Close();
        }
        return data;
    }
    public static List<Doctor> GetDoctors()
    {
        List<Doctor> data = new List<Doctor>();

        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();

            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM Doctor";

                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new Doctor(
                                reader.GetInt32("ID"),
                                reader.GetString("FirstName"),
                                reader.GetString("LastName"),
                                reader.GetString("Patronymic"),
                                reader.GetDateTime("EmploymentDate"),
                                reader.GetInt32("PositionID"),
                                reader.GetString("Login"),
                                reader.GetString("Password")
                            )
                        );                    }
                }
            }
            connection.Close();
        }
        return data;
    }
    public static List<Patient> GetPatients()
    {
        List<Patient> data = new List<Patient>();

        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();

            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM Patient";

                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new Patient(
                                reader.GetInt32("ID"),
                                reader.GetString("FirstName"),
                                reader.GetString("LastName"),
                                reader.GetString("Patronymic"),
                                reader.GetDateTime("DateBirth"),
                                reader.GetString("PhoneNumber")
                            )
                        );
                    }
                }
            }
            connection.Close();
        }
        return data;
    }
    public static List<Position> GetPositions()
    {
        List<Position> data = new List<Position>();

        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();

            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM Position";

                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new Position(
                                reader.GetInt32("ID"),
                                reader.GetString("Name")
                            )
                        );
                    }
                }
            }
            connection.Close();
        }
        return data;
    }
   
    public static List<Procedure> GetProcedures()
    {
        List<Procedure> data = new List<Procedure>();

        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();

            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM Procedure";

                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new Procedure(
                                reader.GetInt32("ID"),
                                reader.GetInt32("DoctorID"),
                                reader.GetInt32("DiseaseRecordID"),
                                reader.GetString("Description"),
                                reader.GetDateTime("DateStart"),
                                reader.GetInt32("Duration"),
                                reader.GetDecimal("Cost")
                            )
                        );        
                    }
                }
            }
            connection.Close();
        }
        return data;
    }
    public static List<Receipt> GetReceipts()
    {
        List<Receipt> data = new List<Receipt>();

        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();

            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM Receipt";

                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new Receipt(
                                reader.GetInt32("ID"),
                                reader.GetDecimal("Amount"),
                                reader.GetInt32("DiseaseRecrodID"),
                                reader.GetDateTime("DatePayment")
                            )
                        );
                    }
                }
            }
            connection.Close();
        }
        return data;
    }
    public static List<Status> GetStatusList()
    {
        List<Status> data = new List<Status>();

        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();

            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM Status";

                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new Status(
                                reader.GetInt32("ID"),
                                reader.GetString("Name")
                            )
                        );
                    }
                }
            }
            connection.Close();
        }
        return data;
    }
}