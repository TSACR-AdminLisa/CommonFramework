using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int suma = 1 + int.Parse("0.x1");
            }
            catch (Exception ex)
            {
                ErrorHandling.Error error = new ErrorHandling.Error();
                error.RegisterErrorEventLog(ex, "Main", "Program.cs");
            }
            Console.ReadKey();
        }
    }
}
