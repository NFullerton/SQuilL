/*************************************************************\
|
|  TableToFile.cs started on 6/7 by Nicholas Fullerton
|
|  This class converts a table of the user's choice to a text
|  file to facilitate saving for later use.
| 
\**************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQuilL {
   class TableToFile {

      // This represents the text to be written to the file:
      string text = "";

      public TableToFile(Table t) {          
         // Columns:
         for (int i = 0; i < t.getGrid().Columns.Count; i++) {
            // In a csv-style format we don't want a comma 
            // after the last row/column entry:
            if (i < t.getGrid().Columns.Count - 1)
               text += t.getGrid().Columns[i].Name + ",";
            else
               text += t.getGrid().Columns[i].Name + "\n";
         }
         // Rows:
         for (int i = 0; i < t.getGrid().Rows.Count; i++) {
            for (int j = 0; j < t.getGrid().Columns.Count; j++) {
               // In a csv-style format we don't want a comma 
               // after the last row/column entry:
               if (j < t.getGrid().Columns.Count - 1)
                  text += t.getGrid().Rows[i].Cells[j].Value + ",";
               else
                  text += t.getGrid().Rows[i].Cells[j].Value + "\n";
            }
         }               
      }

      public string getFileText() {
         return text;
      }
   }
}