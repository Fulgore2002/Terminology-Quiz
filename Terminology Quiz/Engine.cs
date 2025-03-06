using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Terminology_Quiz
{
    internal class Engine
    {
        Quiz quiz = new Quiz();

        public void Start()
        {
            LoadData();
            Menu();
        }
        //FIRST   
        private void LoadData()
        {
            string[] contents = GetDataFromTextFile("../../../data/data.txt");

            // Assuming the file has data in "Term:Definition" format on each line
            foreach (string line in contents)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2)
                {
                    quiz.TermsAndDefinitions[parts[0].Trim()] = parts[1].Trim();
                }
            }
        }

        private string[] GetDataFromTextFile(string path) => File.ReadAllLines(path);


        //SECOND    
        private string GetAllData()
        {
            string output = "";
            foreach (var pair in quiz.TermsAndDefinitions)
            {
                output += $"{pair.Key}: {pair.Value}\n";
            }
            return output;
        }

        //THIRD

        private void Menu()
        {
            Print(quiz.QuizName);

            string[] options = { "Quiz", "Show all terms and definitions", "Search for term", "Exit" };
            for (int i = 0; i < options.Length; i++)
            {
                Print($" {i + 1}) {options[i]}");
            }

            Show("Enter an option: ");
            switch (ReadLine())
            {
                case "1":
                    StartQuiz(); // FOURTH
                    break;
                case "2":
                    Print(GetAllData()); // SECOND
                    break;
                case "3":
                    Print(TermSearch()); // FIFTH
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Print($"Please enter a number corresponding to an option in the list (1 to {options.Length}).");
                    break;
            }

            Pause();
            Menu(); // Recursive call
        }


        //FOURTH
        private void StartQuiz(int quizLength = 10)
        {
            if (quiz.TermsAndDefinitions.Count == 0)
            {
                Print("No data available to start the quiz.");
                return;
            }

            Random random = new Random();
            List<string> keys = quiz.TermsAndDefinitions.Keys.ToList();

            for (int i = 0; i < Math.Min(quizLength, keys.Count); i++)
            {
                string term = keys[random.Next(keys.Count)];
                Show($"What is the definition of '{term}'? ");
                string answer = ReadLine();

                if (answer?.Trim().Equals(quiz.TermsAndDefinitions[term], StringComparison.OrdinalIgnoreCase) == true)
                {
                    Print("Correct!");
                }
                else
                {
                    Print($"Wrong! The correct definition is: {quiz.TermsAndDefinitions[term]}");
                }
            }
        }

        private void Print(string output) => WriteLine($"{output}");
        private void Show(string output) => Write($"{output}");
        private void Pause()
        {
            Print("Press any key to continue...");
            ReadKey();
            Clear();
        }


        private void Print(string output) => WriteLine($"{output}");
        private void Show(string output) => Write($"{output}");
        private void Pause()
        {
            Print("Press any key to continue...");
            ReadKey();
            Clear();
        }
        private string TermSearch()
        {
            Show("Enter a term to search for: ");
            return Find(ReadLine());
        }
        private string Find(string itemName)
        {
            //TODO: make the itemName the same case as what is stored in the dictionary
            //so the player doesn't have to type in a word in the same case
            if (quiz.TermsAndDefinitions.ContainsKey(itemName))
            {
                return quiz.TermsAndDefinitions[itemName];
            }
            return $"Sorry, {itemName} was not found.";
        }
        //FIFTH
        //complete the functionality items that aren't included in this framework
    }
}
