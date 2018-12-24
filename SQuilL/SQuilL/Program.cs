/*************************************************************\
|
|  Program.cs generated automatically upon Project Creation
|
|  This class represents the main entry point of the application.
| 
\**************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQuilL {
   static class Program {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main() {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new SQuilL());
      }
   }
}
