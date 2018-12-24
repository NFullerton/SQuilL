using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQuilL {
   class WarningMessage {
      public WarningMessage(string title, string message) {
         MessageBox.Show(message, title, MessageBoxButtons.OK,
         MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
   }
}
