//Dakota Cain
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1, num2, num3, num4;
            num1 = 51;
            num2 = 785;
            num3 = 83;
            num4 = 98;

            double result = Add(num1, num2);
            Console.WriteLine($"{num1} + {num2} = {result}");

            result = Subtract(num3, num4);
            Console.WriteLine($"{num3} + {num4} = {result}");

            double[] allTheNumbers = new double[5];
            allTheNumbers[0] = 1;
            allTheNumbers[1] = 4;
            allTheNumbers[2] = 5;
            allTheNumbers[3] = 10;
            allTheNumbers[4] = 20;

            result = Add(allTheNumbers);
            Console.WriteLine(result);

            DatabaseStuff();

            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val1">The left hand operand</param>
        /// <param name="val2">The right hand operand</param>
        /// <returns>Returns the sum of val1 and val2</returns>
        static double Add(double val1, double val2)
        {

            var sum = val1 + val2;

            return sum;
        }

        static double Add(double[] values)
        {
            double sum = 0;
            int counter = 0;

            while (counter < values.Length)
            {
                sum += values[counter];
                counter++;
            }


            return sum;
        }

        static double Subtract(double val1, double val2)
        {
            return val1 - val2;
        }

        static void DatabaseStuff()
        {
            string connectionString = "";
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT " +
                        "FirstName," +
                        "LastName," +
                        "Email," +
                        "Gender," +
                        "Address," +
                        "City," +
                        "State," +
                        "ZipCode" +
                        "FROM Customer";
                    using (var reader = commandExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader[0].ToDtring());
                        }
                    }
                }
            }
        }
    }
}
