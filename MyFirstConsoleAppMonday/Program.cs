using System.Diagnostics.Metrics;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Models;
using Repository;
using Services;


namespace MyFirstConsoleAppMonday
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepository _employeeRepository = new EmployeeRepository();
            AddressServices _addressServices = new AddressServices();
            EmployeeServices _employeeServices = new EmployeeServices();

            //// Criar um novo funcionário
            //Address address = new Address();
            //string createMessage = _employeeServices.CreateNewEmployee("John", "Francis", "Smith", new DateTime(1990, 1, 1), "john@example.com", true, 2, 123456, 654321, "Developer", "Develops software", "Jane Doe", address);
            //Console.WriteLine(createMessage);

            // Atualizar o funcionário
            //string updateMessage = _employeeServices.UpdateEmployeeById(10, "Carlos", "Francisco", "Gonzaga", new DateTime(1989, 7, 14), "carlosgonzaga@Outlook.com", true, 2, 123456789, 987654321, "Junior Developer", "Develops basics software", "Jane Doe", address);
            //Console.WriteLine(updateMessage);

            // Deletar o funcionário
            //string deleteMessage = _employeeServices.DeleteEmployeeById(11);
            //Console.WriteLine(deleteMessage);

            // Criar nova Morada
            //Address address = new Address("Elias Garcia", "", 8, "Almada", "2800-010", "Setúbal", "Almada");
            //Address address2 = _addressServices.CreateNewAddress(address);

            //Expects a number from 0 to 5
            // Into an int32 variable type at the end
            // Values comes from a user input
            //bool valid = false;
            /*
            do {
                int userInput = -1; // Reset,

                //int? n = null;
                //bool converted = int.TryParse(Console.ReadLine(), out userInput);

                try
                {
                    Console.WriteLine("Please provide a number from 0 to 5");
                    userInput = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex) {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally {
                    if (userInput != -1)
                    {
                        if (userInput >= 0 && userInput <= 5)
                        {
                            valid = true;
                            Console.WriteLine("The inserted number was " + userInput.ToString());
                        }
                        else
                            Console.WriteLine("The number must be between 0 and 5");
                    }
                    else
                        Console.WriteLine("Your input was invalid. Please provide another");

                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (!valid);
            */

            //EmployeeServices employeeServices = new EmployeeServices();
            //List<Employee> employees = employeeServices.GetAllEmployee();
            //Employee emp = _employeeServices.GerarDadosFakeCSharp();
            Employee employee = _employeeServices.GetEmployeeById(01);
            //Console.ReadLine();

            #region

            ////EmployeeServices employeeServices = new EmployeeServices();
            ////ClientServices clientServices = new ClientServices();
            ////string[] arrayString = new string[9];
            ///*string[,] arrayString2 = new string[3, 3]
            //{
            //    { "col 1, row 1", "col 2, row 1", "col 3, row 1" },
            //    { "col 1, row 2", "col 2, row 2", "col 3, row 2" },
            //    { "col 1, row 3", "col 2, row 3", "col 3, row 3" },
            //};*/


            ///*
            //Console.Write("Input a number: ");
            //int number = Convert.ToInt32(Console.ReadLine());
            //string resultTable = GenerateTableFromNumber(number);
            //Console.WriteLine(resultTable);

            ////number = 154;
            ////resultTable = GenerateTableFromNumber(number);
            ////Console.WriteLine(resultTable);

            //int n1 = 3;
            //int n2 = 4;

            //int n = AddNumber(n1, n2);

            //string name = SetFullName("João", "Almeida", "Pedro");
            //string name2 = SetFullName("João", "Almeida");

            //StringBuilder stringBuilder = new StringBuilder();

            //int counter = 1;
            //do
            //{
            //    int result = number * counter;
            //    string line = $"{number} x {counter} = {result}";
            //    stringBuilder.AppendLine(line);
            //    counter++;
            //}
            //while (counter <= 10);
            //Console.WriteLine(stringBuilder.ToString());

            //stringBuilder = new StringBuilder();

            //int counter2 = 1;
            //while (counter2 <= 10)
            //{
            //    int result = number * counter2;
            //    string line = $"{number} x {counter2} = {result}";
            //    stringBuilder.AppendLine(line);
            //    counter2++;
            //}

            //Console.WriteLine(stringBuilder.ToString());
            //*/

            ///*    
            //   ___**
            //   __****
            //   _******
            //   ********

            //L  E  A  I
            //1  3  2  4
            //2  2  4  4
            //3  1  6  4
            //4  0  8  4
            //      */
            ///* Tree examples
            //string output = "";
            //for (int i = 1; i <= number; i++)
            //{
            //    Console.WriteLine(output += "*");
            //}

            //for (int i = 1;i <= number; i++)
            //{
            //    for (int j = 1; j <= number-i; j++)
            //    {
            //        Console.Write(" ");
            //    }

            //    for (int j = 1;j <= i; j++)
            //    {
            //        Console.Write("**");
            //    }
            //    Console.WriteLine("");
            //}
            //*/

            ////Console.WriteLine("Hello, World!");
            ///*
            //Person person = new Person();
            //Person person2 = new Person();

            //person.FirstName = "Test";
            //person.LastName = "Test Last";

            //Console.Read();

            //int currentYear = DateTime.Now.Year;
            //DateTime birthdate = Convert.ToDateTime(Console.ReadLine());
            //int age = currentYear - birthdate.Year;

            //string s = Console.ReadLine();

            //string s1 = "10";
            //string s2 = "10";
            //string s3 = s1 + s2;
            //int n1 = 10;
            //int n2 = 20;
            //int n31 = n1 + n2;
            //int n32 = n1 - n2;
            //int n33 = n1 * n2;
            //int n34 = n1 / n2;
            //double n35 = Convert.ToDouble(n1) / Convert.ToDouble(n2);

            //int x = 1;
            //int y = ++x;
            //int z = x++;

            //double n4 = (double)n1;
            //double n5 = Convert.ToDouble(n1);
            //double n6 = double.Parse(s1);

            //double n7 = 10.25 + n4 + n5 + (n6 * 2);
            //string s7 = n7.ToString();

            //int n8 = Convert.ToInt32(Console.ReadLine());
            //*/
            ///*
            //Pixel pixel = new Pixel();
            //pixel.blue = 12;
            //pixel.red = 132;
            //pixel.green = 0;

            //StringBuilder sb = new StringBuilder(); // empty with default capacity 16
            //for (int i = 0; i < 25; i++)
            //{
            //    string str = $"Current position {i} of 25\n";
            //    sb.Append(str);
            //}

            //Console.WriteLine(sb.ToString());

            //pixel.paint();
            //*/
            ///*
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.Beep(); Console.Beep();
            //Console.Beep(); Console.Beep();
            //Console.Beep(); Console.Beep();
            //Console.Write("My name is");
            //Console.WriteLine("João");
            //*/
            ///*
            //char c = 'd';
            //string temp = "Assembly";
            //char[] characters = {'B', 'a', 'z', 'i', 'n', 'g', 'a'};

            //string temp2 = new string(characters);
            //string temp3 = new string(characters, 3, (characters.Length - 3));
            //string temp4 = new string('$', 12);

            //temp4 = temp2.Substring(3, 2);

            //string temp5 = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            //string[] splitString = temp5.Split(' ');

            //char ch = temp2[3];
            //int n = temp.Length;

            //string helloWorld = "Hello \tworld\nWe are learning \"C#\"";
            //Console.WriteLine(helloWorld);
            //*/
            ////double n2 = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            ///*
            //string s1 = "Hello";
            //string s2 = "Hello world";
            //string s3 = s1 + " world";

            ////s2 == s3; // true
            //Object.ReferenceEquals(s2, s3); // false
            //Object.Equals(s1, s2); // true
            //s2.Equals(s3); // true
            //s1.CompareTo(s2); // -1
            //string s4 = null; ;
            //s1.CompareTo(s4); // -1

            //Random random = new Random();

            //int n1 = random.Next(100);
            //int n2 = random.Next(10, 20);
            //int n3 = random.Next(100);


            //Console.WriteLine("Please provide your age");
            //int age = Convert.ToInt32(Console.ReadLine());
            //string content;
            //if (age <= 18)
            //{
            //    Console.WriteLine("You are a child");
            //    content = "CLD";
            //}
            //else if (age <= 24)
            //{
            //    Console.WriteLine("You are a teenager");
            //    content = "JUN";
            //}
            //else if (age <= 65)
            //{
            //    Console.WriteLine("You are an adult");
            //    content = "ALD";
            //}
            //else if (age <= 101)
            //{
            //    Console.WriteLine("You are an senior");
            //    content = "SNR";
            //}
            //else
            //{
            //    Console.WriteLine("You are a mummy man");
            //    content = "MMM";
            //}

            //if (age <= 18 || age >= 65) // Child and senior our above
            //    Console.WriteLine("You have an available discount");
            //else 
            //    Console.WriteLine("You do not have a discount");

            //string text = (age <= 18 || age >= 65) ? "You have an available discount" : "You do not have a discount";
            //Console.WriteLine(text);

            //switch (content)
            //{
            //    case "CLD":
            //        Console.WriteLine("Switch for child code");
            //        break;
            //    case "JUN":
            //        Console.WriteLine("Switch for teenager code");
            //        break;
            //    case "ALD":
            //        Console.WriteLine("Switch for adult code");
            //        break;
            //    case "SNR":
            //    case "MMM":
            //        Console.WriteLine("Switch for senior or older code");
            //        break;
            //    default:
            //        Console.WriteLine("This is the default option");
            //        break;
            //}*/
            ///*
            //Console.WriteLine("How many cycle runs do you want?");
            //int limit = Convert.ToInt32(Console.ReadLine());
            //int counter = 0;
            //*/
            ///*while (counter < limit)
            //{
            //    //if (counter != 10)
            //    Console.WriteLine(counter);
            //    counter++;
            //}*/
            ///*
            //Random random = new Random();
            //string replay = "y";
            //while (replay == "y" && counter < limit)
            //{
            //    Console.WriteLine("Replaying cycle with counter " + counter++);

            //    int n1 = random.Next(100);
            //    Console.WriteLine("Random value is " + n1);

            //    if (counter == 5)
            //        continue;

            //    if (counter == 10)
            //        break;

            //    //counter++;

            //    //Console.WriteLine("Go again? (Y/N)");
            //    //replay = Console.ReadLine();
            //}

            //// reset current breacking condition values
            //counter = 0;
            //replay = "n";
            //do
            //{
            //    Console.WriteLine("Replaying cycle with counter " + counter++);
            //    Console.WriteLine("Go again? (Y/N)");
            //    replay = Console.ReadLine();
            //} while (replay == "y" && counter < limit);
            //*/
            //#region Cycles
            ///*
            //Console.WriteLine("Number of rows");
            //int rows = Convert.ToInt32(Console.ReadLine());

            //for (int i = 1; i <= rows; i++)
            //{
            //    for (int j = 1; j <= (rows - i); j++)
            //    {
            //        Console.Write(' ');
            //    }
            //    for (int j = 1; j <= i; j++)
            //    {
            //        Console.Write("**");
            //    }
            //    Console.WriteLine("");

            //}
            //*/
            #endregion
            /*
            //for (int i = 0; i < limit; i++)
            //{
            //    Console.WriteLine("Replaying cycle with counter " + i);
            //}

            //int[] array = new int[5] { 1, 2, 3, 4, 5 };
            //foreach (int n in array)
            //{
            //    if (n % 2 != 0)
            //        Console.WriteLine(n);
            //}
            //*/
            /*
            //Console.Write("Input a number: ");
            //int number = Convert.ToInt32(Console.ReadLine());

            //string[] listName = new string[number];
            //string[,] listName2 = new string[number, 2];
            //Random random = new Random();

            //for (int i = 0; i < listName.Length; i++)
            //{
            //    listName[i] = random.Next(100).ToString();
            //}

            //Array.Sort(listName);

            //Array.Reverse(listName, 1, number-1);

            //int[] array = new[] { 5, 2, 3, 1, 4, 5 };

            //Array.IndexOf(array, 5); // 0
            //Array.LastIndexOf(array, 5); // 5
            //Array.Sort(array); // 1, 2, 3, 4, 5, 5
            ////Array.Reverse(array, 5); // 5, 5, 4, 3, 2, 1

            //int[] array1 = new int[15]; // 0, 0, 0, 0, 0, 0
            //Array.Copy(array, array1, array.Length); // array1 = 5, 5, 4, 3, 2, 1
            //*/
            /*
            //DateTime birthDate = Convert.ToDateTime("1900-01-01");

            //DateTime dateTime1 = new DateTime(1980, 2, 3);

            //try
            //{
            //    string message1 = employeeServices.CreateNewEmployee("João", "Pedro", "Almeida", birthDate, true, 132456789, 1098765, "Tech developer", "Tech developer", "", "Rua da Assembly", "", 3, "Lisboa", "Lisboa", "Alvalade");
            //    string message2 = employeeServices.CreateNewEmployee("Filipe", "", "Coelho", birthDate, true, 222333444, 55566677, "Tech developer", "Tech developer", "", "Rua ao lado da Assembly", "Entre o contimente", 5, "Lisboa", "Lisboa", "Alvalade");
            //}
            //catch (Exception ex)
            //{
            //    string s = ex.Message;
            //}
            //*/
            ////Person person = new Person();
            ////List<Person> result = person.GetAllPersons();

            //#endregion
            //Person person = new Person();
            //Employee employee = (Employee)person;

            //DateTime birthdate = Convert.ToDateTime("1970-01-01");
            //Employee employee1 = new Employee("João", "Pedro", "Almeida", birthdate, "joao.almeida@assembly.pt", true, 123456789, 987654321, "João Rodrigues", "Developer", "Filipe Coelho", "Rua da Assembly", "", 3, "Lisboa", "Lisboa", "Alvalade");
            ////string clientMessage = clientServices.CreateNewClient("Mario", "José", "dos Santos", birthdate, "jose.santos@gmail.com", "Rua de Cabo Verde", "", 2, "Lisboa", "Belém", "Lisboa");
            string messangerError = "";

            //try
            //{
            //    Console.WriteLine("Please insert a number");
            //    int number = Convert.ToInt32(Console.ReadLine());
            //}
            //catch (NullReferenceException ex)
            //{

            //}
            //catch (Exception ex)
            //{
            //    string msg = ex.Message;
            //    Console.WriteLine("Number invalid!");

            //}
            //finally 
            //{
            //    if (messangerError != "")
            //    {
            //        Console.WriteLine("Erro generico");
            //    }
            //}

            //Console.WriteLine("Testing...");
            

            Console.ReadLine();
        }

        public enum Suits : short
        {
            Spades = 1,
            Hearts = 2,
            Clubs = 3,
            Diamonds = 4
        }

        public enum DaysOfWeek : short
        {
            Monday = 2,
            Tuesday = 3,
            Wendsday = 4,
            Thursday = 5,
            Friday = 6,
            Saturday = 7,
            Sunday = 1
        }

        public static string GenerateTableFromNumber(int inputValue)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 1; i <= 10; i++)
            {
                int result = inputValue * i;
                string line = $"{inputValue} x {i} = {result}";
                stringBuilder.AppendLine(line);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Method to generate the name based on the inputs.
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="middleName">Middle name (if existing)</param>
        /// <returns>Returns the users full name.</returns>

        public static int AddNumber(int number1, in int number2)
        {
            number1 = 10;
            //number2 = 99;
            return number1 + number2;
        }
        
        /*
        public static string SetFullName(string firstName, string lastName)
        {
            string fullName = firstName + " ";

            fullName += lastName;

            return fullName;
        }
        */
    }
}
