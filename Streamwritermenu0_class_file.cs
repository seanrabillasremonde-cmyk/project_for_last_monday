using Data2;


namespace stream_in_all_in_one_project
{
       public class FileManager
    {
        private List<Product> products = new List<Product>();
        private string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private string fileName = "";
        private string fullPath = "";

        public void ShowMenu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n======== MENU ========");
                Console.WriteLine("|1. Enter File Name     |");
                Console.WriteLine("|2. Enter Text and Save |");
                Console.WriteLine("|3. Display File Content|");
                Console.WriteLine("|4. Exit                |");
                Console.Write("|Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateFile();
                        break;

                    case "2":
                        SaveProduct();
                        break;

                    case "3":
                        DisplayFile();
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Exiting File Manager...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void CreateFile()
        {
            Console.Write("Enter filename: ");
            fileName = Console.ReadLine() + ".txt";
            fullPath = Path.Combine(desktop, fileName);
            Console.WriteLine("File created! Check your desktop.");
        }

        private void SaveProduct()
        {
            if (string.IsNullOrEmpty(fullPath))
            {
                Console.WriteLine("Please create/select a file first!");
                return;
            }

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Grade: ");
            if (!int.TryParse(Console.ReadLine(), out int grade) || grade < 50 || grade > 100)
            {
                Console.WriteLine("Invalid grade entered! Must be 50-100.");
                return;
            }

            Product p = new Product
            {
                Name = name,
                Grade = grade,
                CreatedDate = DateTime.Now
            };

            products.Clear();
            products.Add(p);

            using (StreamWriter writer = new StreamWriter(fullPath, true))
            {
                foreach (var product in products)
                {
                    writer.Write($"\n|Name:{product.Name}    |\n" +
                                 $"|Grade:{product.Grade}  |\n" +
                                 $"|CreatedDate:{product.CreatedDate.ToShortDateString()}|\n");
                }
            }

            Console.WriteLine("Saved successfully!");
        }

        private void DisplayFile()
        {
            if (string.IsNullOrEmpty(fullPath))
            {
                Console.WriteLine("Please create/select a file first!");
                return;
            }

            if (File.Exists(fullPath))
            {
                Console.WriteLine(File.ReadAllText(fullPath));
            }
            else
            {
                Console.WriteLine("File does not exist yet.");
            }
        }
    } 
}