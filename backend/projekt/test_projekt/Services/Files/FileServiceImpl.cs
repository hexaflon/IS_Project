using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using CsvHelper;
using test_projekt.Services.Files;
using MySql.Data.MySqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Text.Json;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace test_projekt.Services.Impl
{
    public class FileServiceImpl : IFileService
    { 
        public static XmlDocument xmlDocument;
        public static JsonDocument jsonDocument;
        private string xmlfilepath = "\\import\\data.xml";
        private string jsonFilePath = "\\import\\data.json";
        private readonly IConfiguration configuration;
        public FileServiceImpl(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ImportXml()
        {
            string currentDirectory = Environment.CurrentDirectory;
            Console.WriteLine(currentDirectory + xmlfilepath);
            string path = currentDirectory + xmlfilepath;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                xmlDocument = xmlDoc;
                if (xmlDocument != null)
                {
                    Console.WriteLine("Import powiódł się");
                }
                else
                {
                    Console.WriteLine("Error");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        //import z pliku json do bazy
        public void ImportJson()
        {
            string currentDirectory = Environment.CurrentDirectory;
            Console.WriteLine(currentDirectory + jsonFilePath);
            string path = currentDirectory + jsonFilePath;
            string connectionString = configuration["connetionString"];

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    Console.WriteLine("rozpoczecie");
                    try
                    {
                        Console.WriteLine("test");
                        if (File.Exists(path))
                        {
                            string jsonString = File.ReadAllText(path);
                            Console.WriteLine(jsonString);
                            var mieszkanieList = JsonConvert.DeserializeObject<List<Mieszkaniec>>(jsonString);
                            jsonDocument = JsonDocument.Parse(jsonString);
                            Console.WriteLine(jsonString);

                            if (jsonDocument != null)
                            {
                                foreach (var mieszkanie in mieszkanieList)
                                {
                                    string query = "INSERT INTO liczba_mieszkancow (id, rok, ilosc_kobiet, ilosc_mezczyzn, wszyscy) " +
                                                   "VALUES (@id, @rok, @ilosc_kobiet, @ilosc_mezczyzn, @wszyscy)";
                                    //Console.WriteLine(query);

                                    using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
                                    {
                                        command.Parameters.AddWithValue("@id", mieszkanie.id);
                                        command.Parameters.AddWithValue("@rok", mieszkanie.GetRok());
                                        command.Parameters.AddWithValue("@ilosc_kobiet", mieszkanie.GetIloscKobiet());
                                        command.Parameters.AddWithValue("@ilosc_mezczyzn", mieszkanie.GetIloscMezczyzn());
                                        command.Parameters.AddWithValue("@wszyscy", mieszkanie.GetWszyscy());
                                        command.ExecuteNonQuery();
                                        //Console.WriteLine("udalo");
                                    }
                                }

                                transaction.Commit();
                            }
                            else
                            {
                                Console.WriteLine("Error");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Plik nie istnieje");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                        transaction.Rollback();
                    }
                }
            }
        }



        public void ExportXml()
        {

            try
            {
                string currentDirectory = Environment.CurrentDirectory;
                string path = currentDirectory + "\\export\\data.xml";

                XmlDocument export = new XmlDocument();
                //export = import();
                //ImportXml();
                export = xmlDocument;
                export.Save(path);
                Console.WriteLine("Export powiódł sie");


            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        //export do pliku danych z tabeli liczba_mieszkancow
        public void ExportJson()
        {
            try
            {
                Console.WriteLine("1");
                string currentDirectory = Environment.CurrentDirectory;
                string path = currentDirectory + "\\export\\liczba_mieszkancow.json";
                File.WriteAllText(path, get_mieszkancy());
                Console.WriteLine("12");
                path = currentDirectory + "\\export\\liczba_bezrobotnych.json";
                File.WriteAllText(path, GetTableDataAsJson());

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        //usuniecie z tabeli liczba_bezrobotnych
        public bool DeleteFromData(int id)
        {
            string connectionString = configuration["connetionString"];
            string tableName = "liczba_bezrobotnych";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string lockTableQuery = $"LOCK TABLES {tableName} WRITE;";
                        using (MySqlCommand lockTableCommand = new MySqlCommand(lockTableQuery, connection, transaction))
                        {
                            lockTableCommand.ExecuteNonQuery();
                        }

                        string deleteQuery = $"DELETE FROM {tableName} WHERE id = @id;";
                        using (MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection, transaction))
                        {
                            deleteCommand.Parameters.AddWithValue("@id", id);
                            Console.WriteLine(deleteCommand.CommandText);
                            int rowsAffected = deleteCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine("yep");
                                transaction.Commit();
                                return true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                        return false;
                    }
                    finally
                    {
                        string unlockTableQuery = "UNLOCK TABLES;";
                        using (MySqlCommand unlockTableCommand = new MySqlCommand(unlockTableQuery, connection, transaction))
                        {
                            unlockTableCommand.ExecuteNonQuery();
                        }
                    }
                }
            }

            Console.WriteLine("er");
            return false;
        }

        public XmlDocument GetDocument()
        {

            return xmlDocument;

        }
        public JsonDocument GetJson()
        {
            //return get_mieszkancy();
            return jsonDocument;
        }
        //wyswietlenie danych z tabeli liczba_mieszkancow
        public string get_mieszkancy()
        {
            string connectionString = configuration["connetionString"];
            string tableName = "liczba_mieszkancow";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("2");
                string query = $"SELECT * FROM {tableName};";
                //string query = "Select * FROM INFORMATION_SCHEMA.TABLES";
                Console.WriteLine("3");
                Console.WriteLine(query);
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("4");
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        string jsonData = JsonConvert.SerializeObject(dataTable);
                        Console.WriteLine(jsonData);
                        Console.WriteLine("5");
                        return jsonData;
                    }
                }
            }
        }
        //zapis liczba_mieszkancow do xml
        public void SaveDataAsXml()
        {
            string tableName = "liczba_mieszkancow";
            string connectionString = configuration["connetionString"];
            Console.WriteLine("2");
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM {tableName};";
                Console.WriteLine("3");
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        XDocument xdoc = new XDocument();
                        XElement root = new XElement("Data");
                        Console.WriteLine("4");
                        foreach (DataRow row in dataTable.Rows)
                        {
                            XElement record = new XElement("Record");
                            foreach (DataColumn column in dataTable.Columns)
                            {
                                record.Add(new XElement(column.ColumnName, row[column]));
                            }
                            root.Add(record);
                        }
                        string currentDirectory = Environment.CurrentDirectory;
                        string path = currentDirectory + "\\export\\data.xml";
                        xdoc.Add(root);
                        xdoc.Save(path);
                        Console.WriteLine("5");
                    }
                }
            }
        }
        public void ExportDataToCsv()
        {
            string connectionString = configuration["connetionString"];
            string tableName = "liczba_bezrobotnych";
            string csvFilePath = Environment.CurrentDirectory;
            csvFilePath += "\\export\\zbazy.csv";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand($"SELECT * FROM {tableName}", connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        using (StreamWriter streamWriter = new StreamWriter(csvFilePath))
                        {
                            using (CsvWriter csvWriter = new CsvWriter(streamWriter, System.Globalization.CultureInfo.InvariantCulture))
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    csvWriter.WriteField(reader.GetName(i));
                                }
                                csvWriter.NextRecord();
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        csvWriter.WriteField(reader[i]);
                                    }
                                    csvWriter.NextRecord();
                                }
                            }
                        }
                    }
                }
            }
        }

        public string GetTableDataAsJson()
        {
            string connectionString = configuration["connetionString"];
            string tableName = "liczba_bezrobotnych";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT d.id,k.nazwa as 'kraj',t.nazwa as 'zmienna',d.rok,d.miesiac,d.wartosc FROM {tableName} as d inner join kraj as k on k.id=d.kraj_id " +
                    $"inner join typ_danej as t on t.id = d.zmienna_id;";
                    //string query = "Select * FROM INFORMATION_SCHEMA.TABLES";
		Console.WriteLine(query);
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        string jsonData = JsonConvert.SerializeObject(dataTable);
			Console.WriteLine(jsonData);
                        return jsonData;
                    }
                }
            }
        }







        public void ImportCsvToDB()
        {
            string connectionString = configuration["connetionString"];
            string tableName = "liczba_bezrobotnych";
            string csvFilePath = Environment.CurrentDirectory;
            csvFilePath += "\\import\\dobazy.csv";
            Console.WriteLine(csvFilePath);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (System.IO.StreamReader reader = new System.IO.StreamReader(csvFilePath))
                {
                    reader.ReadLine();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        using (MySqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                string[] fields = line.Split(';');

                                string query = $"INSERT INTO {tableName} " +
                                               $"VALUES ('{fields[0]}', '{fields[1]}', '{fields[2]}', '{fields[3]}', '{fields[4]}', '{fields[5]}');";
                                Console.WriteLine(query);

                                using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
                                {
                                    command.ExecuteNonQuery();
                                    Console.WriteLine("Wiersz z pliku CSV został zaimportowany.");
                                    transaction.Commit();
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                transaction.Rollback();
                            }
                        }
                    }
                }
            }
        }
    }
}
