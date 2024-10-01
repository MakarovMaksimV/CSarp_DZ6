
using System;

namespace DZ6
{
    public class Calculator : ICalculatable
    {
        public double Result = 0;
        Stack<double> stk = new Stack<double>();
        Stack<CalculatorActionLog> action = new Stack<CalculatorActionLog>();

        public event EventHandler<EventArgs>? GotResult;

        public void Add(double num)
        {
            double temp = Result + num;
            if (temp>double.MaxValue)
            {
                action.Push(new CalculatorActionLog(CalculatorAction.Add, num));
                throw new CalculatorOperationCauseOverflowExeption("Переполнение", action);
            }
            Result += num;
            RiseEvent();
            stk.Push(Result);
            action.Push(new CalculatorActionLog(CalculatorAction.Add, num)); Result += num;

        }

        public void Div(double num)
        {
            if (num == 0)
            {
                action.Push(new CalculatorActionLog(CalculatorAction.Div, num));
                throw new CalculatorDivideByZeroExeption("Деление на ноль",action);
            }  
            Result /= num;
            RiseEvent();
            stk.Push(Result);
            action.Push(new CalculatorActionLog(CalculatorAction.Div, num));
        }

        public void Multi(double num)
        {
            double temp = Result * num;
            if(temp>double.MaxValue)
            {
                action.Push(new CalculatorActionLog(CalculatorAction.Multy, num));
                throw new CalculatorOperationCauseOverflowExeption("Переполнение", action);
            }
            Result *= num;
            RiseEvent();
            stk.Push(Result);
        }

        public void Sub(double num)
        {
            double temp = Result - num;
            if (temp < double.MinValue )
            {
                action.Push(new CalculatorActionLog(CalculatorAction.Sub, num));
                throw new CalculatorOperationCauseOverflowExeption("Переполнение", action);
            }
            stk.Push(Result);
            Result -= num;
            RiseEvent();
        }

        public void RiseEvent()
        {
            GotResult?.Invoke(this,EventArgs.Empty);
        }

        public void CanselLast()
        {
            stk.Pop();
            Result = stk.Peek();
            RiseEvent();
        }
    }
}

