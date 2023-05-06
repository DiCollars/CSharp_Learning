try
{
    ExplicitTypecastingCorrect();

    ExplicitTypecastingEcxeption();
}
catch (Exception ex)
{
    Console.Beep();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("ERROR:/ " + ex.Message);
    Console.ResetColor();
}


void ExplicitTypecastingCorrect()
{
    //CLR will check casting -> target type can be parent or current object type.
    Object obj = new Employee();
    Employee employee = (Employee)obj;
}

void ExplicitTypecastingEcxeption()
{
    //All correct, right?
    Manager manager = new Manager();
    PromoteEmployee(manager);

    //Hmmm, InvalidCastException
    DateTime dateTime = DateTime.Now;
    PromoteEmployee(dateTime);
}

void PromoteEmployee(object o)
{
    Employee e = (Employee)o;
}

class Employee { }

class Manager : Employee { }
