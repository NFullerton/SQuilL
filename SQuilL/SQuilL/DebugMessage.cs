/*************************************************************\
|
|  DebugMessage.cs started on 5/25 by Nicholas Fullerton
|
|  This class is basically a customized MessageBox wrapper
|  used to aid in debugging/application development. Its use
|  is not necessary for operation.
| 
\**************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQuilL {
   class DebugMessage {
      
      // string m: message.
      // string s or list l: The variable content to show.
      
      public DebugMessage(string m, string s) {
         MessageBox.Show(s, "Debug Message(string): " + m);
      }

      public DebugMessage(string m, List<string> l) {
         string temp = "";
         foreach (string s in l)
            temp += "\"" + s + "\"" + " ";
         MessageBox.Show(temp, "Debug Message(list): " + m);
      }   
   }
}
