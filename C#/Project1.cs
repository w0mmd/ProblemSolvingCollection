using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    class clsCalculator
    {
        private float _Result = 0;
        private float _Number = 0;
        public float Result
        {
            get
            {
                return _Result;
            }
            set
            {
                _Result = value;
            }
        }

        public float number
        {
            get
            {
                return _Number;
            }
            set
            {
                _Number = value;
            }
        }

        public string OpName
        {
            get;
            set;
        }
        
        private bool _IsZero(float Number)
        {
            return (Number == 0);
        }

        public void Clear()
        {
            Result = 0;
        }

        public void Add(float Number)
        {
            number = Number;
            Result += Number;
            OpName = "Adding";
        }

        public void Subtract(float Number)
        {
            number = Number;
            Result -= Number;
            OpName = "Subtracting";
        }

        public void Multiply(float Number)
        {
            number = Number;
            Result *= Number;
            OpName = "Multiplying";
        }

        public bool Divide(float Number)
        {
            number = Number;           
            OpName = "Dividing";
            bool Succeeded = true;

            if (_IsZero(Number))
            {
                Result /= 1;
                Succeeded = false;
            }
            else
            {
                Result /= Number;
                Succeeded = true;
            }

            return Succeeded;
        }

        public void Print()
        {
            Console.WriteLine($"Result after {OpName} {number} is: {Result}");
        }
        

    }

    internal class Program
    {
       
        static void Main(string[] args)
        {

            clsCalculator Calculator1 = new clsCalculator();

            Calculator1.Add(10);
            Calculator1.Print();

            Calculator1.Add(100);
            Calculator1.Print();

            Calculator1.Subtract(20);
            Calculator1.Print();

            Calculator1.Divide(0);
            Calculator1.Print();

            Calculator1.Multiply(3);
            Calculator1.Print();

            Calculator1.Clear();
            Calculator1.Print();
            
            Console.ReadKey();
        }

    }
}
