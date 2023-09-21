using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Assessment_Tasks
{
    class Assessment_tasts
    {
        // static Dictionary<string , int> dict = new Dictionary<string,int>();
        const string rule = "the quick and brown fox jumps over the lazy dog";
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Your String To be Encoded");
            string query = Console.ReadLine();

            if (query == null)
                throw new NullReferenceException();
            else if (query == "")
                throw new ArgumentException();
            else
            {
                char[] charcheck = query.ToCharArray();
                string ans = "";
                for (int i = 0; i < charcheck.Length; i++)
                {
                    if (charcheck[i] == ' ')
                    {
                        //ans = ans.Remove(ans.Length - 1);
                        ans = ans.Substring(0, ans.Length - 1);
                        ans += '-';
                    }
                    else
                        ans += (query[charcheck[i] - 97] + ",");
                }
                ans = ans.Remove(ans.Length - 1);
            }
            char[] charArr = rule.ToLower().ToCharArray();
            string[] letters = new string[26];
            int word = 0, letter = 0;
            for (int i = 0; i < charArr.Length; i++)
            {
                if (charArr[i] == ' ')
                {
                    word++;
                    letter = 0;
                    continue;
                }
                if (letters[(int)charArr[i] - 97] == null)
                    letters[(int)charArr[i] - 97] = word.ToString() + letter.ToString();
                letter++;

            }


        }
    }
}