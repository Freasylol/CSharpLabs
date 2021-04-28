using System;

class Programmer : WorkingHuman
{
    ~Programmer()
    {

    }
    public Programmer()
    {

    }
    public Programmer(string name, string lastName, string patronymic, int age, int weight,
                      int growth, string hobby, int gender, int salary, string placeOfWork,
                      string position, string favouriteProgrammingLang) : base(name, lastName,
                      patronymic, age, weight, growth, hobby, gender, salary, placeOfWork, position)
    {
        this.favouriteProgrammingLang = favouriteProgrammingLang;
    }
    public override void WorkingHumanInfo()
    {
        base.WorkingHumanInfo();
        string programmerOutput = "\nЛюбимый язык программирования: " + favouriteProgrammingLang;
        Console.WriteLine(programmerOutput);
    }

    public override void GetSalary()
    {
        Console.WriteLine("Программист получил зарплату");
    }
    public override void Work()
    {
        Console.WriteLine("Программист работает");
    }
    public override void WorkingHumanMethodsInvocation()
    {
        Console.WriteLine("Выберите метод, который хотите вызвать: 1 - ничего не делать, 2 - информация об объекте класса, 3 - смена какого-либо поля объекта класса, 4 - день рождения, 5 - вывести статические поля класса, 6 - ходить, 7 - дышать, 8 - есть, 9 - повышение зарплаты,");
        string choiceStr = Console.ReadLine();
        CheckPositiveInt(ref choiceStr);
        int choice = int.Parse(choiceStr);
        switch (choice)
        {
            case 1:
                break;
            case 2:
                WorkingHumanInfo();
                WorkingHumanMethodsInvocation();
                break;
            case 3:
                ChangeWorkingHumanField();
                WorkingHumanMethodsInvocation();
                break;
            case 4:
                BirthDay();
                WorkingHumanMethodsInvocation();
                break;
            case 5:
                ShowStaticFields();
                WorkingHumanMethodsInvocation();
                break;
            case 6:
                Move();
                WorkingHumanMethodsInvocation();
                break;
            case 7:
                Breathe();
                WorkingHumanMethodsInvocation();
                break;
            case 8:
                Eat();
                WorkingHumanMethodsInvocation();
                break;
            case 9:
                SalaryIncrease();
                WorkingHumanMethodsInvocation();
                break;
            default:
                Console.WriteLine("Была введена неверная операция. Повторите ввод");
                WorkingHumanMethodsInvocation();
                break;
        }
    }

    public void ChangeFavouriteProgrammingLang()
    {
        Console.WriteLine("Введите новый любимый язык программирования");
        favouriteProgrammingLang = Console.ReadLine();
        CheckString(ref favouriteProgrammingLang);
    }

    public override void ChangeWorkingHumanField()
    {
        Console.WriteLine("Введите номер поля, которое хотите изменить: 1 - имя, 2 - фамилия, 3 - отчество, 4 - вес, 5 - рост, 6 - пол, 7 - хобби, 8 - зарплату, 9 - должность, 10 - место работы, 11 - любимый язык программирования");
        string choiceStr = Console.ReadLine();
        CheckPositiveInt(ref choiceStr);
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
            case 8:
                ChangeSalary();
                WorkingHumanMethodsInvocation();
                break;
            case 9:
                ChangePosition();
                WorkingHumanMethodsInvocation();
                break;
            case 10:
                ChangePlaceOfWork();
                WorkingHumanMethodsInvocation();
                break;
            case 11:
                ChangeFavouriteProgrammingLang();
                WorkingHumanMethodsInvocation();
                break;
            default:
                Console.WriteLine("Ошибка! Повторите ввод номера поля");
                ChangeHumanField();
                break;
        }
    }

    private string favouriteProgrammingLang;
}
