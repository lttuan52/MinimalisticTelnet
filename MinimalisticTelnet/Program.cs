// minimalistic telnet implementation
// conceived by Tom Janssens on 2007/06/06  for codeproject
//
// http://www.corebvba.be

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace MinimalisticTelnet
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a new telnet connection to hostname "gobelijn" on port "23"
            TelnetConnection tc = new TelnetConnection("192.168.7.2", 23);

            //login with user "root",password "rootpassword", using a timeout of 100ms, and show server output
            string s = tc.Login("debian", "temppwd",100);
            //Thread.Sleep(5000);
            Console.Write(s);

            // server output should end with "$" or ">", otherwise the connection failed
            string prompt = s.TrimEnd();
            /* prompt = s.Substring(prompt.Length -1,1);
             if (prompt != "$" && prompt != ">" )
                 throw new Exception("Connection failed");

             prompt = "";*/

            // while connected
            string test;
                // display server output
                Console.Write(tc.Read());
                tc.WriteLine("pwd");                
                Console.Write(tc.Read());
                tc.WriteLine("cd evl/");
                Console.Write(tc.Read());
                tc.WriteLine("./run_Evlsrv.sh stdin");
                Console.Write(tc.Read());
                tc.WriteLine("openc");
                Console.Write(tc.Read());
                tc.WriteLine("set i 17260 1");
                Console.Write(tc.Read());
                tc.WriteLine("closec");
                Console.Write(tc.Read());
                tc.WriteLine("test ../letuan1/Function_test/C128/C128B/C128_B.bmp");
                Console.Write(tc.Read());
                tc.WriteLine("loop 0");
                test = tc.Read();
                Console.Write(tc.Read());            
        }
    }
}
