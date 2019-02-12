using System;
using System.Collections.Generic;


namespace PadawansTask6
{
    public static class NumberFinder
    {
        public static int? NextBiggerThan(int number)
        {
            List<int> allDigits = new List<int>();
            string strNumber = number.ToString();

            //building array from string
            for (int i = 0; i < strNumber.Length; i++)
            {
                allDigits.Add(Int32.Parse(strNumber[i].ToString()));
            }

            int? tempIndex = null;


            for (int i = allDigits.Count - 1; i >= 0; i--)
            {
                if (tempIndex != null)
                    break;
                for (int j = i-1; j >=0; j--)
                {
                    if (allDigits[i] > allDigits[j])
                    {
                        int tempDigit = allDigits[i];
                        allDigits[i] = allDigits[j];
                        allDigits[j] = tempDigit;
                        tempIndex = j;
                        break;
                    }

                }
            }

            //No changes => no largest integer
            if (tempIndex == null)
                return null;


            //sort digits after changed digit by ascending
            int lenghtForArray = allDigits.Count - ((int) tempIndex + 1);
            int[] digitsForSort = new int[lenghtForArray];
            allDigits.CopyTo((int)tempIndex + 1,digitsForSort, 0, lenghtForArray);
            Array.Sort(digitsForSort);

            //return sorted digits to source array
            int[] resultArray = allDigits.ToArray();
            digitsForSort.CopyTo(resultArray,(int)tempIndex + 1);


            string strResult = String.Empty;
            //building string from array
            foreach (var digit in resultArray)
            {
                strResult += digit;
            }

            int? result = null;
            try
            {
                result = int.Parse(strResult);
            }
            catch (Exception ex)
            {
                //value out of Int32 => number is not exits => return null
                result = null;
            }

            return result;

           
        }
    }
}
