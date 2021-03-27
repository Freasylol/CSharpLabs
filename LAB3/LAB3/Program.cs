using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

class Human {
    ~Human() {
    }

    public Human() {
    
    }

    public Human(string name, string lastName, string patronymic, int age, int weight,
                 int growth, string hobby, int gender) {
        this["name"] = name;
        this["lastName"] = lastName;
        this["patronymic"] = patronymic;
        this["age"] = age;
        this["weight"] = weight;
        this["growth"] = growth;
        this["hobby"] = hobby;
        this["gender"] = gender;
        AssignAgeCategory();
        AssignBodyMassIndex();
        Console.WriteLine("Объект класса Human был проиницилизирован");
    }

    public dynamic this[string propName] {
        get {
            switch(propName) {
                case "name":
                    return name;
                    break;
                case "lastName":
                    return lastName;
                    break;
                case "patronymic":
                    return patronymic;
                    break;
                case "hobby":
                    return hobby;
                    break;
                case "age":
                    return age;
                    break;
                case "weight":
                    return weight;
                    break;
                case "growth":
                    return growth;
                    break;
                case "gender":
                    return gender;
                    break;
                default: 
                    return null;
            }
        }
        set {
            switch(propName) {
                case "name":
                    name = value;
                    break;
                case "lastName":
                    lastName = value;
                    break;
                case "patronymic":
                    patronymic = value;
                    break;
                case "hobby":
                    hobby = value;
                    break;
                case "age":
                    age = value;
                    break;
                case "weight":
                    weight = value;
                    break;
                case "growth":
                    growth = value;
                    break;
                case "gender":
                    gender = (Gender)value;
                    break;
                default:
                    break;
            }
        }
    }

    public void AssignBodyMassIndex() {
        if (growth != 0) {
            bodyMassIndex = weight / (growth * growth);
            if (bodyMassIndex > 18.5 && bodyMassIndex < 25) {
            bodyMassIndexGroup = BodyMassIndexGroup.Normal;
            } else if (bodyMassIndex < 18.5) {
            bodyMassIndexGroup = BodyMassIndexGroup.BelowNormal;
            } else {
            bodyMassIndexGroup = BodyMassIndexGroup.AboveNormal;
        }  
        }
        
            
    }

    public void AssignAgeCategory() {
        if (age <= 3 && age > 0) {
            ageCategory = AgeCategory.Baby;
        } else if (age > 3 && age <= 12) {
            ageCategory = AgeCategory.Child;
        } else if (age > 12 && age < 18) {
            ageCategory = AgeCategory.Teenager;
        } else if (age >= 18 && age < 60) {
            ageCategory = AgeCategory.Adult;
        } else if (age >= 60) {
            ageCategory = AgeCategory.Elderly;
        }
    }

    public void ShowBodyMassIndexGroup() {
        switch(bodyMassIndexGroup) {
            case BodyMassIndexGroup.BelowNormal:
                Console.WriteLine("Группа по индексу массы тела: ниже нормы");
                break;
            case BodyMassIndexGroup.Normal:
                Console.WriteLine("Группа по индексу массы тела: ниже нормы");
                break;
            case BodyMassIndexGroup.AboveNormal:
                Console.WriteLine("Группа по индексу массы тела: выше нормы");
                break;
        }


    }

    public void ShowAgeCategory() {
        switch(ageCategory) {
            case AgeCategory.Baby:
                Console.WriteLine("Возрастная категория: младенец");
                break;
            case AgeCategory.Child:
                Console.WriteLine("Возрастная категория: ребёнок");
                break;
            case AgeCategory.Teenager:
                Console.WriteLine("Возрастная категория: подросток");
                break;
            case AgeCategory.Adult:
                Console.WriteLine("Возрастная категория: взрослый");
                break;
            case AgeCategory.Elderly:
                Console.WriteLine("Возрастная категория: пожилой");
                break;
        }

    }

    public void ShowGender() {
        switch(gender) {
            case Gender.Female:
                Console.WriteLine("Пол: женский");
                break;
            case Gender.Male:
                Console.WriteLine("Пол: мужской");
                break;
        }
    }

    public void ShowStaticFields() {
        string output = "";
        output = String.Concat(output, "Части тела человека: ");
        foreach(string el in body) {
            output = String.Concat(output, el, " ");
        }
        output = String.Concat(output, "\nСъедобная еда: ");
        foreach(string el in edibleFood) {
            output = String.Concat(output, el, " ");
        }
        Console.WriteLine(output);
    }

    public string GenerateAgeCategoryStr() {
        switch(ageCategory) {
            case AgeCategory.Baby:
                return "\nВозрастная категория: младенец";
                break;
            case AgeCategory.Child:
                return "\nВозрастная категория: ребёнок";
                break;
            case AgeCategory.Teenager:
                return "\nВозрастная категория: подросток";
                break;
            case AgeCategory.Adult:
                return "\nВозрастная категория: взрослый";
                break;
            case AgeCategory.Elderly:
                return "\nВозрастная категория: пожилой";
                break;
            default:
                return "\nВозрастная категория: не определена";
        }
    }

    public string GenerateBodyMassIndexGroupStr() {
        switch(bodyMassIndexGroup) {
            case BodyMassIndexGroup.BelowNormal:
                return "\nГруппа по индексу массы тела: ниже нормы";
                break;
            case BodyMassIndexGroup.Normal:
                return "\nГруппа по индексу массы тела: ниже нормы";
                break;
            case BodyMassIndexGroup.AboveNormal:
                return "\nГруппа по индексу массы тела: выше нормы";
                break;
            default:
                return "\nГруппа по индексу массы тела: не определена";
                break;
        }
    }

    public string GenerateGenderStr() {
         switch(gender) {
            case Gender.Female:
                return "\nПол: женский";
                break;
            case Gender.Male:
                return "\nПол: мужской";
                break;
            default:
                return "\nПол: не определён";
                break;
        }
    }

    static bool CheckWrongGender(string str, bool isWrongSymb) {
        bool isWrongGender = false;
        if (isWrongSymb == true) {
            
        } else {
            if (Enum.IsDefined(typeof(Gender), int.Parse(str))) {
                Console.WriteLine("Ошибка! Были введены неверные числа для инициализации пола");
                isWrongGender = true;
            }
        }
        return isWrongGender;
    }

    static void CheckGenderInt(ref string str) {
        bool isWrongSymb = CheckWrongSymbInt(str);
        bool isEmpty = CheckStringEmpt(ref str);
        bool isNegative = CheckPositive(str, isEmpty);
        bool isWrongGender = CheckWrongGender(str, isWrongSymb);
        while ((isEmpty != false) || (isWrongSymb != false) 
                || (isNegative != false) || (isWrongGender != false)) {
            Console.WriteLine("Повторите ввод");
            str = Console.ReadLine();
            isWrongSymb = CheckWrongSymbInt(str);
            isEmpty = CheckStringEmpt(ref str);
            isNegative = CheckPositive(str, isEmpty);
            isWrongGender = CheckWrongGender(str, isWrongSymb);
        }
    }

    static void CheckString(ref string str) 
    {
        bool isWrongSymb = CheckWrongSymb(str);
        bool isEmpty = CheckStringEmpt(ref str);
        while ((isEmpty != false) || (isWrongSymb != false)) {
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

    static bool CheckPositive(string str, bool isEmpty) {
        bool isNegative = false;
        if (isEmpty == false) {
            if(str[0] == '-' || str[0] == '0') {
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
                || (isNegative != false)) {
            Console.WriteLine("Повторите ввод");
            str = Console.ReadLine();
            isWrongSymb = CheckWrongSymbInt(str);
            isEmpty = CheckStringEmpt(ref str);
            isNegative = CheckPositive(str, isEmpty);
        }
    }

    static bool CheckWrongSymbInt(string str) {
            bool isWrongSymb = false;
            Regex regExp = new Regex(@"[0-9]");
            MatchCollection match = regExp.Matches(str);
            if (match.Count != str.Length) {
                Console.WriteLine("Ошибка были введены недопустимые символы");
                isWrongSymb = true;
            }
            return isWrongSymb;
        }

    public void BirthDay() {
        age++;
        AssignAgeCategory();
        Console.WriteLine("С днём рождения!");
        Console.WriteLine("Ваш возраст: {0}", this["age"]);
    }

    public void EatTastyFood() {
        Random random = new Random();
        int value = random.Next(0, 1);
        switch(value) {
            case 0:
                Console.WriteLine("Вам не повезло. Вы потолстели на 1 кг");
                weight++;
                Console.WriteLine("Ваш вес: {0}", weight);
                break;
            case 1:
                Console.WriteLine("Вам повезло. Ваш вес не изменился");
                break;
        }
    }

    public void ChangeHumanField() {
        Console.WriteLine("Введите номер поля, которое хотите изменить: 1 - имя, 2 - фамилия, 3 - отчество, 4 - вес, 5 - рост, 6 - пол, 7 - хобби");
        string choiceStr = Console.ReadLine();
        CheckPositiveInt(ref choiceStr);
        int choice = int.Parse(choiceStr); 
        switch(choice) {
            case 1:
                ChangeName();
                break;
            case 2:
                ChangeLastName();
                break;
            case 3:
                ChangePatronymic();
                break;
            case 4:
                ChangeWeight();
                break;
            case 5:
                ChangeGrowth();
                break;
            case 6:
                ChangeGender();
                break;
            case 7:
                ChangeHobby();
                break;   
            default:
                Console.WriteLine("Ошибка! Повторите ввод номера поля");
                ChangeHumanField();
                break;
        }
    }

    public void ChangeName() {
        Console.WriteLine("Введите новое имя");
        name = Console.ReadLine();
        CheckString(ref name);
    }

    public void ChangeLastName() {
        Console.WriteLine("Введите новую фамилию");
        lastName = Console.ReadLine();
        CheckString(ref lastName);
    } 

    public void ChangePatronymic() {
        Console.WriteLine("Введите новое отчество");
        patronymic = Console.ReadLine();
        CheckString(ref patronymic);
    }

    public void ChangeWeight() {
        Console.WriteLine("Введите новый вес");
        string weightStr = Console.ReadLine();
        CheckPositiveInt(ref weightStr);
        weight = int.Parse(weightStr);
    }

    public void ChangeGrowth() {
        Console.WriteLine("Введите новый рост");
        string growthStr = Console.ReadLine();
        CheckPositiveInt(ref growthStr);
        growth = int.Parse(growthStr);
    }

    public void ChangeGender() {
        switch(gender) {
            case Gender.Male:
                gender = Gender.Female;
                break;
            case Gender.Female:
                gender = Gender.Male;
                break;
        }
    }

    public void ChangeHobby() {
        Console.WriteLine("Введите новое хобби");
        hobby = Console.ReadLine();
        CheckString(ref hobby);
    }

    public void MethodsInvocation() {
        Console.WriteLine("Выберите метод, который хотите вызвать: 1 - ничего не делать, 2 - информация об объекте класса, 3 - смена какого-либо поля объекта класса, 4 - день рождения, 5 - вкусно поесть, 6 - вывести статические поля класса");
        string choiceStr = Console.ReadLine();
        CheckPositiveInt(ref choiceStr);
        int choice = int.Parse(choiceStr); 
        switch(choice) {
            case 1:
                break;
            case 2:
                HumanInfo();
                MethodsInvocation();
                break;   
            case 3:
                ChangeHumanField();
                MethodsInvocation();
                break;
            case 4:
                BirthDay();
                MethodsInvocation();
                break;
            case 5:
                EatTastyFood();
                MethodsInvocation();
                break;
            case 6:
                ShowStaticFields();
                MethodsInvocation();
                break;
            default:
                Console.WriteLine("Была введена неверная операция. Повторите ввод");
                MethodsInvocation();
                break;
        }

    }

    public void HumanInfo() {
        string output = String.Concat("Имя: ", this["name"], "\nФамилия: ", this["lastName"], "\nОтчество: ", this["patronymic"],"\nВозраст: ", this["age"].ToString(), "\nВес: ", this["weight"].ToString(), "\nРост: ", this["growth"].ToString(), GenerateAgeCategoryStr(), GenerateGenderStr(), GenerateBodyMassIndexGroupStr(), "\nХобби: ", this["hobby"]);
        Console.WriteLine(output);
    }

    protected string name;
    protected string lastName;
    protected int age;
    protected int weight;
    protected int growth;
    protected AgeCategory ageCategory; 
    protected Gender gender;
    protected BodyMassIndexGroup bodyMassIndexGroup;
    protected string hobby;
    protected string patronymic;
    protected double bodyMassIndex;
    static protected string[] body = {"голова", "глаза", "руки", "уши", "ноги"};
    static protected string[] edibleFood = {"овощи", "мясо", "фрукты"};
}

class Student : Human {
    ~Student() {
        
    }
    protected string university;
}

class StudentOfCertainSpeciality : Student {
    
}

enum AgeCategory {
    Baby,
    Child,
    Teenager,
    Adult,
    Elderly
}

enum Gender {
    Male = 1, 
    Female = 2
}

enum BodyMassIndexGroup {
    BelowNormal,
    Normal,
    AboveNormal
}

namespace LAB3
{
    class Program
    {  
        static bool CheckWrongGender(string str, bool isWrongSymb, bool isEmpty) {
            bool isWrongGender = false;
            if (isWrongSymb == false && isEmpty == false) {
                if (Enum.IsDefined(typeof(Gender), int.Parse(str))) {
                    
                } else {
                    Console.WriteLine("Ошибка! Были введены неверные числа для инициализации пола");
                    isWrongGender = true;
                }
            } 
            return isWrongGender;
        }

        static void CheckGenderInt(ref string str) {
            bool isWrongSymb = CheckWrongSymbInt(str);
            bool isEmpty = CheckStringEmpt(ref str);
            bool isNegative = CheckPositive(str, isEmpty);
            bool isWrongGender = CheckWrongGender(str, isWrongSymb, isEmpty);
            while ((isEmpty != false) || (isWrongSymb != false) 
                    || (isNegative != false) || (isWrongGender != false)) {
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
            while ((isEmpty != false) || (isWrongSymb != false)) {
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

        static bool CheckPositive(string str, bool isEmpty) {
            bool isNegative = false;
            if (isEmpty == false) {
                if(str[0] == '-' || str[0] == '0') {
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
                        || (isNegative != false)) {
                    Console.WriteLine("Повторите ввод");
                    str = Console.ReadLine();
                    isWrongSymb = CheckWrongSymbInt(str);
                    isEmpty = CheckStringEmpt(ref str);
                    isNegative = CheckPositive(str, isEmpty);
                }
            }

        static bool CheckWrongSymbInt(string str) {
                bool isWrongSymb = false;
                Regex regExp = new Regex(@"[0-9]");
                MatchCollection match = regExp.Matches(str);
                if (match.Count != str.Length) {
                    Console.WriteLine("Ошибка были введены недопустимые символы");
                    isWrongSymb = true;
                }
                return isWrongSymb;
            }

        static Human HumanInitialization() {
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

        static void Main(string[] args)
        {
            Human human = new Human();
            human = HumanInitialization();
            human.HumanInfo();
            human.MethodsInvocation();
            Console.ReadKey();
        }
    }
}
