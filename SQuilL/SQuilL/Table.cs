/*************************************************************\
|
|  Table.cs started on 5/30 by Nicholas Fullerton
|
|  This class is a graphical representation of an SQL Table
|  as a child MDI Form containing only a DataGridView to 
|  display data.
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
using System.Runtime.InteropServices;

namespace SQuilL {
   public partial class Table : Form {

      // The name of the table
      string name = "";        

      // Default Constructor:
      public Table() {
         InitializeComponent();        
         
      }

      

      // Constructor with Table Name:
      public Table(string s) {
         InitializeComponent();
         name = s;
         this.Text = name;
         clearAll();         
      }

      // Accessor for Table name:
      public string getName() {
         return this.name;
      }

      // Mutator for Table name:
      public void renameTable(String newName) {
         name = newName;
         this.Text = newName;         
      }

      public void addRow(List<string> row) {
         DataGridViewRow r = new DataGridViewRow();
         foreach(string s in row) {
            r.Cells.Add(new DataGridViewTextBoxCell {Value = s});
         }
      
         this.grid.Rows.Add(r);         
         resizeFit();
      }

      public void addRows(List<DataGridViewRow> rows) {
         
         foreach (DataGridViewRow row in rows) {
            this.grid.Rows.Add(row);
         }
         
         resizeFit();
      }
      
      public void addColumns(List<string> columns) {
         foreach(string s in columns)
            this.grid.Columns.Add(s, s);
         
         resizeFit();
      }

      public void addColumns(List<DataGridViewColumn> columns) {
         foreach (DataGridViewColumn col in columns)
            this.grid.Columns.Add(col);
         
         resizeFit();
      }     

      // Returns width of DataGridView, helper for autosizing Tables:
      public int calculateGridWidth() {
         int width = 0;
         foreach (DataGridViewColumn col in grid.Columns)
            width += col.Width;         
         
         return width;
      }
     
      // Returns height of DataGridView, helper for autosizing Tables:
      public int calculateGridHeight() {
         int height = 0;
         height += this.grid.ColumnHeadersHeight;
         foreach (DataGridViewRow row in grid.Rows)
            height += row.Height;
         
         return height;
      }

      // This is the method which fits the table to the data in the DataGridView:
      public void resizeFit() {
         this.grid.AutoResizeColumns();
         this.ClientSize = new Size(calculateGridWidth(), calculateGridHeight());         
         // This is needed to resize the grid to...it's own size?!
         this.grid.Size = this.ClientSize;         
      }

      // This is a ham-handed way to get the DataGridView from a Table:
      public DataGridView getGrid() {
         return this.grid;
      }

      // Shows "Right-click" menu when Table is right-clicked:
      private void Table_MouseClick(object sender, MouseEventArgs e) {
         if (e.Button == MouseButtons.Right) {            
               contextMenu.Show(Cursor.Position);
         }
      }
      
      // This selects all cells in a Table:
      public void selectAll() {
         this.grid.SelectAll();
      }

      // This clears all cell selections in a Table:
      public void clearAll() {
         this.grid.ClearSelection();
      }

      // Context Menu: Rename Table...
      private void renameTableToolStripMenuItem_Click(object sender, EventArgs e) {
         RenameForm rn = new RenameForm(this);
      }

      // Table Load Event:
      private void Table_Load(object sender, EventArgs e) {         
         this.clearAll();         
      }

      // Select/Highlight/Mark Cell:
      public void MarkCell(int x, int y) {
         this.grid.CurrentCell = this.grid[x,y];
         this.grid.CurrentCell.Selected = true;
      }

      // Select/Highlight/Mark row from index:
      public void markRowByIndex(int index) {
         this.grid.CurrentCell = this.grid[0, index];
         for(int i = 0; i < this.grid.Rows[0].Cells.Count; i++) {
            this.grid[i, index].Selected = true;          
         }
      }

      // Select/Highlight/Mark Column from index:
      public void markColumnByIndex(int index) {
         this.grid.CurrentCell = this.grid[index, 0];
         for (int i = 0; i < this.grid.Rows.Count; i++) {            
            this.grid[index, i].Selected = true;
         }
      }      

      // Select/Highlight/Mark Column from column name:
      public void markColumnByName(string name) {         
         int index;
         // HACK:
         try { 
            index = this.grid.Columns[name].Index;           
            for (int i = 0; i < this.grid.Rows.Count; i++) {
               this.grid[index, i].Selected = true;
            }
         }
         catch(Exception ex) { return; }    
      }

      // Accesses Cell data
      public string getCellData(int x, int y) {
         string data = "";
         try { data = this.grid[x, y].Value.ToString(); }
         catch (Exception ex) {
            MessageBox.Show("Error: Grid Cell Data at " + x.ToString() +
               ", " + y.ToString() + " could not be accessed.");            
         }
         return data;
      }

      // Mutates Cell data
      public void setCellData(int x, int y, string data) {         
         try { this.grid[x, y].Value = data; }
         catch (Exception ex) {
            MessageBox.Show("Error: Grid Cell Data could not be mutated.");
         }         
      }

      // Context Menu: Save Table As...
      private void saveTableAsToolStripMenuItem_Click(object sender, EventArgs e) {
         saveTableAs();
      }

      private void closeAndDeleteTableToolStripMenuItem_Click(object sender, EventArgs e) {
         if (MessageBox.Show("Do you want to save your Table?",
            "Save Schema?", MessageBoxButtons.YesNo,
            MessageBoxIcon.Exclamation) == DialogResult.Yes) {
            saveTableAs();
         }

         else {
            SQuilL parent = (SQuilL)this.MdiParent;
            parent.removeTable(this);
            this.Dispose();            

         }
      }

      private void saveTableAs() {
         TableToFile saveTable = new TableToFile(this);
         string saveText = saveTable.getFileText();
         SaveFileDialog saveFile = new SaveFileDialog();
         saveFile.FileName = this.getName() + ".csv";
         saveFile.Filter = "CSV SQuilL table File | *.csv";
         if (saveFile.ShowDialog() == DialogResult.OK) {
            File.WriteAllText(saveFile.FileName, saveText);
         }
      }
      
      
   
   
   
   
   
   
   
   // *----------------- END METHODS ---------------------------------*
   
   }
}
