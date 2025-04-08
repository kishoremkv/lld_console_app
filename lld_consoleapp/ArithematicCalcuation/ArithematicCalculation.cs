// This uses Composite design pattern


using System.Collections;
using System.Runtime.CompilerServices;

namespace lld_console_app.ArithematicCalculation
{
    // you have to do the arithematic calculation

    // operation and then you can 
    
    
    public interface ArithematicCalculator
    {
        public double calculate();
    }

    public class Number : ArithematicCalculator
    {
        public int Value { get; set; }
        public Number(int Value)
        {
            this.Value = Value;
        }
        public double calculate()
        {   
            return this.Value;
        }
    }

    public class Operator : ArithematicCalculator
    {

        public OperatorTypes operation { get; set; }
        
        public ArithematicCalculator Left { get; set; }
        public ArithematicCalculator Right { get; set; }

        public Operator(ArithematicCalculator arithematicCalculator1, ArithematicCalculator arithematicCalculator2, OperatorTypes ch)
        {
            this.operation = ch;
            this.Left = arithematicCalculator1;
            this.Right = arithematicCalculator2;
        }
        public double calculate()
        {
            switch(this.operation)
            {
                case OperatorTypes.PLUS:
                    return this.Left.calculate() + this.Right.calculate();
                case OperatorTypes.MINUS:
                    return this.Left.calculate() - this.Right.calculate();
                case OperatorTypes.MULTIPLY:
                    return this.Left.calculate() * this.Right.calculate();
                case OperatorTypes.DIVIDE:
                    if(this.Right.calculate() == 0)
                    {
                        return -1;
                    }
                    else 
                    {
                        return this.Left.calculate() / this.Right.calculate();
                    }
                default:
                    return 0;
            }

        }
    }

    public class ArithematicCalculation
    {
        public static void Run()
        {
            ArithematicCalculator number1 = new Number(3);
            ArithematicCalculator number2 = new Number(5);
            ArithematicCalculator number3 = new Number(10);

            ArithematicCalculator arithematicCalculator = new Operator(number1, number2, OperatorTypes.MINUS);
            ArithematicCalculator arithematicCalculator2 = new Operator(arithematicCalculator, number3, OperatorTypes.DIVIDE);
            
            Console.WriteLine(arithematicCalculator2.calculate());

        }
    }

    public enum OperatorTypes
    {
        PLUS = '+', 
        MINUS = '-', 
        MULTIPLY = '*', 
        DIVIDE = '/'
    }
}