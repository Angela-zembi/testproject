using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace testApp
{
    class Program
    {
        class Test {
            List<string> list = new List<string>();
            string[] arr = new string[10];
            int[] mass = new int[5];
            int f1 = 0;
            int f2 = 1;

            public void Reader()
            {
                FileStream file1 = new FileStream("source.txt", FileMode.Open);
                StreamReader reader = new StreamReader(file1);

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    list.Add(line);
                    //Console.WriteLine(list[list.Count - 1]);
                }

                arr = list.ToArray();
                reader.Close();
            }

            public void FibonacciNum()
            {
                for (int i = 0; i < mass.Length; i++)
                {
                    int f = f1 + f2;
                    mass[i] = f;
                    f1 = f2;
                    f2 = f;
                }
            }

            public void Search() {
                FileStream file = new FileStream("output.txt", FileMode.Append);
                StreamWriter writer = new StreamWriter(file);
                for (int i =0; i<mass.Length;i++) {
                    for (int j=0; j<arr.Length;j++) {
                        string str = arr[j];
                        string el = Convert.ToString(mass[i]);
                        if (str.EndsWith(el))
                        {
                            char[] chars = str.ToCharArray();
                            //string rev = new StringBuilder(str).reverse().ToString();
                            for (int z = 0; z < chars.Length; z++)
                            {
                                for (int h = chars.Length - 1; h > z; h--)
                                {
                                    char tmp = chars[h];
                                    chars[h] = chars[h - 1];
                                    chars[h - 1] = tmp;
                                }
                            }
                            writer.WriteLine(new string(chars));
                        }
                    }
                }
                Console.WriteLine("Complite");
                writer.Close();
            }
        }
        
        
        static void Main(string[] args)
        {
            Test test1 = new Test();
            test1.Reader();
            test1.FibonacciNum();
            test1.Search();
            Console.ReadKey();
        }


    }
}
