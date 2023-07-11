using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ModelExmaple.Data;
using ModelExmaple.Models;
using System.Data;

namespace ModelExmaple
{    

    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                    .AddJsonFile("appSettings.json").Build();

            DataContextDapper dataContextDapper = new DataContextDapper(config);
            DataContextEF dataContextEF = new DataContextEF(config);

            string connectionString = "Server=192.168.72.230;Database=EmployeeInfo_YK;TrustServerCertificate=True;Trusted_Connection=True;";

            //For Mac and Linux users
            //string connectionString = "Server=192.168.72.230;Database=EmployeeInfo_YK;TrustServerCertificate=True;Trusted_Connection=False;User ID=sa;Password=SQLConnect1;";

            IDbConnection dbConnection = new SqlConnection(connectionString);

            string sqlCommand = "SELECT GETDATE();";          
            
            DateTime dateTime = dataContextDapper.LoadDataSingle<DateTime>(sqlCommand);

            Console.WriteLine(dateTime);
            //Console.WriteLine();

            Computer computer = new Computer()
            {
                MotherBoard = "Z687",
                CPUCores = 1,
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 1099.98m,
                VideoCard = "7KVD",
            };

            dataContextEF.Add(computer);
            dataContextEF.SaveChanges();

            string sql = @"Insert Into TutorialAppSchema.Computer(MotherBoard,CPUCores,HasWifi, HasLTE, ReleaseDate, Price, VideoCard)
                    Values('" + computer.MotherBoard + "','" + computer.CPUCores + "','" + computer.HasWifi + "','" + computer.HasLTE 
                    + "','" + computer.ReleaseDate + "','" + computer.Price + "','" + computer.VideoCard + "');";

            int numRowsAffected = dataContextDapper.ExecuteSingleWithRowcount(sql);
            bool rowsAffected = dataContextDapper.ExecuteSingle(sql);
            
            Console.WriteLine(numRowsAffected);
            Console.WriteLine(rowsAffected);

            string sqlSelect = @"SELECT ComputerId, MotherBoard, CPUCores, HasWifi, HasLTE, ReleaseDate, Price, VideoCard FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = dataContextDapper.LoadData<Computer>(sqlSelect);
            

            Console.WriteLine("ComputerId,MotherBoard,CPUCores, HasWifi, HasLTE, ReleaseDate, Price, VideoCard");
            Console.WriteLine("---------------------------------------------------------------");

            foreach(Computer comp in computers) 
            {
                Console.WriteLine("'" + comp.ComputerId +  "'" + comp.MotherBoard + "','" + comp.CPUCores + "','"  + comp.HasWifi + "','" + comp.HasLTE + "','" + comp.ReleaseDate 
                    + "','" + comp.Price + "','" + comp.VideoCard + "'");
            }

            IEnumerable<Computer> computersEF = dataContextEF.computer.ToList<Computer>();

            if(computersEF != null)
            {
                Console.WriteLine("ComputerId,MotherBoard,CPUCores, HasWifi, HasLTE, ReleaseDate, Price, VideoCard");
                Console.WriteLine("---------------------------------------------------------------");

                foreach (Computer comp in computersEF)
                {
                    Console.WriteLine("'" + comp.ComputerId + "'" + comp.MotherBoard + "','" + comp.CPUCores + "','" + comp.HasWifi + "','" + comp.HasLTE + "','" + comp.ReleaseDate
                    + "','" + comp.Price + "','" + comp.VideoCard + "'");
                }
            }            

            //Console.WriteLine(computer.MotherBoard);
            //Console.WriteLine(computer.HasWifi);
            //Console.WriteLine(computer.HasLTE);
            //Console.WriteLine(computer.ReleaseDate);
            //Console.WriteLine(computer.Price);
            //Console.WriteLine(computer.VideoCard);
        }
    }
}