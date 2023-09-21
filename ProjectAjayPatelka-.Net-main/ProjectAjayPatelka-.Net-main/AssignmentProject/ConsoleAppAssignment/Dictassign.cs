using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Assessment_Tasks
{
    class Hackathon1_Other
    {
        static Dictionary<string, string> codes = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            const string rule = "the quick and brown fox jumps over the lazy dog";
            Console.WriteLine("Please Enter Your String To be Encoded");
            string query = Console.ReadLine();
            Console.WriteLine(EncodeString(rule.Split(' '), query.ToLower()));
        }
        private static string EncodeString(string[] code, string query)
        {
            if (query == null)
                throw new NullReferenceException();
            else if (string.IsNullOrEmpty(query))
                throw new ArgumentException();
            else
            {
                for (int i = 0; i < code.Length; i++)
                    for (int j = 0; j < code[i].Length; j++)
                        if (codes.ContainsKey(code[i][j].ToString()) == false)
                            codes.Add(code[i][j].ToString(), i.ToString() + j.ToString());



                char[] strChar = query.ToCharArray();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < strChar.Length; i++)
                {
                    if (strChar[i] == ' ')
                    {
                        sb.Remove(sb.Length - 1, 1);
                        sb.Append('-');
                    }
                    else
                        sb.Append(codes[strChar[i].ToString()] + ",");
                }
                sb.Remove(sb.Length - 1, 1);
                return sb.ToString();
            }
        }
    }
}