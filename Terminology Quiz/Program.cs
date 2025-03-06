/*
 * Programming II Quiz Framework
 * Tyler Hitchcock, 3/6/25
 * credits: 
 * Modified and extended code provided in class: https://github.com/janell-baxter/ProgrammingII-QuizFramework 
 */

namespace Terminology_Quiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Terminology Quiz";
            Engine engine = new Engine();
            engine.Start();
        }
    }
}
