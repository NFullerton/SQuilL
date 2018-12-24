/*************************************************************\
|
|  SchemaToTables.cs started on 5/30 by Nicholas Fullerton
|
|  This class is an intermediate class which takes a filestream
|  and loads the tables within into the SQuilL application.
| 
\**************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SQuilL {
   class SchemaToTables {

      List<Table> tables;
      Stream stream;
      int index = -1;

      /*
       * .sch (schema) files of a specific format are supported: 
       * 
       * 
       * The schema name is the filename of the .sch file opened.
       * Table names within the schema are marked with a colon (:)
       * 
       * The following comma-delimited line is the column names of 
       * the table, and the comma-delimited lines following that
       * are the rows' data read until the next blank line. Then
       * the loader will search for the next table name and return
       * when it finds nothing more to load. An example schema with 
       * 2 tables:
       * 
       *    EMP_TABLE:
       *    EMP_ID,EMP_FIRSTNAME,EMP_LASTNAME
       *    1,John,Smith
       *    2,Jane,Doe
       *    
       *    EMP_PAY_INFO:
       *    EMP_ID,EMP_PAYRATE,EMP_PAYTYPE
       *    1,$35000,SALARIED
       *    2,$35000,SALARIED
       * 
       */

      // This constructor takes a file stream and creates a collection of tables
      // with the stream data and with the stream filename as the title:
      public SchemaToTables(Stream s, string name) {
         stream = s;
         tables = new List<Table>();         
         StreamReader reader = new StreamReader(stream);
         // HACK:
         STARTTABLE:
         
         // Read in the Schema Tables, terminate when there's nothing more to load:
         while (!reader.EndOfStream) {            
            string line = reader.ReadLine();
            if(line.Contains(":")) {
               index += 1;
               tables.Add(new Table(line.Trim(':')));
               string[] fields = reader.ReadLine().Split(',');
               List<string> columns = new List<string>(fields);
               tables[index].addColumns(columns);
               for(;;) {
                  string rowLine;
                  try {
                     rowLine = reader.ReadLine();
                     if(rowLine.Contains(",")) {
                        // Read the line as a row
                        List<string> row = new List<string>(rowLine.Split(','));
                        tables[index].addRow(row);
                     }
                     else
                        goto STARTTABLE;
                  }
                  catch(Exception ex) {return;};                 
               }              
            }
         }
      }

      // This is how you pull the created tables from the SchemaToTables object:
      public List<Table> getTables() {
         if (this.stream != null && this.tables != null) {
            return this.tables;
         }

         else {
            MessageBox.Show("Schema Load Error", "Tables could not be loaded from schema.");
            return null;
         }
      }
   }
}
