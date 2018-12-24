/*************************************************************\
|
|  FileToTable.cs started on 5/30 by Nicholas Fullerton
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
   class FileToTable {


      Table table;
      Stream stream;

      /*
       * Both comma-delimited .csv and .txt files are supported 
       * here, but the csv/txt files must be of a specific format:
       * 
       * The table name is the name of the txt/csv file opened.
       * Fields are delimited by commas and rows are delimited by
       * newlines. The file to be opened must contain a number of 
       * fields which is the result of the number of fields in the
       * top row multiplied by the number of lines. The fields in
       * the top row are the header fields, they are the "column
       * names." 
       * 
       * A short example of a table with 3 columns named "EMP_ID",
       * "EMP_FIRSTNAME" and "EMP_LASTNAME" and two rows of records
       * is as follows:
       * 
       *    EMP_ID,EMP_FIRSTNAME,EMP_LASTNAME
       *    1,John,Smith
       *    2,Jane,Doe
       * 
       */

      // This constructor takes a file stream and creates a graphic table object
      // with the stream data and with the stream filename as the title:
      public FileToTable(Stream s, string name) {
         stream = s;
         table = new Table(name);
         StreamReader reader = new StreamReader(stream);

         // Get field (column) names:
         string line = reader.ReadLine();
         string[] fields = line.Split(',');
         List<string> columns = new List<string>(fields);
         table.addColumns(columns);
         
         while (!reader.EndOfStream) {
            List<string> row = new List<string>(reader.ReadLine().Split(','));
            table.addRow(row);
            
         }
      }

      // This is how you pull the created table from the FileToTable object:
      public Table getTable() {
         if (this.stream != null && this.table != null) {
            return this.table;
         } 
         
         else {
            var wm = new WarningMessage("Table Error", "Table could not be created.");
            return null;
         }
     }      
  }
}
