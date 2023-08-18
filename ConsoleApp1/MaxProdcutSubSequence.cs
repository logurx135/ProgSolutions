using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class MaxProdcutSubSequence
    {
        public static long GetMaxProduct(long[] inputArr )
        {
            long result = 1;

            int howManyNegatives = 0;
            long lowestNegative =long.MinValue;
            for (int i = 0; i < inputArr.Length; i++)
            {
                result *= inputArr[i];
                if(inputArr[i] < 0 )
                {
                    howManyNegatives++;
                    if(inputArr[i] > lowestNegative )
                        lowestNegative = inputArr[i];
                }
            }

            if( howManyNegatives % 2 != 0) {
                result /= lowestNegative;
            }

            return result;
        }
    }
}
