/*
 * Author: Humzah Ali
 * Date: 23/11/15
 * Project: Unit Converter
 * File: UnitConverterProgram.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    class UnitConverterProgram
    {
        internal RunConverter RunConverter
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        static void Main(string[] args)
        {
            bool repeatProg = true;//bool to repeat program

            do
            {
                Console.Title = "Unit Conversion Program";//change the console title
                Console.SetWindowSize(78, 40);//change window size to make it appropriate to view a table of conversions

                string repeatAns;//variable for answer given to repeat question
                RunConverter runProgram = new RunConverter();//create an instance of RunConverter class

                runProgram.Run();//call the run method

                Console.ForegroundColor = ConsoleColor.Cyan;//change text colour to cyan
                Console.Write("\nEnter \"exit\" if you want to exit the program: ");
                repeatAns = Console.ReadLine().ToUpper();

                if (repeatAns == "EXIT")//if answer is exit
                    repeatProg = false;//repeat is false

                Console.Clear();

            } while (repeatProg == true);//keep running the program while repeatProg is true
        }//end main
    }//end program class
}//end namespace
