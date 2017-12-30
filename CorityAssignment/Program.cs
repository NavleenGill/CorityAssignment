using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorityAssignment
{
    class Program
    {

        private static String  path = "C:\\Users\\Owner\\Documents\\Visual Studio 2015\\Projects\\CorityAssignment\\expenses.txt";
        private int n; //number of participants in each camping trip
        private int p; //number of receipts/charges for each participant

        private void readInputWriteOutput()
        {
            TextReader tr = File.OpenText(path);
            n = int.Parse(tr.ReadLine()); //read the value for number of participants in each camping trip
            
            while (n != 0)
            {
                ArrayList arr = new ArrayList(); //use collection to store the sum of charges for each participant
                for (int i = 0; i < n; i++)
                { 
                    double sum = 0.0;
                    p = int.Parse(tr.ReadLine()); //read the value for number of charges spent by each participant

                    for (int j = 0; j < p; j++)
                    {
                        double y = double.Parse(tr.ReadLine());
                        sum = sum + y; //sum of charges
                    }//end of for j loop
                    
                    arr.Add(sum); //add the sum of charges to the arrayList
                }//end of for i loop

                double total = 0.0; //total of charges by all participants

                foreach(double value in arr)
                {
                    total = total + value;
                }

                double equalShare = total / n; //equal share of money

                foreach(double value in arr)
                {
                    if(value > equalShare)
                        File.AppendAllText(path + ".out", "($" + Math.Round((value - equalShare), 2) + ")" + Environment.NewLine);
                    else
                        File.AppendAllText(path + ".out", "$" + Math.Round((equalShare - value), 2) + Environment.NewLine);
                }

                File.AppendAllText(path + ".out", Environment.NewLine);//insert blank line after end of each camping trip
                n = int.Parse(tr.ReadLine()); //read the value for number of participants in next camping trip

            }//end of while loop
            tr.Close();
        }//end of getInput() method
         

        public static void Main(string[] args)
        {
            Program ob = new Program();
            ob.readInputWriteOutput();

        }//end of main method
    }//end of Program class
}//end of namespace
