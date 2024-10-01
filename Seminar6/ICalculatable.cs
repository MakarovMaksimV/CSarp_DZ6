using System;
namespace DZ6
{
	public interface ICalculatable
	{
		event EventHandler<EventArgs> GotResult;
		public void Add(double num);
		public void Sub(double num);
		public void Div(double num);
		public void Multi(double num);
    }
}

