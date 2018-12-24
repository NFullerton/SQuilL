/*************************************************************\
|
|  LeftJoin.cs started on 6/7 by Nicholas Fullerton
|
|  This class represents a LEFT OUTER JOIN SQL operation
| 
\**************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQuilL {
   class LeftJoin {
      Table t1, t2, productTable, newTable;
      string key1, key2;

      public LeftJoin(Table table1, Table table2, List<string> keys) {
         t1 = table1; t2 = table2;
         key1 = keys[0];
         key2 = keys[1];

         Product product = new Product(t1, t2);
         productTable = product.getProductTable();
         List<string> columns = new List<string>();
         List<DataGridViewRow> rows = new List<DataGridViewRow>();
         newTable = new Table();

         foreach (DataGridViewColumn col in productTable.getGrid().Columns) {
            columns.Add(col.Name);
         }

         // Strip rows with no key matches, then (ha)
         // add ones from the Right table with no key matches, 
         // then strip dupes and resize table:
         while (!stripNonMatch(productTable)) { }
         addNoLeftKeyMatch();
         while(stripDuplicateRows(productTable)) { } 
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

      // This method adds rows from the left table,
      // in which there is no key match on the right table:
      public void addNoLeftKeyMatch() {
         List<string> t2Keys = new List<string>();
         for (int i = 0; i < t2.getGrid().Rows.Count; i++) {
            t2Keys.Add(t2.getGrid().Rows[i].Cells[key2].Value.ToString());
         }

         for (int i = 0; i < t1.getGrid().Rows.Count; i++) {
            bool match = false;

            foreach (string key in t2Keys) {
               if (t1.getGrid().Rows[i].Cells[key1].Value.ToString() ==
                  key)
                  match = true;
            }

            if (!match) {

               List<string> partialRow = new List<string>();
               for (int k = 0; k < t1.getGrid().Columns.Count; k++) {
                  partialRow.Add(t1.getGrid().Rows[i].Cells[k].Value.ToString());
               }
               for (int n = 0; n < t2.getGrid().Columns.Count; n++) {
                  partialRow.Add("");
               }
               productTable.addRow(partialRow);

            }
            
         }         
      }

      // Strips duplicate rows from Table:
      public bool stripDuplicateRows(Table t) {
         int i, j;
         int rowCount = t.getGrid().Rows.Count;
                
         for (i = 0; i < rowCount-1; i++) {
            List<string> row1 = new List<string>();  
            foreach (DataGridViewCell cell1 in t.getGrid().Rows[i].Cells) {
               row1.Add(cell1.Value.ToString());
            }
            for (j = (i+1); j < rowCount; j++) {
               List<string> row2 = new List<string>();
               foreach (DataGridViewCell cell2 in t.getGrid().Rows[j].Cells) {
                  row2.Add(cell2.Value.ToString());
               }
               if (listsEqual(row1, row2)) {                  
                  t.getGrid().Rows.RemoveAt(j);
                  return true;
               }
            }                      
         }
         return false;
      }

      // This method determine whether or not two lists are duplicates:
      public bool listsEqual(List<string> l1, List<string> l2) {         
         if (l1.Count != l2.Count)
            return false;
         for (int i = 0; i < l1.Count; i++) {
            if (l1[i] != l2[i])
               return false;
         }
         return true;
      }

      // This method determines whether or not a row has a key match:
      public bool keydataMatch(DataGridViewRow row, string k1, string k2) {
         if (k1 == k2) {
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
         for (int i = 0; i < t.getGrid().Columns.Count; i++) {
            if (t.getGrid().Columns[i].Name == k1) {
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