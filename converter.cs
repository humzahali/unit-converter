/*
 * Author: Humzah Ali
 * Date: 23/11/15
 * Project: Unit Converter
 * File: Converter.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    class Converter
    {
        //attributes
        private int _userInput;
        private int _counter;
        private double _factorValue;

        private List<double> halfUnit = new List<double>();// list instead of an array because I don't know the amount of elements

        public enum Operator { PLUS = 1, MINUS = 2, MULTIPLY = 3, DIVIDE = 4 };//create enum type for mathematecal operators

        //methods
        //constructor
        public Converter(int userInput, int counter, double factorVal)
        {
            //assign parameters to class attributes
            this._userInput = userInput;
            this._counter = counter;
            this._factorValue = factorVal;
        }

        //generic convert method that can convert to and from any unit
        public double Convert(double fromNum, Operator op) //pass the original value, the operation and value to convert by
        {
            double ans = 0;

            //switch case - use appropriate operator in each formula 
            switch (op)
            {
                case Operator.MULTIPLY:
                    ans = fromNum * this._factorValue;
                    break;
                case Operator.DIVIDE:
                    ans = fromNum / this._factorValue;
                    break;
                case Operator.PLUS:
                    ans = fromNum + this._factorValue;
                    break;
                case Operator.MINUS:
                    ans = fromNum - this._factorValue;
                    break;
            }

            return ans;//return answer of conversion
        }//end Convert method

        public List<double> GetHalfUnit()
        {
            this.halfUnit.Add(0.5);//initialise list

            //set list elements of half units
            for (double i = 0; i <= (this._userInput / 2); i += 0.5)
            {
                double halfUnitNum;

                halfUnitNum = this.halfUnit[this.halfUnit.Count - 1] + 0.5;//add 0.5 to the last element in the list

                this.halfUnit.Add(halfUnitNum);//add half unit to list
            }//end for loop

            return this.halfUnit;
        }//end getHalfList

        public void PrintTable(string fromUnit, string toUnit, Operator op)
        {
            Int32 listIndex = 0;//variable to keep track of itterations in list

            //TABLE HEADER, width specifier of 9 and 18
            Console.WriteLine("\n{0,9} {1,18}", fromUnit, toUnit);
            Console.WriteLine("=================================");//table seperator

            //display contents of the table while counter is lessthan or equal to the user input
            while (this._counter <= this._userInput)
            {
                double convertedUnit = this.Convert(this._counter, op);//store converted unit 

                //add half gallon data
                foreach (double num in this.halfUnit)
                {
                    if (num < convertedUnit)//print half gallon if element in list is less than the converted unit
                    {
                        if (this.halfUnit[listIndex] >= convertedUnit)
                            break;//don't do anything if the element in the list is bigger than the converted gallon

                        Console.WriteLine("{0,9} <--- {1,13} <---",
                            this.Convert(this.halfUnit[listIndex], Operator.DIVIDE).ToString("0.000"),//converted data
                            this.halfUnit[listIndex].ToString("0.000"));//print half gallon and litre conversion

                        listIndex++;//increment list pointer
                        break;//stop and don't write more than 1 half unit at a time
                    }//end if
                }//end foreach loop

                //write the litre number and the gallon conversion on the other side
                Console.WriteLine("{0,9} {1,18}", this._counter.ToString("0.000"), convertedUnit.ToString("0.000"));

                this._counter++;//increment litre counter by 1
            }//end while loop
        }//end print function
    }//end class
}//end namespace
