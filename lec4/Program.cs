using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lec4
{
    public class Program
    {
        static void Main(string[] args)
        {
            // FileStream fOut = new FileStream("myText.txt", FileMode.Create);

            // Console.WriteLine((int)'A');
            // Console.WriteLine((int)'Z');

            // for (int i = 65; i <= 90; i++)
            // {
            //     fOut.WriteByte((byte)(char)i);
            // }
            // fOut.Close();

            // for (int i = 'A'; i <= 'Z'; i++)
            // {
            //     fOut.WriteByte((byte)i);
            // }
            // fOut.Close();

            // for (char i = 'A'; i <= 'Z'; i++)
            // {
            //     fOut.WriteByte((byte)i);
            //     // fOut.WriteByte((byte)' ');
            //     // fOut.WriteByte((byte)'\n');
            //     // fOut.WriteByte((byte)'\t');
            // }
            // fOut.Close();




            // FileStream fIn = new FileStream("myText.txt", FileMode.Open);

            // int i = fIn.ReadByte();
            // while (i != -1)
            // {
            //     Console.WriteLine((char)i);
            //     i = fIn.ReadByte();
            // }


            Console.Write("Enter File Name : ");
            string? fileName = Console.ReadLine();
            FileStream fOut = new FileStream(fileName!, FileMode.Open);
            FileStream fIn = new FileStream("copy_" + fileName!, FileMode.Create);


            int m = fOut.ReadByte();
            while (m != -1)
            {
                fIn.WriteByte((byte)m);
                m = fOut.ReadByte();
            }

            fOut.Close();
            fIn.Close();


        }
    }
}