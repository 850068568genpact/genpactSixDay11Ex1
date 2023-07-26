using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace Day11Ex01
{
    internal class Program
    {
        static string fpath;
        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.Create();
            string choice = "";
            Console.WriteLine("Choose from following Options :");
            do
            {
                Console.WriteLine("1. Write 2. Read");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1: WriteMethod(); break;
                    case 2: ReadMethod(); break;
                }
                Console.WriteLine("Enter y to continue");
                choice = Console.ReadLine();
            } while (choice == "y");
            Console.ReadKey();
        }
        public void Create()
        {
            string path = "C:\\DotnetTraining\\Day11\\Customers";
            Console.WriteLine("Enter Customer Name :");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Customer DOB :");
            string dob = Console.ReadLine();
            fpath = path + "\\" + name + "_" + dob + ".docx";
            if (!File.Exists(path))
            {
                Console.WriteLine("Error!!! File already exists");
            }
            else
                File.Create(fpath).Close();
        }
        public static void WriteMethod()
        {
            Person person = new Person();
            Console.WriteLine("Enter Customer Details - ID, City, Address");
            Console.WriteLine("Enter Customer ID");
            person.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Customer Name");
            person.CName = Console.ReadLine();
            Console.WriteLine("Enter Customer City");
            person.CCity = Console.ReadLine();
            Console.WriteLine("Enter Customer Address");
            person.CAddress = Console.ReadLine();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fpath, FileMode.OpenOrCreate, FileAccess.Write);
            formatter.Serialize(stream, person);
            Console.WriteLine("Written Inside File");
            stream.Close();
        }
        public static void ReadMethod()
        {
            Console.WriteLine("***Deserialized Information***");
            Stream stream1 = new FileStream(fpath, FileMode.Open, FileAccess.Read);
            IFormatter formatter = new BinaryFormatter();
            Person myPerson = (Person)(formatter.Deserialize(stream1));
            Console.WriteLine("Customer ID :" + myPerson.Id);
            Console.WriteLine("Customer Name :" + myPerson.CName);
            Console.WriteLine("Customer City :" + myPerson.CCity);
            Console.WriteLine("Customer Address :" + myPerson.CAddress);
        }
    }
}