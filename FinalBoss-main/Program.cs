using System;
using System.Windows.Forms;
using Telas;

namespace EncryptMe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new Login());
            Console.WriteLine("teste batatinha");
        }
    }
}
