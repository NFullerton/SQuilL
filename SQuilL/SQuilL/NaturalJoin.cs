/*************************************************************\
|
|  NaturalJoin.cs started on 6/7 by Nicholas Fullerton
|
|  This class represents a natural JOIN SQL operation
| 
\**************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQuilL {
   class NaturalJoin {
      Table t1, t2, productTable, newTable;
      string key1, key2;

      public NaturalJoin(Table table1, Table table2, List<string> keys) {
         t1 = table1; t2 = table2;
         key1 = keys[0];
         key2 = keys[1];

         Product product = new Product(t1, t2);
         productTable = product.getProductTable();
         List<string> columns = new List<string>();
         List<DataGridViewRow> rows = new List<DataGridViewRow>();
         newTable = new Table();

         foreach(DataGridViewColumn col in productTable.getGrid().Columns) {
            columns.Add(col.Name);
         }

         // Strip all rows in which the keys values don't match, 
         // resize resulting table:
         while (!stripNonMatch(productTable)) { }
         productTable.resizeFit();       
         
      }

      // This method strips from a table all rows in which the key
      // values do not match:
      public bool stripNonMatch(Table t) {
         for (int i = 0; i < t.getGrid().Rows.Count; i++) {
            if (!keydataMatch(t.getGrid().Rows[i], key1, key2)) {
               // If the row data in both keys doesn't match...                
               t.getGrid().Rows.RemoveAt(i);
               return false;
            }
         }
         return true;
      }

      // This method determines whether or not a row has a key match:
      public bool keydataMatch(DataGridViewRow row, string k1, string k2) {
         if(k1 == k2) {
            if (row.Cells[namesToIndices(productTable, k1, k2)[0]].Value.ToString() == 
                row.Cells[namesToIndices(productTable, k1, k2)[1]].Value.ToString()) {
               return true;
            }
            else {
               return false;
            }
         }
         else {
            if (row.Cells[k1].Value.ToString() == row.Cells[k2].Value.ToString()) {
               return true;
            }
            else {
               return false;
            }
         }
      }

      // This is for when both keys are the same name:
      private List<int> namesToIndices(Table t, string k1, string k2) {
         List<int> indices = new List<int>();
         for(int i = 0; i < t.getGrid().Columns.Count; i++) {
            if(t.getGrid().Columns[i].Name == k1) {
               indices.Add(i);
            }
         }
         for (int i = t.getGrid().Columns.Count - 1; i > indices[0]; i--) {
            if (t.getGrid().Columns[i].Name == k2) {
               indices.Add(i);
            }
         }
         return indices;
      }

      // Pull the resulting table from the object instance:
      public Table getTableJoin() {
         return productTable;
      }

   //----------------END METHODS---------------------------*
   }
}
