/*
 * Author: Humzah Ali
 * Date: 23/11/15
 * Project: Unit Converter
 * File: RunConverter.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    class RunConverter
    {
        //attributes
        string introText;
        int litreInput = 0;
        bool prompt = true;//flag to know if prompt should be repeated
        string extendProgram;

        internal Converter Converter
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        //methods
        //run method
        public void Run()
        {
            introText = "This is a unit conversion program which displays a chart of litre values and\nthe equivalent in gallons. "
                + "Half gallons will also be displayed in the chart."
                + "\nHalf gallon equivalents are indicated with a '<---'."
                + "\n\nYou will then have the option to extend the program and "
                + "create your own\nconversion table.";//set intro text
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(introText); //write intro text
            Console.ResetColor();//reset colour back to default

            while (prompt)//while ask prompt = true
            {
                do//ask for litre input
                {
                    try
                    {
                        //prompt user to provide an input and assign their input in a variable
                        Console.Write("\nPlease enter the number of litres you want converted to gallons: ");
                        litreInput = int.Parse(Console.ReadLine());//assign the input to a variable and parse as an int
                        prompt = false;//change value of repeat bool to false as the user entered a valid input
                    }
                    catch//catch any exception
                    {
                        Console.WriteLine("Please enter a whole number.\n");//prompt user to enter a valid number
                    }
                } while (litreInput <= 0);//while input is less than or equal to 0, repeat the loop
            }//end while

            //create an instance with given litreInput, start counter at 1 and provide the conversion factor form litres/gallons
            Converter litreConverter = new Converter(litreInput, 1, 0.21997);

            litreConverter.GetHalfUnit();//make list of half units

            //print table with the two headers "Litres" and "Gallons" and pass the multiply enum value
            litreConverter.PrintTable("Litres", "Gallons", Converter.Operator.MULTIPLY);

            //prompt user asking if they would like to extend the program and create their own unit conversion table
            Console.Write("\nEnter \"yes\" if you want to extend the program and convert your own unit: ");
            extendProgram = Console.ReadLine().ToUpper();//read input and convert it to upper case

            if (extendProgram == "YES")//if user enters the string 'yes' in any case, start the extended program
            {
                string helpText;//guides user on how to use this part of the program
                int unitInput = 0;//input from user stored in this variable
                double conversionFactor = 0;//conversion factor initialised to 0
                string fromUnit = "init";//initialise string
                string toUnit = "init";//initialise string
                Converter.Operator opInput = Converter.Operator.MULTIPLY;//create enum type

                helpText = "\nThis part of the program allows you to create your own conversion table!\n"
                    + "\nYOU WILL NEED TO KNOW:\n\nThe value you are converting from (MUST BE NO LONGER THAN 9 CHARACTERS)\n"
                    + "The value you are converting to (MUST BE NO LONGER THAN 9 CHARACTERS)"
                    + "\nThe operator (plus (1), minus (2), multiply (3) or divide (4))\n"
                    + "The factor value used to arrive at the converted value\nNumber you want converted to";//help text for user
                Console.ForegroundColor = ConsoleColor.Green;//change text colour to green
                Console.WriteLine(helpText); //write help text
                Console.ResetColor();//reset colour to the default

                //ASK FOR BOTH TO AND FROM UNITS - FOR TABLE HEADERS
                do
                {
                    //prompt user to provide input and assign their input in a variable
                    Console.Write("\nPlease enter the unit you are converting from: ");
                    fromUnit = Console.ReadLine();//assign the input to a variable
                } while (fromUnit.Length > 9);//prevent table from being unorganised and only allow 9 characters

                do
                {
                    //prompt user to provide input and assign their input in a variable
                    Console.Write("\nPlease enter the unit you are converting to: ");
                    toUnit = Console.ReadLine();//assign the input to a variable
                } while (toUnit.Length > 9);//prevent table from being unorganised and only allow 9 characters

                //ASK FOR OPERATOR
                prompt = true;//ask bool reset to true
                while (prompt)//while repeat = true
                {
                    do
                    {
                        try
                        {
                            //prompt user to provide input and assign their input in a variable
                            Console.Write("\nPlease enter the operation used in the conversion: ");
                            opInput = (Converter.Operator)Enum.Parse(typeof(Converter.Operator), Console.ReadLine().ToUpper());//assign the input to a variable
                            prompt = false;//don't ask again
                        }
                        catch//catch any exception
                        {
                            Console.WriteLine("Please enter a valid operator.");//prompt user to enter a valid number
                        }
                    } while ((int)opInput >= 5 || (int)opInput <= 0);//only allow values of e-nums between 1-4
                }//end while

                //ASK FOR CONVERSION FACTOR VALUE
                prompt = true;//reset ask bool to true
                while (prompt)//while repeat = true
                {
                    try
                    {
                        //prompt user to provide input and assign their input in a variable
                        Console.Write("\nPlease enter the conversion factor value: ");
                        conversionFactor = double.Parse(Console.ReadLine());//assign the input to a variable
                        prompt = false;//change value of repeat flag to false as the user entered a valid input
                    }
                    catch//catch any exception
                    {
                        Console.WriteLine("Please enter a valid number.");//prompt user to enter a valid number
                    }
                }//end while

                //ASK FOR UNIT NUMBER
                prompt = true;//reset ask bool to true
                while (prompt)//while repeat = true
                {
                    do
                    {
                        try
                        {
                            //prompt user to provide input and assign their input in a variable
                            Console.Write("\nPlease enter the number of conversions you want: ");
                            unitInput = int.Parse(Console.ReadLine());//assign the input to a variable
                            prompt = false;//change value of repeat flag to false as the user entered a valid input
                        }
                        catch//catch any exception
                        {
                            Console.WriteLine("Please enter a whole number.");//prompt user to enter a valid number
                        }
                    } while (unitInput <= 0);//keep prompting if value entered is less than 0
                }//end while

                Converter userConvertor = new Converter(unitInput, 1, conversionFactor);//create instance of Converter class

                userConvertor.PrintTable(fromUnit, toUnit, opInput);//print table with all values given by user
            }//end if

            else//if user does not input "yes" to extend the program
            {
                Console.ForegroundColor = ConsoleColor.Yellow;//change text colour to yellow
                Console.WriteLine("\nYou did not enter \"yes\".");
            }//end else
        }//end run
    }//end class
}//end namespace
