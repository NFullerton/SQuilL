/*************************************************************\
|
|  SQLWorker.cs started on 5/25 by Nicholas Fullerton
|
|  This class represents the operation of a SQL statement on
|  one or more Tables. 
| 
\**************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQuilL {
   class SQLWorker {
      // Used to select all fields in a Table:
      const string wildcard = "*";
      // Tokenized SQL statement:
      List<string> tokens = new List<string>();
      // Columns to highlight:
      List<string> fieldTokens;
      // Tables on which to operate:
      List<string> tableTokens;
      // Key columns used for JOINS:
      List<string> keyTokens;
      // References to the tables themselves:
      List<Table> tables = new List<Table>();           

      // Result Table Types:
      bool isTable = false;
      bool product = false;
      bool naturalJoin = false;
      bool fullJoin = false;
      bool leftJoin = false;
      bool rightJoin = false;      

      // Constructor of keywords (s) acting on the available tables (t) and
      // will return a new table object if variable "it" is true:
      public SQLWorker(List<string> s, List<Table> t, bool it) {
         isTable = it;
         fieldTokens = new List<string>();
         tableTokens = new List<string>();
         keyTokens = new List<string>();
         // In C# the assignment operator creates references to lists,
         // this may be redundant but I'm doing so out of habit.
         tokens = s;
         tables = t;                  

         readFieldTokens();
         readTableAndKeyTokens();        
      }      

      // Retrieves Resulting Table from Query:
      public Table getTable(List<Table> tables) {
         Table t1 = new Table(), t2 = new Table();
         string type = tableType();
         foreach (Table t in tables) {
            if (t.getName() == tableTokens[0])
               t1 = t;
         }
         if (tableTokens.Count > 1) {
            foreach (Table t in tables) {
               if (t.getName() == tableTokens[1])
                  t2 = t;
            }
         }

         if(isTable && (type != "ERROR")) {           
               

               if (type == "PRODUCT") { 
                  var p = new Product(t1, t2);
                  var pr = new Projector(p.getProductTable(), fieldTokens);
                  return pr.getTable();
               }
               else if (type == "JOIN") { 
                  var j = new NaturalJoin(t1, t2, keyTokens);
                  var pr = new Projector(j.getTableJoin(), fieldTokens, keyTokens);
                  return pr.getTable();
               }
               else if (type == "FJOIN") { 
                  var fj = new FullJoin(t1, t2, keyTokens);
                  var pr = new Projector(fj.getTableJoin(), fieldTokens, keyTokens);
                  return pr.getTable();
               }
               else if (type == "LJOIN") { 
                  var lj = new LeftJoin(t1, t2, keyTokens);
                  var pr = new Projector(lj.getTableJoin(), fieldTokens, keyTokens);
                  return pr.getTable();
               }
               else if (type == "RJOIN") {
                  var rj = new RightJoin(t1, t2, keyTokens);
                  var pr = new Projector(rj.getTableJoin(), fieldTokens, keyTokens);
                  return pr.getTable();
               }
               else {
                  var pr = new Projector(tables[0], fieldTokens);
                  return pr.getTable();
               }             
                     
         }
         else
            return null;      
      }

      private string tableType() {
         if(product)
            return "PRODUCT";
         else if (naturalJoin)
            return "JOIN";
         else if (leftJoin)
            return "LJOIN";
         else if (rightJoin)
            return "RJOIN";
         else if (fullJoin)
            return "FJOIN";
         else
            return "ERROR";
      }

      // Helper to read to and from a string in a List, then put each token in another List:
      private void readFromAndTo(string start, string end, List<string> from, List<string> to) {
         int startIndex, endIndex;
         try {
            startIndex = from.IndexOf(start); endIndex = from.IndexOf(end);
         }
         catch (Exception ex) {
            var wm = new WarningMessage("SQL Statement Read Failed",
               "Error: Start and/or end keys not found in SQL Statement!");
            return;
         }
         for (int i = startIndex + 1; i < endIndex; i++)
            to.Add(from[i]);
      }

      private void readFieldTokens() {
         readFromAndTo("SELECT", "FROM", tokens, fieldTokens);
      }

      private void readTableAndKeyTokens() {
         // If the SQL statement is not a JOIN or PRODUCT:
         if (!tokens.Contains("JOIN") && !tokens.Contains("PRODUCT")) {
            readFromAndTo("FROM", ";", tokens, tableTokens);            

         }
         // If the statement is a JOIN:
         else if (tokens.Contains("JOIN") || tokens.Contains("PRODUCT")) {
            if (tokens.Contains("PRODUCT")) {
               product = true;
               readFromAndTo("FROM", "PRODUCT", tokens, tableTokens);
               readFromAndTo("PRODUCT", ";", tokens, tableTokens);
            }
            else {
               readFromAndTo("FROM", "JOIN", tokens, tableTokens);
               readFromAndTo("JOIN", "ON", tokens, tableTokens);
            }
            
            if (tokens.Contains("JOIN")) {
               int index = tokens.IndexOf("JOIN");
               if (tokens[index - 1] == "LEFT") {
                  leftJoin = true;
                  tableTokens.Remove("LEFT");
               }
               else if (tokens[index - 1] == "RIGHT") {
                  rightJoin = true;
                  tableTokens.Remove("RIGHT");
               }
               else if (tokens[index - 1] == "FULL") {
                  fullJoin = true;
                  tableTokens.Remove("FULL");
               }
               else {
                  naturalJoin = true;
               }
               readFromAndTo("ON", ";", tokens, keyTokens); keyTokens.Remove("=");
            }            
         }        
      }      
      
      //// If no JOINs, just select columns:
      //else {
      //   foreach (string ft in fieldTokens) {
      //      foreach (Table table in tables) {
      //         table.markColumnByName(ft);
      //      }
      //   }
      //}    

      //if (selectAll) {
      //   foreach (Table table in tables) {
      //      foreach (string tt in tableTokens) {
      //         if (table.getName() == tt)
      //            table.selectAll();
      //      }
      //   }
      //}
      

   // ------------- END METHODS --------------------*
   }
}
