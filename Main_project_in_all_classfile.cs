using average_in_one_project;
using random;
using stream_in_all_in_one_project;
using System;
class Program
{
    static void Main()
    {
        RandomNumberGenerator rng = new RandomNumberGenerator();
        GradeManager manager = new GradeManager();
        FileManager fileManager = new FileManager();





        bool menu = true;
        string Menu = "";
         while(menu)
        {
            Console.WriteLine("\n======== MENU ========");
            Console.WriteLine("|1. Generate random number|");
            Console.WriteLine("|2. Input grade of average|");
            Console.WriteLine("|3. streamwriter and list |");
            Console.WriteLine("|4.Exit                   |");
            Console.Write("|Choose: ");
            Menu = Console.ReadLine();
           
            
            if(Menu == "")
            { Console.WriteLine("Invalid input try again"); }
            switch (Menu)
            {
                case "1":
                    rng.Generate();
                    break;

                case "2":
                    manager.InputGrades();
                    break;

                case "3":
                    fileManager.ShowMenu();
                    break;

                case "4":
                    menu = false;
                    return;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;

            }



        }    
    }


}