using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;

namespace ModelExample3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Windows Authentication
            //string connectionString = "Server=192.168.72.230;Database=EmployeeInfo_YK;TrustServerCertificate=True;Trusted_Connection=True;";
            //string connectionString = "Server=myServerName;Database=myDataBase;TrustServerCertificate=True;Trusted_Connection=True;";

            //SQL Authentication
            //string connectionString = "Server=myServerName; Database = myDataBase; User Id = myUsername; Password = myPassword;";

            //ADO.NET Architecture
            //Approach1: Connected Architecture
            //SqlConnection sqlConnection = new SqlConnection(connectionString);
            //sqlConnection.Open();

            //string selectSQL = "Select * From [TutorialAppSchema].[Computer]";
            //SqlCommand sqlCommand = new SqlCommand(selectSQL, sqlConnection);

            //SqlDataReader reader = sqlCommand.ExecuteReader();

            //Console.WriteLine("ComputerId | MotherBoard | CPUCores | HasLTE | HasWiFi | ReleaseDate | Price| VideoCard");
            //while (reader.Read())
            //{
            //    Console.WriteLine(reader["ComputerId"] + "|" + reader["MotherBoard"] + "|" + reader["CPUCores"] + "|" + reader["HasWiFi"] + "|" + reader["HasWiFi"]
            //    + "|" + reader["ReleaseDate"] + "|" + reader["Price"] + "|" + reader["VideoCard"]);
            //}
            //reader.Close();

            //Computer computer = new Computer()
            //{
            //    MotherBoard = "X9087",
            //    CPUCores = 10,
            //    HasWifi = false,
            //    HasLTE = true,
            //    ReleaseDate = DateTime.Parse("6/13/2003"),
            //    Price = 1433.99m,
            //    VideoCard = "8UTBD"
            //};

            //string insertSQL = @"Insert into [TutorialAppSchema].[Computer]([Motherboard],[CPUCores],[HasWifi],[HasLTE],[ReleaseDate],[Price],[VideoCard]) Values('"
            //            + computer.MotherBoard + "','" + computer.CPUCores + "','" + computer.HasWifi + "','" + computer.HasLTE + "','" + computer.ReleaseDate + "','"
            //            + computer.Price + "','" + computer.VideoCard + "')";

            //sqlCommand = new SqlCommand(insertSQL, sqlConnection);
            //sqlCommand.CommandType = CommandType.Text;
            //sqlCommand.ExecuteNonQuery();

            //selectSQL = "Select * From [TutorialAppSchema].[Computer]";
            //sqlCommand = new SqlCommand(selectSQL, sqlConnection);
            //sqlCommand.CommandType = CommandType.Text;
            //reader = sqlCommand.ExecuteReader();

            //Console.WriteLine("ComputerId | MotherBoard | CPUCores | HasLTE | HasWiFi | ReleaseDate | Price| VideoCard");
            //while (reader.Read())
            //{
            //    Console.WriteLine(reader["ComputerId"] + "|" + reader["MotherBoard"] + "|" + reader["CPUCores"] + "|" + reader["HasWiFi"] + "|" + reader["HasWiFi"]
            //    + "|" + reader["ReleaseDate"] + "|" + reader["Price"] + "|" + reader["VideoCard"]);
            //}
            //reader.Close();

            //Approach 2: Disconnected Architecture
            //SqlConnection sqlConnection = new SqlConnection(connectionString);
            //sqlConnection.Open();

            //string query = "Select * From [TutorialAppSchema].[Computer]";
            //SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            //sqlCommand.CommandType = CommandType.Text;
            //sqlCommand.CommandText = query;

            //SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            //DataSet ds = new DataSet();
            //adapter.Fill(ds);

            //Console.WriteLine("ComputerId | MotherBoard | CPUCores | HasLTE | HasWiFi | ReleaseDate | Price| VideoCard");
            //foreach (DataTable dt in ds.Tables)
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        Console.WriteLine(dr["ComputerId"] + "|" + dr["MotherBoard"] + "|" + dr["CPUCores"] + "|" + dr["HasLTE"] + "|" + dr["HasWiFi"] + "|" + dr["ReleaseDate"]
            //                + "|" + dr["Price"] + "|" + dr["VideoCard"]);
            //    }

            //}

            //Computer computer = new Computer();
            //computer.MotherBoard = "X9087";
            //computer.CPUCores = 10;
            //computer.HasWifi = false;
            //computer.HasLTE = true;
            //computer.ReleaseDate = DateTime.Parse("6/13/2003");
            //computer.Price = 1433.99m;
            //computer.VideoCard = "8UTBD";

            //string sqlinsert = @"Insert into [TutorialAppSchema].[Computer](Motherboard,CPUCores,HasWifi,HasLTE,ReleaseDate,Price,VideoCard) Values(" +
            //            "'" + computer.MotherBoard + "','" + computer.CPUCores + "','" + computer.HasWifi + "','" + computer.HasLTE + "','" + computer.ReleaseDate
            //            + "','" + computer.Price + "','" + computer.VideoCard + "')";

            //Console.WriteLine(sqlinsert);

            //SqlCommand sqlCommand = new SqlCommand(sqlinsert, sqlConnection);
            //sqlCommand.CommandType = CommandType.Text;
            //int rowsAffected = sqlCommand.ExecuteNonQuery();
            //Console.WriteLine(rowsAffected > 0);



            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
            //Approach 3: Dapper
            //string sqlSelect = "SELECT GETDATE()";
            //DataContextDapper dapper = new DataContextDapper(config);
            //DateTime dateTime = dapper.LoadDataSingle<DateTime>(sqlSelect);
            //Console.WriteLine(dateTime);


            //Computer computer = new Computer()
            //{
            //    MotherBoard = "Z687",
            //    CPUCores = 1,
            //    HasWifi = true,
            //    HasLTE = false,
            //    ReleaseDate = DateTime.Now,
            //    Price = 1099.98m,
            //    VideoCard = "7KVD",
            //};

            //string sql = @"Insert Into TutorialAppSchema.Computer(MotherBoard,CPUCores,HasWifi, HasLTE, ReleaseDate, Price, VideoCard)
            //        Values('"
            //+ computer.MotherBoard + "','" + computer.CPUCores + "','" + computer.HasWifi + "','" + computer.HasLTE
            //+ "','" + computer.ReleaseDate + "','" + computer.Price + "','" + computer.VideoCard + "');";

            //int numRowsAffected = dapper.ExecuteSqlWithRowcount(sql);
            //bool rowsAffected = dapper.ExecuteSql(sql);

            //sqlSelect = @"SELECT ComputerId, MotherBoard, CPUCores, HasWifi, HasLTE, ReleaseDate, Price, VideoCard FROM TutorialAppSchema.Computer";
            //IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

            //Console.WriteLine("ComputerId | MotherBoard | CPUCores | HasLTE | HasWiFi | ReleaseDate | Price| VideoCard");
            //foreach (Computer comp in computers)
            //{
            //    Console.WriteLine(comp.ComputerId + "|" + comp.MotherBoard + "|" + comp.CPUCores + "|" + comp.HasLTE + "|" + comp.HasWifi + "|" + comp.ReleaseDate
            //              + "|" + comp.Price + "|" + comp.VideoCard);
            //}


            //Approach 4: Entity Framework
            //DataContextEF entityframework = new DataContextEF(config);


            //Computer computer = new Computer()
            //{
            //    MotherBoard = "Z687",
            //    CPUCores = 1,
            //    HasWifi = true,
            //    HasLTE = false,
            //    ReleaseDate = DateTime.Now,
            //    Price = 1099.98m,
            //    VideoCard = "7KVD",
            //};

            //entityframework.Add(computer);
            //entityframework.SaveChanges();

            //List<Computer> computers = entityframework.computer.ToList<Computer>();

            //if (computers != null)
            //{
            //    Console.WriteLine("ComputerId | MotherBoard | CPUCores | HasLTE | HasWiFi | ReleaseDate | Price| VideoCard");
            //    foreach (Computer comp in computers)
            //    {
            //        Console.WriteLine(comp.ComputerId + "|" + comp.MotherBoard + "|" + comp.CPUCores + "|" + comp.HasLTE + "|" + comp.HasWifi + "|" + comp.ReleaseDate
            //                  + "|" + comp.Price + "|" + comp.VideoCard);
            //    }
            //}


            //JSON Concepts
            string computersJson = File.ReadAllText("Computers.json");
            //DataContextDapper dapper = new DataContextDapper(config);
            DataContextEF entityframework = new DataContextEF(config);

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson,options);
            IEnumerable<Computer>? computersNewtonsoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

            if (computersNewtonsoft != null)
            {
                foreach (Computer comp in computersNewtonsoft)
                {                    
                    Computer computer = new Computer()
                    {
                        MotherBoard = comp.MotherBoard,
                        CPUCores = comp.CPUCores,
                        HasWifi = comp.HasWifi,
                        HasLTE = comp.HasLTE,
                        ReleaseDate = comp.ReleaseDate,
                        Price = comp.Price,
                        VideoCard = comp.VideoCard,
                    };
                    entityframework.Add(computer);
                    entityframework.SaveChanges();                   

                }
            }

            List<Computer> computers = entityframework.computer.ToList<Computer>();

            if (computers != null)
            {
                Console.WriteLine("ComputerId | MotherBoard | CPUCores | HasLTE | HasWiFi | ReleaseDate | Price| VideoCard");
                foreach (Computer comp in computers)
                {
                    Console.WriteLine(comp.ComputerId + "|" + comp.MotherBoard + "|" + comp.CPUCores + "|" + comp.HasLTE + "|" + comp.HasWifi + "|" + comp.ReleaseDate
                              + "|" + comp.Price + "|" + comp.VideoCard);
                }
            }

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };

            //string computersCopyNewtonsoft = JsonConvert.SerializeObject(computersJson, serializerSettings);
            //File.WriteAllText("computersCopyNewtonSoft.txt", "\n" + computersCopyNewtonsoft + "\n");

            //string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computersJson);
            //File.WriteAllText("computersCopySystem.txt", "\n" + computersCopySystem + "\n");


            //Model Mapping
            //1. AutoMapper
            //string computersJson = File.ReadAllText("ComputersSnake.json");
            //Mapper mapper = new Mapper(new MapperConfiguration((cfg) => cfg.CreateMap<ComputersSnake, Computer>()
            //        .ForMember(destination => destination.ComputerId, options => options.MapFrom(source => source.computer_id))
            //        .ForMember(destination => destination.MotherBoard, options => options.MapFrom(source => source.motherboard))
            //        .ForMember(destination => destination.HasWifi, options => options.MapFrom(source => source.has_wifi))
            //        .ForMember(destination => destination.HasLTE, options => options.MapFrom(source => source.has_lte))
            //        .ForMember(destination => destination.ReleaseDate, options => options.MapFrom(source => source.release_date))
            //        .ForMember(destination => destination.Price, options => options.MapFrom(source => source.price))
            //        .ForMember(destination => destination.VideoCard, options => options.MapFrom(source => source.video_card))
            //));

            //IEnumerable<ComputersSnake>? computersAutoMapper = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ComputersSnake>>(computersJson);

            //if (computersAutoMapper != null)
            //{
            //    IEnumerable<Computer> computerResult = mapper.Map<IEnumerable<Computer>>(computersAutoMapper);                
            //    foreach (Computer computer in computerResult)
            //    {
            //        Console.WriteLine(computer.MotherBoard);
            //    }
            //}

            //2. JsonPropertyName attribute
            //string computersJson = File.ReadAllText("ComputersSnake.json");
            //IEnumerable<Computer>? computersJsonPropertyMapping = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson);
            //if (computersJsonPropertyMapping != null)
            //{
            //    Console.WriteLine("computer_id  |   motherboard |   has_wifi |   has_lte |   release_date   |   video_card  |   cpu_cores   |   price");
            //    foreach (Computer comp in computersJsonPropertyMapping)
            //    {
            //        Console.WriteLine(comp.ComputerId + "|" + comp.MotherBoard + "|" + comp.HasWifi + "|" + comp.HasLTE + "|" + comp.ReleaseDate + "|" +
            //            comp.VideoCard + "|" + comp.CPUCores + "|" + comp.Price);
            //    }         

            //}
        }

        private static string EscapeSingleQuote(string input)
        {            
              string result = input.Replace("'", "''");
              return result;            
        }
    }
}