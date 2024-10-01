namespace DZ6;

class Program
{
    static void Main(string[] args)
    {
        ICalculatable calculator = new Calculator();
        calculator.GotResult += Calculator_GotResult;

        TryCatch(calculator.Add, 7.1);

        TryCatch(calculator.Multi, double.MaxValue);
        TryCatch(calculator.Sub, double.MaxValue);
        TryCatch(calculator.Sub, double.MaxValue);
        TryCatch(calculator.Div, 0);

        Console.ReadKey();
    }

    static void TryCatch(Action<double> action, double value)
    {
        try
        {
            action.Invoke(value);
        }
        catch (CalculatorDivideByZeroExeption ex)
        {
            Console.WriteLine(ex);
        }
        catch (CalculatorOperationCauseOverflowExeption ex)
        {
            Console.WriteLine(ex);
        }
    }

    private static void Calculator_GotResult(object? sender, EventArgs e)
    {
        Console.WriteLine($"{((Calculator)sender).Result}");
    }


}

