using Microsoft.Maui.Graphics;
using QrLib;
using System;
using System.Drawing;

namespace QrLibTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IQrGenerator qrGenerator = new QrGenerator();
            byte[] imgData = qrGenerator.FromText("Hello!");

            using (FileStream sw = new FileStream("test_qr.png", FileMode.OpenOrCreate))
            {
                sw.Write(imgData);
            }
            Console.WriteLine("Done! Check /bin/Debug/net6.0/test_qr.png");
        }
    }
}