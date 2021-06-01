using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

enum AgeCategory
{
    Baby,
    Child,
    Teenager,
    Adult,
    Elderly
}


enum Gender
{
    Male = 1,
    Female = 2
}

enum BodyMassIndexGroup
{
    BelowNormal,
    Normal,
    AboveNormal
}

enum Choice
{
    Nothing,
    Human,
    Programmer,
    Architect,
    Doctor
}

namespace LAB5
{
    class Program
    {

        static Human HumanInitialization()
        {
            Console.WriteLine("Введите имя человека");
            string name = Console.ReadLine();
            Checker.Check(ref name, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите фамилию человека");
            string lastName = Console.ReadLine();
            Checker.Check(ref lastName, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите отчество человека");
            string patronymic = Console.ReadLine();
            Checker.Check(ref patronymic, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите возраст человека");
            string ageStr = Console.ReadLine();
            Checker.Check(ref ageStr, Checker.ConfigCheckHandlerInt());
            int age = int.Parse(ageStr);
            Console.WriteLine("Введите вес человека");
            string weightStr = Console.ReadLine();
            Checker.Check(ref weightStr, Checker.ConfigCheckHandlerInt());
            int weight = int.Parse(weightStr);
            Console.WriteLine("Введите рост человека");
            string growthStr = Console.ReadLine();
            Checker.Check(ref growthStr, Checker.ConfigCheckHandlerInt());
            int growth = int.Parse(growthStr);
            Console.WriteLine("Введите хобби человека");
            string hobby = Console.ReadLine();
            Checker.Check(ref hobby, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите пол человека(1 - мужской, 2 - женский)");
            string genderStr = Console.ReadLine();
            Checker.Check(ref genderStr, Checker.ConfigCheckHandlerGender());
            int gender = int.Parse(genderStr);
            Human human = new Human(name, lastName, patronymic, age, weight, growth,
                                    hobby, gender);
            return human;
        }

        static Programmer ProgrammerInitialization()
        {
            Console.WriteLine("Введите имя человека");
            string name = Console.ReadLine();
            Checker.Check(ref name, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите фамилию человека");
            string lastName = Console.ReadLine();
            Checker.Check(ref lastName, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите отчество человека");
            string patronymic = Console.ReadLine();
            Checker.Check(ref patronymic, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите возраст человека");
            string ageStr = Console.ReadLine();
            Checker.Check(ref ageStr, Checker.ConfigCheckHandlerInt());
            int age = int.Parse(ageStr);
            Console.WriteLine("Введите вес человека");
            string weightStr = Console.ReadLine();
            Checker.Check(ref weightStr, Checker.ConfigCheckHandlerInt());
            int weight = int.Parse(weightStr);
            Console.WriteLine("Введите рост человека");
            string growthStr = Console.ReadLine();
            Checker.Check(ref growthStr, Checker.ConfigCheckHandlerInt());
            int growth = int.Parse(growthStr);
            Console.WriteLine("Введите хобби человека");
            string hobby = Console.ReadLine();
            Checker.Check(ref hobby, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите пол человека(1 - мужской, 2 - женский)");
            string genderStr = Console.ReadLine();
            Checker.Check(ref genderStr, Checker.ConfigCheckHandlerGender());
            int gender = int.Parse(genderStr);
            Console.WriteLine("Введите зарплату");
            string salaryStr = Console.ReadLine();
            Checker.Check(ref salaryStr, Checker.ConfigCheckHandlerInt());
            int salary = int.Parse(salaryStr);
            Console.WriteLine("Введите место работы");
            string placeOfWork = Console.ReadLine();
            Checker.Check(ref placeOfWork, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите свою должность");
            string position = Console.ReadLine();
            Checker.Check(ref position, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите свой любимый язык программирования ");
            string favouriteProgrammingLang = Console.ReadLine();
            Checker.Check(ref favouriteProgrammingLang, Checker.ConfigCheckHandlerStr());
            Programmer programmer = new Programmer(name, lastName, patronymic, age, weight, growth,
                                                   hobby, gender, salary, placeOfWork, position,
                                                   favouriteProgrammingLang);
            return programmer;
        }

        static Doctor DoctorInitialization()
        {
            Console.WriteLine("Введите имя человека");
            string name = Console.ReadLine();
            Checker.Check(ref name, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите фамилию человека");
            string lastName = Console.ReadLine();
            Checker.Check(ref lastName, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите отчество человека");
            string patronymic = Console.ReadLine();
            Checker.Check(ref patronymic, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите возраст человека");
            string ageStr = Console.ReadLine();
            Checker.Check(ref ageStr, Checker.ConfigCheckHandlerInt());
            int age = int.Parse(ageStr);
            Console.WriteLine("Введите вес человека");
            string weightStr = Console.ReadLine();
            Checker.Check(ref weightStr, Checker.ConfigCheckHandlerInt());
            int weight = int.Parse(weightStr);
            Console.WriteLine("Введите рост человека");
            string growthStr = Console.ReadLine();
            Checker.Check(ref growthStr, Checker.ConfigCheckHandlerInt());
            int growth = int.Parse(growthStr);
            Console.WriteLine("Введите хобби человека");
            string hobby = Console.ReadLine();
            Checker.Check(ref hobby, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите пол человека(1 - мужской, 2 - женский)");
            string genderStr = Console.ReadLine();
            Checker.Check(ref genderStr, Checker.ConfigCheckHandlerGender());
            int gender = int.Parse(genderStr);
            Console.WriteLine("Введите зарплату");
            string salaryStr = Console.ReadLine();
            Checker.Check(ref salaryStr, Checker.ConfigCheckHandlerInt());
            int salary = int.Parse(salaryStr);
            Console.WriteLine("Введите место работы");
            string placeOfWork = Console.ReadLine();
            Checker.Check(ref placeOfWork, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите свою должность");
            string position = Console.ReadLine();
            Checker.Check(ref position, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите свою медицинскую специальность");
            string medicalSpeciality = Console.ReadLine();
            Checker.Check(ref medicalSpeciality, Checker.ConfigCheckHandlerStr());
            Doctor doctor = new Doctor(name, lastName, patronymic, age, weight, growth,
                                                   hobby, gender, salary, placeOfWork, position,
                                                   medicalSpeciality);
            return doctor;
        }

        static Architect ArchitectInitialization()
        {
            Console.WriteLine("Введите имя человека");
            string name = Console.ReadLine();
            Checker.Check(ref name, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите фамилию человека");
            string lastName = Console.ReadLine();
            Checker.Check(ref lastName, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите отчество человека");
            string patronymic = Console.ReadLine();
            Checker.Check(ref patronymic, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите возраст человека");
            string ageStr = Console.ReadLine();
            Checker.Check(ref ageStr, Checker.ConfigCheckHandlerInt());
            int age = int.Parse(ageStr);
            Console.WriteLine("Введите вес человека");
            string weightStr = Console.ReadLine();
            Checker.Check(ref weightStr, Checker.ConfigCheckHandlerInt());
            int weight = int.Parse(weightStr);
            Console.WriteLine("Введите рост человека");
            string growthStr = Console.ReadLine();
            Checker.Check(ref growthStr, Checker.ConfigCheckHandlerInt());
            int growth = int.Parse(growthStr);
            Console.WriteLine("Введите хобби человека");
            string hobby = Console.ReadLine();
            Checker.Check(ref hobby, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите пол человека(1 - мужской, 2 - женский)");
            string genderStr = Console.ReadLine();
            Checker.Check(ref genderStr, Checker.ConfigCheckHandlerGender());
            int gender = int.Parse(genderStr);
            Console.WriteLine("Введите зарплату");
            string salaryStr = Console.ReadLine();
            Checker.Check(ref salaryStr, Checker.ConfigCheckHandlerInt());
            int salary = int.Parse(salaryStr);
            Console.WriteLine("Введите место работы");
            string placeOfWork = Console.ReadLine();
            Checker.Check(ref placeOfWork, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите свою должность");
            string position = Console.ReadLine();
            Checker.Check(ref position, Checker.ConfigCheckHandlerStr());
            Console.WriteLine("Введите свою архитектурную специальность");
            string architectSpeciality = Console.ReadLine();
            Checker.Check(ref architectSpeciality, Checker.ConfigCheckHandlerStr());
            Architect architect = new Architect(name, lastName, patronymic, age, weight, growth,
                                                   hobby, gender, salary, placeOfWork, position,
                                                   architectSpeciality);
            return architect;
        }

        static void WorkAndGetSalary(WorkingHuman workingHuman)
        {
            workingHuman.Work();
            workingHuman.GetSalary();
        }

        static void WorkingHumanInfo(WorkingHuman workingHuman)
        {
            workingHuman.WorkingHumanInfo();
        }

        static void WorkingHumanMethodsInvocation(WorkingHuman workingHuman)
        {
            workingHuman.WorkingHumanMethodsInvocation();
        }

        static void Push<T>(ref T[] arr, T value)
        {
            T[] newArray = new T[arr.Length + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                newArray[i] = arr[i];
            }

            newArray[arr.Length] = value;

            arr = newArray;
        }

        static void addHumanObject(ref Human[] arr)
        {
            Console.WriteLine("Хотите ввести ещё один объект класса?(1 - да, 2 - нет)");
            string selectionStr = Console.ReadLine();
            Checker.Check(ref selectionStr, Checker.ConfigCheckHandlerInt());
            int selection = int.Parse(selectionStr);
            if (selection == 1)
            {
                CreationChoice(ref arr);
            }
        }

        static void showHumanArray(ref Human[] arr)
        {
            Console.WriteLine("Массив людей: ");
            foreach (Human el in arr)
            {
                el.HumanInfo();
            }
        }

        static void CreationChoice(ref Human[] arr)
        {
            Console.Write("Введите объект класса, который хотите создать(0 - ничего, 1 - человек, " +
                          "2 - программист, 3 - архитектор, 4 - врач)\n");
            string choiceStr = Console.ReadLine();
            Checker.Check(ref choiceStr, Checker.ConfigCheckHandlerChoice());
            Choice choice = (Choice)int.Parse(choiceStr);
            switch (choice)
            { 
                case Choice.Human:
                    Console.WriteLine("Создание класса человека");
                    Human human = new Human();
                    human = HumanInitialization();
                    human.HumanInfo();
                    human.HumanMethodsInvocation();
                    Push(ref arr, human);
                    showHumanArray(ref arr);
                    addHumanObject(ref arr);
                    break;
                case Choice.Programmer:
                    Console.WriteLine("Создание класса программиста");
                    Programmer programmer = new Programmer();
                    programmer = ProgrammerInitialization();
                    WorkingHumanInfo(programmer);
                    WorkingHumanMethodsInvocation(programmer);
                    WorkAndGetSalary(programmer);
                    Push(ref arr, programmer);
                    showHumanArray(ref arr);
                    addHumanObject(ref arr);
                    break;
                case Choice.Architect:
                    Console.WriteLine("Создание класса архитектора");
                    Architect architect = new Architect();
                    architect = ArchitectInitialization();
                    WorkingHumanInfo(architect);
                    WorkingHumanMethodsInvocation(architect);
                    Push(ref arr, architect);
                    showHumanArray(ref arr);
                    addHumanObject(ref arr);
                    break;
                case Choice.Doctor:
                    Console.WriteLine("Создание класса врача");
                    Doctor doctor = new Doctor();
                    doctor = DoctorInitialization();
                    WorkingHumanInfo(doctor);
                    WorkingHumanMethodsInvocation(doctor);
                    Push(ref arr, doctor);
                    showHumanArray(ref arr);
                    addHumanObject(ref arr);
                    break;
                default:
                    break;
            }
             
        }

        static void Main(string[] args)
        {
            Human[] humans = new Human[0];
            CreationChoice(ref humans);
            if (humans.Length != 0)
            {
                Console.WriteLine("\nМассив людей, отсортированный по возрасту");
                Array.Sort(humans, new HumanComparer());
                foreach (Human el in humans)
                {
                    el.HumanInfo();       
                }
            }
            
            Console.ReadKey();
        }
    }
}