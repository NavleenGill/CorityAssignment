using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorityAssignment
{
    class Program
    {

        String path = "C:\\Users\\Owner\\Documents\\Visual Studio 2015\\Projects\\CorityAssignment\\expenses.txt";
        private int n; //number of participants in the camping trip
        private int p; //number of receipts/charges for each participant

        private void getInput()
        {
            double equalShare = calcEqualShare();
            TextReader tr = File.OpenText(path);
            n = int.Parse(tr.ReadLine()); //read first line from input file
            while (n != 0)
            {
                
                for (int i = 0; i < n; i++)
                {
                    double sum = 0.0;
                    p = int.Parse(tr.ReadLine()); //read second line from input file

                    for (int j = 0; j < p; j++)
                    {
                        double y = double.Parse(tr.ReadLine());
                        sum = sum + y;
                    }
                    if (sum > equalShare)
                    {
                        File.AppendAllText(path + ".out", Environment.NewLine + "($" + Math.Round((sum - equalShare), 2) + ")");
                    }
                    else
                    {
                        File.AppendAllText(path + ".out", Environment.NewLine + "$" + Math.Round((equalShare - sum), 2));
                    }

                }

                n = int.Parse(tr.ReadLine());
            }
        }

        private double calcEqualShare()
        {
            TextReader tr = File.OpenText(path);
            n = int.Parse(tr.ReadLine()); //read first line from input file
            
            double sum = 0.0;
            if (n != 0)
            {
                for (int i = 0; i < n; i++)
                {  
                    p = int.Parse(tr.ReadLine()); //read second line from input file
                    for (int j = 0; j < p; j++)
                    {
                        double y = double.Parse(tr.ReadLine());
                        sum = sum + y;
                    }
                }

            }
            tr.Close();
            return sum / 3;
        }
         

        public static void Main(string[] args)
        {
            Program ob = new Program();
            ob.getInput();

        }
    }
}
