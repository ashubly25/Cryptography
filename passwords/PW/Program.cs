using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace PW
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Success!");
            int s = 0;
            while (s<1)
            {
                Console.Write(">>");
                string crypt = Console.ReadLine();
                if (crypt.Contains("encrypt"))
                {
                    Console.WriteLine("Encrypting...");
                    crypt = crypt.Substring(8);
                    Console.WriteLine(crypt);
                    string encrypt = crypt.Trim();
                    encrypt = Crypt.Encrypt(encrypt, true);
                    encrypt = Crypt.Encrypt(encrypt, true);
                    encrypt = Crypt.Encrypt(encrypt, true);
                    encrypt = Crypt.Encrypt(encrypt, true);
                    encrypt = Crypt.Encrypt(encrypt, true);
                    encrypt = Crypt.Encrypt(encrypt, true);
                    encrypt = Crypt.Encrypt(encrypt, true);
                    encrypt = Crypt.Encrypt(encrypt, true);
                    encrypt = Crypt.Encrypt(encrypt, true);
                    encrypt = Crypt.Encrypt(encrypt, true);
                    Console.WriteLine(encrypt);
                    Console.WriteLine("What service is this for (i.e. Facebook, Twitter, Instagram, etc.)?");
                    string service = Console.ReadLine();
                    Console.WriteLine("Saving...");
                    string path = @".\" + service + ".txt";
                    if(!File.Exists(path))
                    {
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine(encrypt);
                        }	
                    }
                    Console.WriteLine("Success!");
                }
                else if (crypt.Contains("decrypt"))
                {
                    crypt = crypt.Substring(8);
                    crypt = crypt.Trim();
                    try
                    {
                        if (crypt.Length < 15)
                        {
                            Console.WriteLine("Decrypting your " + crypt + " password...");
                            System.IO.StreamReader file = new System.IO.StreamReader(@"./" + crypt + ".txt");
                            string line;
                            while ((line = file.ReadLine()) != null)
                            {
                                crypt = line;
                            }
                            file.Close();
                            Console.WriteLine(crypt);
                        }
                        crypt = Crypt.Decrypt(crypt, true);
                        crypt = Crypt.Decrypt(crypt, true);
                        crypt = Crypt.Decrypt(crypt, true);
                        crypt = Crypt.Decrypt(crypt, true);
                        crypt = Crypt.Decrypt(crypt, true);
                        crypt = Crypt.Decrypt(crypt, true);
                        crypt = Crypt.Decrypt(crypt, true);
                        crypt = Crypt.Decrypt(crypt, true);
                        crypt = Crypt.Decrypt(crypt, true);
                        crypt = Crypt.Decrypt(crypt, true);
                        Console.WriteLine("\n"+crypt);
                        Console.WriteLine("Copying text to clipboard...");
                        Clipboard.SetText(crypt);
                        Console.WriteLine("Password copied to clipboard! Paste it where you would like to use your password");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Doesn't look like that exists in our database... Sorry...");
                        Console.WriteLine(e);
                    }
                }
                else if (crypt.Equals("end"))
                {
                    Console.WriteLine("Thanks, bye");
                    Environment.Exit(3000);
                }
            }
        }
    }
}
