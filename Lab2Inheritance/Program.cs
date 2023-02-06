using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Lab2Inheritance.Entities;

namespace Lab2Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "employees.txt";

            string[] lines;

            lines = File.ReadAllLines(path);

            List<Employee> employees = new List<Employee>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(':');

                string id = parts[0];

                string name = parts[1];

                string firstDigit;

                firstDigit = id.Substring(0, 1);

                // if (firstDigit == "0" || firstDigit == "4") Or

                int firstDigitNum = int.Parse(firstDigit);

                if (firstDigitNum >= 0 && firstDigitNum <= 4)
                {
                    //Salaried
                    double salary = double.Parse(parts[7]);

                    Salaried salaried;

                    salaried = new Salaried(id, name, salary);

                    employees.Add(salaried);
                }
                else if (firstDigitNum >= 5 && firstDigitNum <= 7)
                {
                    //Part Time
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);


                    PartTime partTime = new PartTime(id, name, rate, hours);
                    employees.Add(partTime);


                }
                else if (firstDigitNum >=8 && firstDigitNum <=9)
                {
                    //Wage
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);

                    Wages wages = new Wages(id, name, rate, hours);
                    employees.Add(wages);
                }

                double weeklyPaySum = 0;

                foreach (Employee employee in employees)
                {
                    if (employee is PartTime partTime)
                    {
                        double pay = partTime.Pay;
                        weeklyPaySum += pay;
                    }
                    else if (employee is Wages wages)
                    {
                        double pay = wages.Pay;
                    }

                    else if (employee is Salaried salaried)
                    {
                        double pay = salaried.Pay;

                        weeklyPaySum += pay;
                    }
                }

                double averageWeeklyPay = weeklyPaySum / employees.Count;
                Console.WriteLine("Average weekly pay: " + averageWeeklyPay);

                foreach (Employee employee in employees)
                {
                    if (employee is Wages wages)
                    {
                        double pay = wages.Pay;
                    }
                }
            }
        }
    }
}
