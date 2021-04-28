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
        static void CheckChoiceInt(ref string str)
        {
            bool isWrongSymb = CheckWrongSymbInt(str);
            bool isEmpty = CheckStringEmpt(ref str);
            bool isNegative = CheckNotNegative(str, isEmpty);
            bool isWrongGender = CheckWrongChoice(str, isWrongSymb, isEmpty);
            while ((isEmpty != false) || (isWrongSymb != false)
                    || (isNegative != false) || (isWrongGender != false))
            {
                Console.WriteLine("Повторите ввод");
                str = Console.ReadLine();
                isWrongSymb = CheckWrongSymbInt(str);
                isEmpty = CheckStringEmpt(ref str);
                isNegative = CheckNotNegative(str, isEmpty);
                isWrongGender = CheckWrongChoice(str, isWrongSymb, isEmpty);
            }
        }

        static bool CheckWrongChoice(string str, bool isWrongSymb, bool isEmpty)
        {
            bool isWrongGender = false;
            if (isWrongSymb == false && isEmpty == false)
            {
                if (Enum.IsDefined(typeof(Choice), int.Parse(str)))
                {

                }
                else
                {
                    Console.WriteLine("Ошибка! Были введены неверные числа для выбора действия");
                    isWrongGender = true;
                }
            }
            return isWrongGender;
        }

        static bool CheckWrongGender(string str, bool isWrongSymb, bool isEmpty)
        {
            bool isWrongGender = false;
            if (isWrongSymb == false && isEmpty == false)
            {
                if (Enum.IsDefined(typeof(Gender), int.Parse(str)))
                {

                }
                else
                {
                    Console.WriteLine("Ошибка! Были введены неверные числа для инициализации пола");
                    isWrongGender = true;
                }
            }
            return isWrongGender;
        }

        static void CheckGenderInt(ref string str)
        {
            bool isWrongSymb = CheckWrongSymbInt(str);
            bool isEmpty = CheckStringEmpt(ref str);
            bool isNegative = CheckPositive(str, isEmpty);
            bool isWrongGender = CheckWrongGender(str, isWrongSymb, isEmpty);
            while ((isEmpty != false) || (isWrongSymb != false)
                    || (isNegative != false) || (isWrongGender != false))
            {
                Console.WriteLine("Повторите ввод");
                str = Console.ReadLine();
                isWrongSymb = CheckWrongSymbInt(str);
                isEmpty = CheckStringEmpt(ref str);
                isNegative = CheckPositive(str, isEmpty);
                isWrongGender = CheckWrongGender(str, isWrongSymb, isEmpty);
            }
        }

        static void CheckString(ref string str)
        {
            bool isWrongSymb = CheckWrongSymb(str);
            bool isEmpty = CheckStringEmpt(ref str);
            while ((isEmpty != false) || (isWrongSymb != false))
            {
                Console.WriteLine("Повторите ввод");
                str = Console.ReadLine();
                isWrongSymb = CheckWrongSymb(str);
                isEmpty = CheckStringEmpt(ref str);
            }
        }

        static bool CheckStringEmpt(ref string str)
        {
            bool isEmpty = false;
            str = str.Trim();
            if (str.Length == 0)
            {
                Console.WriteLine("Ошибка! Символы не были введены.");
                isEmpty = true;
            }
            else if (str.Length != 0)
            {
                isEmpty = false;
            }
            return isEmpty;
        }

        static bool CheckWrongSymb(string str)
        {
            bool isWrongSymb = false;
            string strUp = str.ToUpper(), strLow = str.ToLower();
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] == strLow[i]) && (str[i] == strUp[i]) && (str[i] != ' '))
                {
                    isWrongSymb = true;
                    Console.WriteLine("Ошибка! Были введены недопустимые символы");
                    break;
                }
            }
            return isWrongSymb;
        }

        static bool CheckNotNegative(string str, bool isEmpty)
        {
            bool isNegative = false;
            if (isEmpty == false)
            {
                if (str[0] == '-')
                {
                    Console.WriteLine("Ошибка!Было введено отрицательное число или ноль");
                    isNegative = true;
                }
            }
            return isNegative;
        }

        static bool CheckPositive(string str, bool isEmpty)
        {
            bool isNegative = false;
            if (isEmpty == false)
            {
                if (str[0] == '-' || str[0] == '0')
                {
                    Console.WriteLine("Ошибка!Было введено отрицательное число или ноль");
                    isNegative = true;
                }
            }
            return isNegative;
        }

        static void CheckPositiveInt(ref string str)
        {
            bool isWrongSymb = CheckWrongSymbInt(str);
            bool isEmpty = CheckStringEmpt(ref str);
            bool isNegative = CheckPositive(str, isEmpty);
            while ((isEmpty != false) || (isWrongSymb != false)
                    || (isNegative != false))
            {
                Console.WriteLine("Повторите ввод");
                str = Console.ReadLine();
                isWrongSymb = CheckWrongSymbInt(str);
                isEmpty = CheckStringEmpt(ref str);
                isNegative = CheckPositive(str, isEmpty);
            }
        }

        static bool CheckWrongSymbInt(string str)
        {
            bool isWrongSymb = false;
            Regex regExp = new Regex(@"[0-9]");
            MatchCollection match = regExp.Matches(str);
            if (match.Count != str.Length)
            {
                Console.WriteLine("Ошибка были введены недопустимые символы");
                isWrongSymb = true;
            }
            return isWrongSymb;
        }

        static Human HumanInitialization()
        {
            Console.WriteLine("Введите имя человека");
            string name = Console.ReadLine();
            CheckString(ref name);
            Console.WriteLine("Введите фамилию человека");
            string lastName = Console.ReadLine();
            CheckString(ref lastName);
            Console.WriteLine("Введите отчество человека");
            string patronymic = Console.ReadLine();
            CheckString(ref patronymic);
            Console.WriteLine("Введите возраст человека");
            string ageStr = Console.ReadLine();
            CheckPositiveInt(ref ageStr);
            int age = int.Parse(ageStr);
            Console.WriteLine("Введите вес человека");
            string weightStr = Console.ReadLine();
            CheckPositiveInt(ref weightStr);
            int weight = int.Parse(weightStr);
            Console.WriteLine("Введите рост человека");
            string growthStr = Console.ReadLine();
            CheckPositiveInt(ref growthStr);
            int growth = int.Parse(growthStr);
            Console.WriteLine("Введите хобби человека");
            string hobby = Console.ReadLine();
            CheckString(ref hobby);
            Console.WriteLine("Введите пол человека(1 - мужской, 2 - женский)");
            string genderStr = Console.ReadLine();
            CheckGenderInt(ref genderStr);
            int gender = int.Parse(genderStr);
            Human human = new Human(name, lastName, patronymic, age, weight, growth,
                                    hobby, gender);
            return human;
        }

        static Programmer ProgrammerInitialization()
        {
            Console.WriteLine("Введите имя человека");
            string name = Console.ReadLine();
            CheckString(ref name);
            Console.WriteLine("Введите фамилию человека");
            string lastName = Console.ReadLine();
            CheckString(ref lastName);
            Console.WriteLine("Введите отчество человека");
            string patronymic = Console.ReadLine();
            CheckString(ref patronymic);
            Console.WriteLine("Введите возраст человека");
            string ageStr = Console.ReadLine();
            CheckPositiveInt(ref ageStr);
            int age = int.Parse(ageStr);
            Console.WriteLine("Введите вес человека");
            string weightStr = Console.ReadLine();
            CheckPositiveInt(ref weightStr);
            int weight = int.Parse(weightStr);
            Console.WriteLine("Введите рост человека");
            string growthStr = Console.ReadLine();
            CheckPositiveInt(ref growthStr);
            int growth = int.Parse(growthStr);
            Console.WriteLine("Введите хобби человека");
            string hobby = Console.ReadLine();
            CheckString(ref hobby);
            Console.WriteLine("Введите пол человека(1 - мужской, 2 - женский)");
            string genderStr = Console.ReadLine();
            CheckGenderInt(ref genderStr);
            int gender = int.Parse(genderStr);
            Console.WriteLine("Введите зарплату");
            string salaryStr = Console.ReadLine();
            CheckPositiveInt(ref salaryStr);
            int salary = int.Parse(salaryStr);
            Console.WriteLine("Введите место работы");
            string placeOfWork = Console.ReadLine();
            CheckString(ref placeOfWork);
            Console.WriteLine("Введите свою должность");
            string position = Console.ReadLine();
            CheckString(ref position);
            Console.WriteLine("Введите свой любимый язык программирования ");
            string favouriteProgrammingLang = Console.ReadLine();
            CheckString(ref favouriteProgrammingLang);
            Programmer programmer = new Programmer(name, lastName, patronymic, age, weight, growth,
                                                   hobby, gender, salary, placeOfWork, position,
                                                   favouriteProgrammingLang);
            return programmer;
        }

        static Doctor DoctorInitialization()
        {
            Console.WriteLine("Введите имя человека");
            string name = Console.ReadLine();
            CheckString(ref name);
            Console.WriteLine("Введите фамилию человека");
            string lastName = Console.ReadLine();
            CheckString(ref lastName);
            Console.WriteLine("Введите отчество человека");
            string patronymic = Console.ReadLine();
            CheckString(ref patronymic);
            Console.WriteLine("Введите возраст человека");
            string ageStr = Console.ReadLine();
            CheckPositiveInt(ref ageStr);
            int age = int.Parse(ageStr);
            Console.WriteLine("Введите вес человека");
            string weightStr = Console.ReadLine();
            CheckPositiveInt(ref weightStr);
            int weight = int.Parse(weightStr);
            Console.WriteLine("Введите рост человека");
            string growthStr = Console.ReadLine();
            CheckPositiveInt(ref growthStr);
            int growth = int.Parse(growthStr);
            Console.WriteLine("Введите хобби человека");
            string hobby = Console.ReadLine();
            CheckString(ref hobby);
            Console.WriteLine("Введите пол человека(1 - мужской, 2 - женский)");
            string genderStr = Console.ReadLine();
            CheckGenderInt(ref genderStr);
            int gender = int.Parse(genderStr);
            Console.WriteLine("Введите зарплату");
            string salaryStr = Console.ReadLine();
            CheckPositiveInt(ref salaryStr);
            int salary = int.Parse(salaryStr);
            Console.WriteLine("Введите место работы");
            string placeOfWork = Console.ReadLine();
            CheckString(ref placeOfWork);
            Console.WriteLine("Введите свою должность");
            string position = Console.ReadLine();
            CheckString(ref position);
            Console.WriteLine("Введите свою медицинскую специальность");
            string medicalSpeciality = Console.ReadLine();
            CheckString(ref medicalSpeciality);
            Doctor doctor = new Doctor(name, lastName, patronymic, age, weight, growth,
                                                   hobby, gender, salary, placeOfWork, position,
                                                   medicalSpeciality);
            return doctor;
        }

        static Architect ArchitectInitialization()
        {
            Console.WriteLine("Введите имя человека");
            string name = Console.ReadLine();
            CheckString(ref name);
            Console.WriteLine("Введите фамилию человека");
            string lastName = Console.ReadLine();
            CheckString(ref lastName);
            Console.WriteLine("Введите отчество человека");
            string patronymic = Console.ReadLine();
            CheckString(ref patronymic);
            Console.WriteLine("Введите возраст человека");
            string ageStr = Console.ReadLine();
            CheckPositiveInt(ref ageStr);
            int age = int.Parse(ageStr);
            Console.WriteLine("Введите вес человека");
            string weightStr = Console.ReadLine();
            CheckPositiveInt(ref weightStr);
            int weight = int.Parse(weightStr);
            Console.WriteLine("Введите рост человека");
            string growthStr = Console.ReadLine();
            CheckPositiveInt(ref growthStr);
            int growth = int.Parse(growthStr);
            Console.WriteLine("Введите хобби человека");
            string hobby = Console.ReadLine();
            CheckString(ref hobby);
            Console.WriteLine("Введите пол человека(1 - мужской, 2 - женский)");
            string genderStr = Console.ReadLine();
            CheckGenderInt(ref genderStr);
            int gender = int.Parse(genderStr);
            Console.WriteLine("Введите зарплату");
            string salaryStr = Console.ReadLine();
            CheckPositiveInt(ref salaryStr);
            int salary = int.Parse(salaryStr);
            Console.WriteLine("Введите место работы");
            string placeOfWork = Console.ReadLine();
            CheckString(ref placeOfWork);
            Console.WriteLine("Введите свою должность");
            string position = Console.ReadLine();
            CheckString(ref position);
            Console.WriteLine("Введите свою архитектурную специальность");
            string architectSpeciality = Console.ReadLine();
            CheckString(ref architectSpeciality);
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
            CheckPositiveInt(ref selectionStr);
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
            CheckChoiceInt(ref choiceStr);
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