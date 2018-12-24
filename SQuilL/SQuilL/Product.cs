/*************************************************************\
|
|  Product.cs started on 6/5 by Nicholas Fullerton
|
|  This class returns a table which represents the 
|  Cartesian Product of two tables.
| 
\**************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace SQuilL {
   class Product {

      List<string> addedColumns;
      Table t1; Table t2; Table newTable;
      int t1Width, t1Height, t2Width, t2Height, width, height;

      public Product(Table table1, Table table2) {
         t1 = table1; t2 = table2;
      }

      // Returns Cartesian Product of 2 tables as a new Table:
      public Table getProductTable() {

         newTable = new Table();
         addedColumns = new List<string>();
         List<string> blankRow = new List<string>();
         t1Width = t1.getGrid().Columns.Count; t1Height = t1.getGrid().Rows.Count;
         t2Width = t2.getGrid().Columns.Count; t2Height = t2.getGrid().Rows.Count;

         width = t1Width + t2Width; height = t1Height * t2Height;                

         newTable.getGrid().Width = width;
         newTable.getGrid().Height = height;        

         for (int i = 0; i < t1Width; i++) {
            addedColumns.Add(t1.getGrid().Columns[i].Name);
         }
         for (int i = 0; i < t2Width; i++) {
            addedColumns.Add(t2.getGrid().Columns[i].Name);
         }

         newTable.addColumns(addedColumns);

         for (int i = 0; i < width; i++)
            blankRow.Add("");
         for (int i = 0; i < height; i++)
            newTable.addRow(blankRow);         

         // The following produces the PRODUCT of two tables:
         copyInto();
         return newTable;
      }

      // Helper for creating Cartesian Product:
      private void copyInto() {
         // This section copies the first table into newTable, then sorts the entered
         // Table:
         int i, j, n;
         for (i = 0; i < t1Width; i++) {
            for (j = 0; j < height; j++) {
               for (n = 0; n < t2Height; n++) {                  
                  newTable.setCellData(i, j, t1.getCellData(i, (j + n) % t1Height));
               }                               
            }            
         }
         newTable.getGrid().Sort(newTable.getGrid().Columns[0], ListSortDirection.Ascending);
      
         // This section copies the second Table into newTable:         
         for (i = 0; i < t2Width; i++) {
            for (j = 0; j < height; j++) {
               for (n = 0; n < t2Height; n++) {                  
                  newTable.setCellData(i + t1Width, j, t2.getCellData(i, (j + n) % t2Height));
               }               
            }
         }      
      }
   
   // ----------------- END METHODS -----------------------*
   }
}
