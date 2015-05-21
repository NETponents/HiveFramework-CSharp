using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HiveFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            string temp_hive_vnum = "0.0.0.1";
            string settings_startscript = "";
            string settings_hostname = "";
            string settings_cuser = "";
            bool settings_silent = false;

            Console.WriteLine("HIVE Framework copyright 2015 NETponents software");
            Console.WriteLine("http://netponents.github.io/HiveFramework-CSharp");
            Console.WriteLine("This program is distributed under the MIT license");
            Console.WriteLine("Comercial use with this copy of this program is prohibited");
            Console.WriteLine("Project page: http://github.com/NETponents/HiveFramework-CSharp");
            Console.WriteLine("When adding an issue, reference @ARMmaster17 (Joshua Zenn)");
            cMgr.pString("core", "Parsing parameters");
            for (int i = 0; i < args.Length; i++)
            {
                if(args[i] == "-silent" || args[i] == "-s")
                {
                    settings_silent = true;
                }
                else if(args[i].StartsWith("-script:"))
                {
                    args[i] = args[i].Replace("-script", "");
                    settings_startscript = args[i];
                }
                else
                {
                    cMgr.pString("core", "Unknown arg encountered");
                }
            }
            cMgr.pString("core", "Starting up...");
            if(File.Exists(@"C:\hiveframework\settings.txt") != true)
            {
                if(settings_silent)
                {
                    cMgr.pString("core", "Silent mode is on, using default parameters");
                    settings_hostname = "H1N001";
                    settings_cuser = "local";
                }
                else
                {
                    Setup(ref settings_hostname, ref settings_cuser);
                }
            }
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            #region shellloop
            while(true)
            {
                string cmd = "";
                Console.Write(settings_cuser + "@" + settings_hostname + ": ");
                cmd = Console.ReadLine();
                if(cmd == "exit")
                {
                    break;
                }
                else if(cmd == "quit")
                {
                    break;
                }
                else if(cmd == "clear")
                {
                    Console.Clear();
                }
                else if(cmd.Split(' ')[0] == "start")
                {
                    // Start running the script
                }
            }
            #endregion
            Console.WriteLine("Press enter to quit...");
            Console.ReadLine();
            return;
        }
        static void Setup(ref string hname, ref string usr)
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Write("Enter a unique name for this node: ");
            hname = Console.ReadLine();
            Console.Write("Enter your username: ");
            usr = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("License");
            Console.WriteLine("========");
            Console.WriteLine("By using this program, you agree to the terms listed in LICENSE in the program directory. Since this is the free version, you also agree that this copy of the program MAY NOT be used for commercial or for-profit purposes.");
            Console.Write("Accept terms? [y/n]: ");
            char license = Console.ReadKey(false).KeyChar;
            if(license == 'y' || license == 'Y')
            {
                //Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                return;
            }
            //Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            return;
        }
    }
    class cMgr
    {
        public static void pString(string sender, string msg)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(sender.ToUpper());
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] ");
            Console.Write(msg);
            Console.Write("/n");
        }
    }
}
