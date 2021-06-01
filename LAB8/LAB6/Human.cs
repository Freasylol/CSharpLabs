using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
class Human : ICreature
{
    public void Move() => Console.WriteLine("Человек дышит");

    public void Eat() => Console.WriteLine("Человек ест");

    public void Breathe() => Console.WriteLine("Человек дышит");

    ~Human()
    {
    }

    public Human()
    {

    }

    public Human(string name, string lastName, string patronymic, int age, int weight,
                 int growth, string hobby, int gender)
    {
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

    public dynamic this[string propName]
    {
        get
        {
            switch (propName)
            {
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
        set
        {
            switch (propName)
            {
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

    public void AssignBodyMassIndex()
    {
        if (growth != 0)
        {
            bodyMassIndex = weight / (growth * growth);
            if (bodyMassIndex > 18.5 && bodyMassIndex < 25)
            {
                bodyMassIndexGroup = BodyMassIndexGroup.Normal;
            }
            else if (bodyMassIndex < 18.5)
            {
                bodyMassIndexGroup = BodyMassIndexGroup.BelowNormal;
            }
            else
            {
                bodyMassIndexGroup = BodyMassIndexGroup.AboveNormal;
            }
        }


    }

    public void AssignAgeCategory()
    {
        if (age <= 3 && age > 0)
        {
            ageCategory = AgeCategory.Baby;
        }
        else if (age > 3 && age <= 12)
        {
            ageCategory = AgeCategory.Child;
        }
        else if (age > 12 && age < 18)
        {
            ageCategory = AgeCategory.Teenager;
        }
        else if (age >= 18 && age < 60)
        {
            ageCategory = AgeCategory.Adult;
        }
        else if (age >= 60)
        {
            ageCategory = AgeCategory.Elderly;
        }
    }

    public void ShowBodyMassIndexGroup()
    {
        switch (bodyMassIndexGroup)
        {
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

    public void ShowAgeCategory()
    {
        switch (ageCategory)
        {
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

    public void ShowGender()
    {
        switch (gender)
        {
            case Gender.Female:
                Console.WriteLine("Пол: женский");
                break;
            case Gender.Male:
                Console.WriteLine("Пол: мужской");
                break;
        }
    }

    public void ShowStaticFields()
    {
        string output = "";
        output = String.Concat(output, "Части тела человека: ");
        foreach (string el in body)
        {
            output = String.Concat(output, el, " ");
        }
        output = String.Concat(output, "\nСъедобная еда: ");
        foreach (string el in edibleFood)
        {
            output = String.Concat(output, el, " ");
        }
        Console.WriteLine(output);
    }

    public string GenerateAgeCategoryStr()
    {
        switch (ageCategory)
        {
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

    public string GenerateBodyMassIndexGroupStr()
    {
        switch (bodyMassIndexGroup)
        {
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

    public string GenerateGenderStr()
    {
        switch (gender)
        {
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

    public void BirthDay()
    {
        age++;
        AssignAgeCategory();
        Console.WriteLine("С днём рождения!");
        Console.WriteLine("Ваш возраст: {0}", this["age"]);
    }

    public void ChangeHumanField()
    {
        Console.WriteLine("Введите номер поля, которое хотите изменить: 1 - имя, 2 - фамилия, 3 - отчество, 4 - вес, 5 - рост, 6 - пол, 7 - хобби");
        string choiceStr = Console.ReadLine();
        Checker.Check(ref choiceStr, Checker.ConfigCheckHandlerInt());
        int choice = int.Parse(choiceStr);
        switch (choice)
        {
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

    public void ChangeName()
    {
        Console.WriteLine("Введите новое имя");
        name = Console.ReadLine();
        Checker.Check(ref name, Checker.ConfigCheckHandlerStr());
    }

    public void ChangeLastName()
    {
        Console.WriteLine("Введите новую фамилию");
        lastName = Console.ReadLine();
        Checker.Check(ref lastName, Checker.ConfigCheckHandlerStr());
    }

    public void ChangePatronymic()
    {
        Console.WriteLine("Введите новое отчество");
        patronymic = Console.ReadLine();
        Checker.Check(ref patronymic, Checker.ConfigCheckHandlerStr());
    }

    public void ChangeWeight()
    {
        Console.WriteLine("Введите новый вес");
        string weightStr = Console.ReadLine();
        Checker.Check(ref weightStr, Checker.ConfigCheckHandlerInt());
        weight = int.Parse(weightStr);
    }

    public void ChangeGrowth()
    {
        Console.WriteLine("Введите новый рост");
        string growthStr = Console.ReadLine();
        Checker.Check(ref growthStr, Checker.ConfigCheckHandlerInt());
        growth = int.Parse(growthStr);
    }

    public void ChangeGender()
    {
        switch (gender)
        {
            case Gender.Male:
                gender = Gender.Female;
                break;
            case Gender.Female:
                gender = Gender.Male;
                break;
        }
    }

    public void ChangeHobby()
    {
        Console.WriteLine("Введите новое хобби");
        hobby = Console.ReadLine();
        Checker.Check(ref hobby, Checker.ConfigCheckHandlerStr());
    }


    public void HumanMethodsInvocation()
    {
        Console.WriteLine("Выберите метод, который хотите вызвать: 1 - ничего не делать, 2 - информация об объекте класса, 3 - смена какого-либо поля объекта класса, 4 - день рождения, 5 - вывести статические поля класса, 6 - ходить, 7 - дышать, 8 - есть");
        string choiceStr = Console.ReadLine();
        Checker.Check(ref choiceStr, Checker.ConfigCheckHandlerInt());
        int choice = int.Parse(choiceStr);
        switch (choice)
        {
            case 1:
                break;
            case 2:
                HumanInfo();
                HumanMethodsInvocation();
                break;
            case 3:
                ChangeHumanField();
                HumanMethodsInvocation();
                break;
            case 4:
                BirthDay();
                HumanMethodsInvocation();
                break;
            case 5:
                ShowStaticFields();
                HumanMethodsInvocation();
                break;
            case 6:
                Move();
                HumanMethodsInvocation();
                break;
            case 7:
                Eat();
                HumanMethodsInvocation();
                break;
            case 8:
                Breathe();
                HumanMethodsInvocation();
                break;
            default:
                Console.WriteLine("Была введена неверная операция. Повторите ввод");
                HumanMethodsInvocation();
                break;
        }

    }



    public void HumanInfo()
    {
        string output = String.Concat("Имя: ", this["name"], "\nФамилия: ", this["lastName"], "\nОтчество: ", this["patronymic"], "\nВозраст: ", this["age"].ToString(), "\nВес: ", this["weight"].ToString(), "\nРост: ", this["growth"].ToString(), GenerateAgeCategoryStr(), GenerateGenderStr(), GenerateBodyMassIndexGroupStr(), "\nХобби: ", this["hobby"], "\n");
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
    static protected string[] body = { "голова", "глаза", "руки", "уши", "ноги" };
    static protected string[] edibleFood = { "овощи", "мясо", "фрукты" };
}
