/*************************************************************\
|
|  RenameForm.cs started on 6/7 by Nicholas Fullerton
|
|  This class represents a MessageBox-style intermediate
|  form to allow the user to rename tables.
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

namespace SQuilL {
   public partial class RenameForm : Form {

      Table t;

      public RenameForm(Table table) {
         InitializeComponent();
         t = table;
         this.StartPosition = FormStartPosition.CenterScreen;
         this.Show();
      }      

      private void setButton_Click(object sender, EventArgs e) {
         if (this.textBox.Text == "")
            MessageBox.Show("Please enter a vaid Table Name!");
         else {
            t.renameTable(this.textBox.Text);
            // FIXME: hook into SQuilL to update table data
            SQuilL parent = (SQuilL)t.MdiParent;
            parent.refreshFields();
            this.Close();
         }
      }

      private void cancelButton_Click(object sender, EventArgs e) {
         this.Close();
      }
   }
}
