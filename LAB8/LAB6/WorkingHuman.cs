using System;

abstract class WorkingHuman : Human
{
    public WorkingHuman()
    {

    }
    public WorkingHuman(string name, string lastName, string patronymic, int age, int weight,
                        int growth, string hobby, int gender, int salary,
                        string placeOfWork, string position) : base(name, lastName, patronymic,
                        age, weight, growth, hobby, gender)
    {
        this.salary = salary;
        this.placeOfWork = placeOfWork;
        this.position = position;
    }
    ~WorkingHuman()
    {
    }
    public abstract void GetSalary();
    public abstract void Work();
    public virtual void WorkingHumanInfo()
    {
        HumanInfo();
        string workingHumanInfo = "Место работы: " + placeOfWork + "\nЗарплата: " + salary.ToString();
        Console.WriteLine(workingHumanInfo);
    }
    public abstract void WorkingHumanMethodsInvocation();

    public void ChangePlaceOfWork()
    {
        Console.WriteLine("Введите новое место работы");
        placeOfWork = Console.ReadLine();
        Checker.Check(ref placeOfWork, Checker.ConfigCheckHandlerStr());
    }

    public void ChangeSalary()
    {
        Console.WriteLine("Введите новую зарплату");
        string salaryStr = Console.ReadLine();
        Checker.Check(ref salaryStr, Checker.ConfigCheckHandlerInt());
        salary = int.Parse(salaryStr);

    }

    public void ChangePosition()
    {
        Console.WriteLine("Введите новую должность");
        position = Console.ReadLine();
        Checker.Check(ref position, Checker.ConfigCheckHandlerStr());
    }


    public virtual void SalaryIncrease()
    {
        Console.WriteLine("Поздравляем! Вам повысили зарплату( + 100 к зарплате)");
        salary += 100;
        Console.WriteLine("Ваша текущая зарплата: " + salary);
    }

    public abstract void ChangeWorkingHumanField();

    protected int salary;
    protected string placeOfWork;
    protected string position;

}
