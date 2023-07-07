namespace FileReadWrite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello ASP.NET Programmers\n";

            //File.WriteAllText("log.txt", str);
            using StreamWriter openFile = new StreamWriter("log.txt", true);

            openFile.AutoFlush = true;

            openFile.WriteLine(str);

            openFile.Close();

            Console.WriteLine(File.ReadAllText("log.txt")); 
        }
    }
}