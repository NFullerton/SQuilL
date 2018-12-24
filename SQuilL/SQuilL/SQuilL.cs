/*************************************************************\
|
|  SQuilL.cs started on 5/17 by Nicholas Fullerton
|
|  This class represents the main class, the MDI parent
|  window form, for the entire SQuiL application.
| 
\**************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SQuilL {
   public partial class SQuilL : Form {

      List<Table> tables = new List<Table>();
      List<string> fields = new List<string>();
      int tablesSelected = 0;
      int fieldsSelected = 0;
      int queryCount = 0;
      int schemaCount = 0;
      bool tableLoaded = false;
             
      private void incFieldsSelected() {
         fieldsSelected += 1;         
      }
      
      public SQuilL() {
         InitializeComponent();
         fieldsBox.SelectedIndex = 0;
         tablesBox.SelectedIndex = 0;
         setToolTips();
         awaitSelect();         
      }       

      // Fades in the Main window when the program loads. Neat!
      private void SQuilL_Load(object sender, EventArgs e) {
         loadFade();
      }

      // This loads the column names of all the tables into "fields":
      public void refreshFields() {
         if (tables.Count > 0)
            tableLoaded = true;
         else
            tableLoaded = false;
         clearBoxes();

         foreach(Table t in tables) {          

            if(!tablesBox.Items.Contains(t.getName()))
               tablesBox.Items.Add(t.getName());
            
            foreach(DataGridViewColumn col in t.getGrid().Columns) {
               if(!fieldsBox.Items.Contains(col.Name))
                  fieldsBox.Items.Add(col.Name);
            }            
         }
      }

      // Allows Tables to remove themselves:
      public void removeTable(Table t) {
         tables.Remove(t);
         clearBoxes();
         refreshFields();
         awaitSelect();
      }

      // Helper to reset controls:
      private void clearBoxes() {
         fieldsBox.Items.Clear();
         fieldsBox.Items.Add("( Select Column...)");
         fieldsBox.SelectedIndex = 0;
         tablesBox.Items.Clear();         
         tablesBox.Items.Add("( Select Table...)");
         tablesBox.SelectedIndex = 0;         
      }

      // Menu: File -> "Quit":
      private void quitToolStripMenuItem_Click(object sender, EventArgs e) {
         if (MessageBox.Show("Do you want to save your schema?",
            "Save Schema?", MessageBoxButtons.YesNo,
            MessageBoxIcon.Exclamation) == DialogResult.Yes) {
               saveSchemaAs();
         } 
         
         else
            Application.Exit();      
      }

      // Menu: File -> "Statement window":
      private void toolStripMenuItem2_Click(object sender, EventArgs e) {
         if (toolStripMenuItem2.Checked == true) {
            toolStripMenuItem2.Checked = false;
            stmtPanel.Visible = false;
            stmtPanel.Enabled = false;
         } 
         
         else {
            toolStripMenuItem2.Checked = true;
            stmtPanel.Visible = true;            
            stmtPanel.Enabled = true;
         }        
      }

      // HACK: hides statement panel so the user can
      // see the Tables loaded:
      private void hideStatementPanel() {
         stmtPanel.Visible = false;
         toolStripMenuItem2.Checked = false;
      }
      
      // Menu -> Import Table...
      // Import table by choosing .txt/.csv files of a specific format:
      private void importTableToolStripMenuItem_Click(object sender, EventArgs e) {
         Stream stream = null;
         // Open the File Select Dialog to choose Table file:
         OpenFileDialog openFile = new OpenFileDialog();
         openFile.InitialDirectory = "C:\\";
         openFile.Filter = "txt files(*.txt)|*.txt|csv files(*.csv)|*.csv";
         openFile.FilterIndex = 2;
         openFile.RestoreDirectory = true;
         // If user selects a File:
         if (openFile.ShowDialog() == DialogResult.OK) {
            try {
               if ((stream = openFile.OpenFile()) != null) {
                  using (stream) {
                     string tableName = Path.GetFileNameWithoutExtension(openFile.FileName);
                     // Detect Duplicate Table Before Load:
                     foreach(Table t in tables) {
                        if(tableName == t.getName() || tableName == t.getName().ToUpper()  
                           || tableName.ToUpper() == t.getName()) {
                           var wm = new WarningMessage("Duplicate Table",
                              "A table with this name is already loaded!");
                           return;
                        }
                     }
                     FileToTable ft = new FileToTable(stream, tableName);
                     Table newTable = ft.getTable();
                     newTable.MdiParent = this;
                     this.tables.Add(newTable);
                     // Populate Tables combobox with Table Names:
                     this.tablesBox.Items.Add(newTable.getName());
                     // Populate Tables combobox with Table Names:
                     refreshFields();
                     hideStatementPanel();
                     newTable.Show();       
                     
                  }
               }
            } 
            catch (Exception ex) {
               var wm = new WarningMessage("Error Opening File",
                  "Exception: " + ex.ToString());               
            }
         }
      }

      // Increments the query count by 1:
      public int getIncQueryCount() {
         queryCount += 1;
         return queryCount;
      }

      // Resets the query count:
      public void resetQueryCount() {
         queryCount = 0;
      }

      public int getIncSchemaCount() {
         schemaCount += 1;
         return schemaCount;
      }

      // FIXME - This is where the action happens - when the button is clicked, 
      // the statement in the statement field is parsed and the Tables
      // are highlighted appropriately"
      private void parseButton_Click(object sender, EventArgs e) {
         stmtField.Text += ";";

         // FIXME All code for button operation should go in a try block here:
         

         foreach (Table table in tables) {
            table.clearAll();
         }

         Tokenizer t = new Tokenizer(stmtField.Text);
         SQLWorker worker = new SQLWorker(t.getTokens(), this.tables, 
            isQueryTableChck.Checked);

         if(isQueryTableChck.Checked) {
            Table newTable = worker.getTable(tables);
            tables.Add(newTable);
            newTable.MdiParent = this;
            newTable.renameTable("QUERY " + getIncQueryCount().ToString());
            refreshFields();
            hideStatementPanel();
            newTable.Show();
         }
      }

      // The following button clicks add SQL keywords to the 
      // statement window:
      private void selectButton_Click(object sender, EventArgs e) {
         stmtField.Text += "SELECT ";
         selectClick();
      }

      private void fromButton_Click(object sender, EventArgs e) {
         stmtField.Text += "FROM ";
         if (fieldsSelected == 0)
            incFieldsSelected();
         fromClick();
      }

      private void innerJoinButton_Click(object sender, EventArgs e) {
         stmtField.Text += "JOIN ";
         tableOperationsClicked();
      }

      private void leftJoinButton_Click(object sender, EventArgs e) {
         stmtField.Text += "LEFT JOIN ";
         tableOperationsClicked();
      }

      private void rightJoinButton_Click(object sender, EventArgs e) {
         stmtField.Text += "RIGHT JOIN ";
         tableOperationsClicked();
      }

      private void button1_Click(object sender, EventArgs e) {
         stmtField.Text += "FULL JOIN ";
         tableOperationsClicked();
      }

      private void wcButton_Click(object sender, EventArgs e) {
         stmtField.Text += "* ";
         incFieldsSelected();
         wcClick();
      }

      private void productButton_Click(object sender, EventArgs e) {
         stmtField.Text += "PRODUCT ";
         tableOperationsClicked();
      }

      private void onButton_Click(object sender, EventArgs e) {
         stmtField.Text += "ON ";         
         onClick();
      }

      private void equalsButton_Click(object sender, EventArgs e) {
         stmtField.Text += "= ";         
         equalsClick();
         incFieldsSelected();
      }

      // Fields (columns/keys) selection dropdown:
      private void fieldsBox_SelectedIndexChanged(object sender, EventArgs e) {
         // FIXME: add commas when more than 1 is selected!
         if (fieldsBox.SelectedIndex != 0)
            stmtField.Text += fieldsBox.SelectedItem + " "; 
         fieldsBox.SelectedIndex = 0;

         if (fieldsSelected == 0) {
            fieldsClick();
           
         }
         else if (fieldsSelected == 1) {            
            keyField1Click();
            
         }
         else if (fieldsSelected == 2) {
            keyField2Click();
         }
         
      }

      // Tables seletion dropdown:
      private void tablesBox_SelectedIndexChanged(object sender, EventArgs e) {
         // FIXME: add commas when more than 1 is selected!
         if(tablesBox.SelectedIndex != 0)
            stmtField.Text += tablesBox.SelectedItem + " ";
         tablesBox.SelectedIndex = 0;
         if (tablesSelected == 0) {
            tablesSelected += 1;
            firstTableClicked();         
         }
         else if (tablesSelected == 1) {
            secondTableClicked();
         }
      }

      // Memu: File -> Import Schema...
      private void importSchemaMenuItem_Click(object sender, EventArgs e) {
         Stream stream = null;
         // Open the File Select Dialog to choose Table file:
         OpenFileDialog openFile = new OpenFileDialog();
         openFile.InitialDirectory = "C:\\";
         openFile.Filter = "SQuilL Schema files(*.sch)|*.sch";
         openFile.FilterIndex = 2;
         openFile.RestoreDirectory = true;
         // If user selects a File:
         if (openFile.ShowDialog() == DialogResult.OK) {
            try {
               if ((stream = openFile.OpenFile()) != null) {
                  using (stream) {
                     string schemaName = Path.GetFileNameWithoutExtension(openFile.FileName);
                     // Detect Duplicate Table Before Load:                     
                     foreach(Table t in tables)
                        tables.Remove(t);
                     
                     SchemaToTables ft = new SchemaToTables(stream, schemaName);
                     foreach(Table t in ft.getTables()) {
                        t.MdiParent = this;
                        this.tables.Add(t);
                        // Populate Tables combobox with Table Names:
                        this.tablesBox.Items.Add(t.getName());
                        // Populate Tables combobox with Table Names:
                        refreshFields();
                        hideStatementPanel();
                        t.Show();       
                     }
                  }
               }
            } 
            catch (Exception ex) {
               var wm = new WarningMessage("Error Opening File",
                  "Exception: " + ex.ToString());               
            }
         }
      }

      // Menu: File -> Save Schema As...
      private void saveSchemaAsToolStripMenuItem_Click(object sender, EventArgs e) {
         saveSchemaAs();
      }

      // Helper method to save Schemas:
      private void saveSchemaAs() {
         SchemaToFile saveSchema = new SchemaToFile(tables);
         string saveText = saveSchema.getFileText();
         SaveFileDialog saveFile = new SaveFileDialog();
         saveFile.FileName = "Schema" + getIncSchemaCount().ToString() + ".sch";
         saveFile.Filter = "SQuilL Schema File | *.sch";
         if (saveFile.ShowDialog() == DialogResult.OK) {
            File.WriteAllText(saveFile.FileName, saveText);
         }
      }

      // Helper Method for Load fade-in:
      private void loadFade() {
         int millis = 1000;
         int steps = 40;
         timer.Interval = millis / steps;
         int currentStep = 0;
         timer.Tick += (arg1, arg2) =>
         {
            this.Opacity = ((double)currentStep) / steps;
            currentStep++;

            if (currentStep >= steps) {
               timer.Stop();
               timer.Dispose();
            }
         };
         timer.Start();
      }

      // Menu: File -> New Schema...
      private void newSchemaToolStripMenuItem_Click(object sender, EventArgs e) {
         if (MessageBox.Show("Do you want to save your current schema?",
            "Save Schema?", MessageBoxButtons.YesNo,
            MessageBoxIcon.Exclamation) == DialogResult.Yes) {
            saveSchemaAs();
         }
         // Clear active tables amd reset query count:
         foreach(Table table in tables) {
            table.Dispose();
         }
         tables.Clear();
         resetQueryCount();
         refreshFields();
      }

      // Clears Statement Field:
      private void clearButton_Click(object sender, EventArgs e) {
         stmtField.Text = "";
         foreach (Table t in tables) {
            t.clearAll();
         }
         awaitSelect();
      }

      // The following methods listed until setToolTips serve to 
      // guide the user input to greatly reduce the likelihood of 
      // invalid input:
      
      // The starting state:
      private void awaitSelect() {
         selectButton.Enabled = true; wcButton.Enabled = false;
         fromButton.Enabled = false; productButton.Enabled = false; 
         innerJoinButton.Enabled = false; fullJoinButton.Enabled = false; 
         leftJoinButton.Enabled = false; rightJoinButton.Enabled = false; 
         onButton.Enabled = false; equalsButton.Enabled = false;         
         fieldsBox.Enabled = false; tablesBox.Enabled = false;
         parseButton.Enabled = false;
         tablesSelected = 0; fieldsSelected = 0;
      }

      // SELECT is clicked, columns and '*' are enabled:
      private void selectClick() {
         fieldsBox.Enabled = true;
         wcButton.Enabled = true;
         selectButton.Enabled = false;
      }

      // * is clicked, FROM is enabled:
      private void wcClick() {
         fromButton.Enabled = true;
         fieldsBox.Enabled = false;
         wcButton.Enabled = false;
         
      }
      // Fields are clicked (selected):
      private void fieldsClick() {
         wcButton.Enabled = false;
         fromButton.Enabled = true;
      }

      // FROM is clicked, table selection is enabled:
      private void fromClick() {
         tablesBox.Enabled = true; wcButton.Enabled = false;
         fieldsBox.Enabled = false; fromButton.Enabled = false;
      }

      // First Table Clicked:
      private void firstTableClicked() {
         tablesBox.Enabled = false; setTableOperations(true);
      }

      // Enable/disable 2-table Operations:
      private void setTableOperations(bool value) {
         productButton.Enabled = value; innerJoinButton.Enabled = value;
         fullJoinButton.Enabled = value; leftJoinButton.Enabled = value;
         rightJoinButton.Enabled = value;
      }

      // JOINS or PRODUCT clicked:
      private void tableOperationsClicked() {
         setTableOperations(false);
         tablesBox.Enabled = true;
         parseButton.Enabled = true;
      }

      // When user selects second table:
      private void secondTableClicked() {
         if(stmtField.Text.Contains("JOIN")) {
            onButton.Enabled = true;
         }
         else if(stmtField.Text.Contains("PRODUCT")) {
            parseButton.Enabled = true;
         }
         tablesBox.Enabled = false;
      }

      // When user clicks ON:
      private void onClick() {
         onButton.Enabled = false;
         fieldsBox.Enabled = true;
      }

      // When user clicks first key field:
      private void keyField1Click() {
         fieldsBox.Enabled = false;
         equalsButton.Enabled = true;
      }

      // When user clicks "=" button:
      private void equalsClick() {
         equalsButton.Enabled = false;
         fieldsBox.Enabled = true;
      }

      // When user clicks second key field:
      private void keyField2Click() {
         fieldsBox.Enabled = false;
         parseButton.Enabled = true;
      }
          
      // sets ToolTips:
      private void setToolTips() {
         selectTT.SetToolTip(selectButton, "SELECT chooses which columns from the \n" +
            "table(s) you want to include in the result.\nUse the wildcard (*) to select all columns.");
         fromTT.SetToolTip(fromButton, "FROM chooses the tables involved in \n" +
            "your query.");
         ijTT.SetToolTip(innerJoinButton, "An inner join, JOIN, chooses only the rows\n" +
            "from 2 tables in which the key values from 1 table match the key values from the other.");
         fjTT.SetToolTip(fullJoinButton, "A FULL JOIN chooses only the rows\n" +
            "from 2 tables in which the key values from 1 table\n match the key values from the other\n"
            + "as well as the rows from both tables in which the key values do not match."); 
         ljTT.SetToolTip(leftJoinButton, "A LEFT JOIN chooses only the rows\n" +
            "from 2 tables in which the key values from 1 table\n match the key values from the other\n"
            + "as well as the rows from the first(left) table in which the key values do not match.");         
         rjTT.SetToolTip(rightJoinButton, "A RIGHT JOIN chooses only the rows\n" +
            "from 2 tables in which the key values from 1 table\n match the key values from the other\n"
            + "as well as the rows from the second(right) table in which the key values do not match.");
         fieldsTT.SetToolTip(fieldsBox, "Use this dropdown to select the fields(columns) \n" +
            "you want to include in the result.\nUse the wildcard (*) to select all columns.");
         tablesTT.SetToolTip(tablesBox, "Use this dropdown to select the tables \n" +
            "you want to include in the result.");
         ckTT.SetToolTip(isQueryTableChck, "Check this box if you want your query \n" +
            "Displayed as a new Table.\nUncheck the box if you want to see your query\n" +
            "as marking your current table(s)");
         fieldTT.SetToolTip(stmtField, "This text field shows your statement. You \n" +
            "Cannot type anything here, you must use the buttons and dropdowns\n" +
            "to enter your statement. If you make a mistake, use the \"Clear\" button\n" +
            "to clear the statement and enter a new statement.");
         parseTT.SetToolTip(parseButton, "Click this button to execute your statement.\n");
         clearTT.SetToolTip(clearButton, "Use this button to enter another statement if\n" +
            "you make a mistake entering your statement.");
         wcTT.SetToolTip(wcButton, "The wildcard character (*) selects all columns \n" +
            "in your table or result.");
         productTT.SetToolTip(productButton, "The PRODUCT of two tables is the table \n" +
            "which results from each row from the first(left) table being paired\n" +
            "with all rows from the second (right) table.");
         onTT.SetToolTip(onButton, "The ON keyword is followed by the first table's key(column) name \n" +
            ", then equals(=), then the second table's key(column) name.");
         equalsTT.SetToolTip(equalsButton, "The equals character (=) is used to separate the \n" +
            "first table's key from the second table's key.");
         
      }

      


      

      
   // ------------- END METHODS ------------------*
   }
}
