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

            //simple menu structure with an array of options and a switch
            string[] options = { "Quiz", "Show all terms and definitions", "Search for term", "Exit" };
            for (int i = 0; i < options.Length; i++)
            {
                Print($"  {i + 1}) {options[i]}");
            }

            Show("Enter an option: ");
            switch (ReadLine())
            {
                case "1":
                    //  Quiz on the terms and definitions
                    StartQuiz();
                    break;
                case "2":
                    // View all terms and definitions
                    Print(GetAllData());
                    break;
                case "3":
                    //  Search the terms and definitions
                    Print(TermSearch());
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Print($"Please enter a number corresponding to an option in the list (1 to {options.Length}).");
                    break;
            }

            Pause();

            //recursive call to Menu
            Menu();
        }


        //FOURTH
        private void StartQuiz(int quizLength = 10) //default can be set as parameter
        {

            //add code here 
            //show dictionary data as quiz
            //for (int i=0; i< quizLength; i++) {//add additional code here}

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
