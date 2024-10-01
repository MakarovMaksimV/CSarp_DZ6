using System;
namespace DZ6
{
	public class CalculatorActionLog
	{
		public  CalculatorAction CalculatorAction {get; private set;}

		

		public double CalcArgument { get; private set; }

		public CalculatorActionLog(CalculatorAction CalculatorAction, double CalcArgument)
		{
			this.CalculatorAction = CalculatorAction;
			this.CalcArgument = CalcArgument;
        }
	}
}

