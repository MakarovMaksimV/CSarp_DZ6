using System;
using static System.Collections.Specialized.BitVector32;

namespace DZ6
{
	public class CalculatorExeption : Exception
	{


        public CalculatorExeption(string s, Stack<CalculatorActionLog> action) : base(s)
        {
            Action = action;
        }
        public CalculatorExeption(string s, Exception e) : base(s, e)
		{
            
		}
        public override string ToString()
        {
            return Message + ": " + string.Join("\n", Action.Select(x => $"{x.CalculatorAction} {x.CalcArgument}"));
        }
        public Stack<CalculatorActionLog> Action { get; private set; }
    }

    class CalculatorDivideByZeroExeption : CalculatorExeption
    {
        public CalculatorDivideByZeroExeption(string s, Stack<CalculatorActionLog> action) : base(s,action)
        {

        }

        public CalculatorDivideByZeroExeption(string s, Exception e) : base(s, e)
        {

        }
    }

    class CalculatorOperationCauseOverflowExeption : CalculatorExeption
    {
		public CalculatorOperationCauseOverflowExeption(string s, Stack<CalculatorActionLog> action) : base(s, action)
		{

		}

        public CalculatorOperationCauseOverflowExeption(string s, Exception e) : base(s, e)
        {

        }

    }
}

