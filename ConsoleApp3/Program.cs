namespace ConsoleApp3
{
    public class Program
    {
        static int i = 40;        

        static void Main(string[] args)
        {

            //Student student = new Student();
            //student.Age = 30;
            //student.Name = "Deepak";
            //student.Address = "New Delhi";

            //Console.WriteLine(student.Age);
            //Console.WriteLine(student.Name);
            //Console.WriteLine(student.Address);

            //student.returnHello();
            //student.returnHello("Yesh");
            //Console.WriteLine();

            //Student scienceStudent = new ScienceStudent();
            //scienceStudent.Age = 40;
            //scienceStudent.Name = "Nikhil";
            //scienceStudent.Address = "Chennai";

            //Console.WriteLine(scienceStudent.Age);
            //Console.WriteLine(scienceStudent.Name);
            //Console.WriteLine(scienceStudent.Address);
            //scienceStudent.returnHello();
            //scienceStudent.returnHello("XYZ");

            Student student = new ScienceStudent();
            student.returnHello("Max");
        }
        
    }

    
}