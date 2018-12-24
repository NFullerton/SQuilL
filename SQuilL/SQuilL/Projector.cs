/*************************************************************\
|
|  Projector.cs started on 6/10/2016 by Nicholas Fullerton
|
|  This class is a helper class for projecting portions of
|  Tables.
| 
\**************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQuilL {
   class Projector {

      Table table;
      List<string> cols;

      // For PRODUCT (no keys): 
      public Projector(Table t, List<string> columns) {
         
         table = t;
         cols = columns;

         if (!columns.Contains("*")) {
            while (strippingForwards()) { } 
            while (strippingBackwards()) { }
         }
      }

      public Projector(Table t, List<string> columns, List<string> keys) {         
         table = t;
         cols = columns;         

         if (!columns.Contains("*")) {
            while (strippingForwards()) { }
            while (strippingBackwards()) { }
         }
         
      }

      private bool strippingForwards() {
         foreach (DataGridViewColumn col in table.getGrid().Columns) {
            if (!cols.Contains(col.Name.ToString())) {
               table.getGrid().Columns.Remove(col);
               return true;
            }
            else
               return false;
         }
         return false;
      }

      private bool strippingBackwards() {
         for (int i = table.getGrid().Columns.Count; i-- >= 0;) {
            if (!cols.Contains(table.getGrid().Columns[i].Name.ToString())) {
               table.getGrid().Columns.Remove(table.getGrid().Columns[i]);
               return true;
            }
            else
               return false;
         }
         return false;
      }
      
      public Table getTable() {
         table.resizeFit();
         return table;
      }
   }
}
