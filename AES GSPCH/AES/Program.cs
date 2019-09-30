using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AES___;
using System.IO;
using System.Threading;
using System.Diagnostics;



namespace AES
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            MultipleAES Cipher = new MultipleAES();
            byte[] mass = SetLength(20);
            File.WriteAllBytes("Ecrypted.aes_gspch",Cut(Cipher.EncryptOFB(mass, Encoding.UTF8.GetBytes("text")),20));
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",ts.Hours, ts.Minutes, ts.Seconds,ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }

        static private byte[] SetLength(int len)
        {
            byte[] mass = new byte[len];
            Random random = new Random();
            random.NextBytes(mass);
            return mass;
        }

        static private byte[] Cut(byte[] mass, int len)
        {
            byte[] mass2 = new byte[len];
            for (int i = 0; i < len; i++)
            {
                mass2[i] = mass[i];
            }
            return mass2;
        }

    }
}
