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
            //Complete this one first
            //the menu options won't work until you put the data 
            //into the quiz.TermsAndDefinitions dictionary

            //example
            string[] contents;
            contents = GetDataFromTextFile("../../../data/data.txt");
            //save data read in to the contents string array
            //to the quiz.TermsAndDefinitions dictionary structure
            //using Key-Value pairs for the
            //terms and definitions

        }
        private string[] GetDataFromTextFile(string path) => File.ReadAllLines(path);


        //SECOND    
        private string GetAllData()
        {
            string output = "Abstract Class\r\nA class that cannot be instantiated.\r\nContainment\r\nIndicates a whole-part relationship and are known as \"has-a\" relationships. Also known as aggregation.\r\nAlgorithm\r\nA procedure that can take input. Through computational steps the input is transformed into output.\r\nArray\r\nA fixed data structure that can hold a collection of elements (identified by index position).\r\nAssociation\r\nA generic relationship between two classes.\r\nBase 10\r\nA numeral system with 10 values (0-9).\r\nBase 2\r\nA numeral system with symbols that represent two values.\r\nBinary\r\nRelating to, or using, the base-2 numeral system (values are expressed with only two symbols: 0 and 1).\r\nBit\r\nA single binary number.\r\nBoolean\r\nA data type with a binary value (such as: true or false, 1 or 0, or on and off).\r\nByte\r\nEight bits (8 bits can hold one of 256 values (from 0-255).\r\nCharacter\r\nA data type that stores a single character, and in C# is surrounded by single quote marks: 'c'.\r\nClass\r\nA template of a type of object.\r\nClass Diagram\r\nUsed to design or model the class structure in a system, including properties and methods.\r\nCode Block\r\nA statement or statements enclosed in curly braces {}. It can contain nested blocks.\r\nCompiler\r\nProduces executable (.exe) files. (It can also create dynamic-link libraries or code modules).\r\nConcatenation\r\nThe operation of joining two things together; in c# it adds two strings together with an operator.\r\nDependency\r\nAn object that another object relies on (for example, a member variable or parameter).\r\nEncapsulation\r\nRelated members are treated as a single unit; external behavior is separate from internal implementation details.\r\nFunction\r\nA series of statements that perform a logical operation or set of operations. \r\nGeneralization\r\nThe equivalent of an inheritance relationship in object-oriented terms (an \"is-a\" relationship).\r\nIDE\r\nSoftware that allows you to write, compile, and debug as you develop applications.\r\nIdentifier\r\nNames programmers choose (such as for classes, methods, and variables).\r\nInstance\r\nA specific object instantiated from a class.\r\nLiteral\r\nA primitive piece of data.\r\nObject\r\nAn instance of a class.\r\nPolymorphism\r\nMultiple classes used interchangeably; each class implements the same properties or methods in different ways.\r\nPseudocode\r\nA set of instructions in plain English. It does not use any language-specific syntax and is easily understood.\r\nRecursion\r\nSomething defined in terms of itself (or its type); in code, a structure that calls itself can have this.\r\nTernary Operator\r\nAn operator that works on three operands. ";
            //add code here to add 
            //all keys and values
            //from the Terms dictionary
            //to the string output
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
