using Microsoft.Extensions.Configuration;
using ModelExmaple2.Models;
using ModelExmaple2.Data;
using System.Text.Json;

namespace ModelExample2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

            DataContextDapper dapper = new DataContextDapper(config);

            string computersJson = File.ReadAllText("Computers.json");

            //Console.WriteLine(computersJson);

            //JsonSerializerOptions options = new JsonSerializerOptions()
            //{
            //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            //    WriteIndented = true,
            //};

            IEnumerable<Computer>? computers = JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson);

            if(computers != null)
            {
                foreach (Computer computer in computers)
                {
                    Console.WriteLine(computer.ComputerId + " " + computer.MotherBoard + " " + computer.HasWifi + " " + computer.HasLTE + " " + computer.ReleaseDate + " " +
                        computer.VideoCard);
                }
            }
        }
    }
}