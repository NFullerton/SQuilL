namespace SQuilL {
   partial class Table {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         this.components = new System.ComponentModel.Container();
         this.grid = new System.Windows.Forms.DataGridView();
         this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.renameTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.saveTableAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.closeAndDeleteTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
         this.contextMenu.SuspendLayout();
         this.SuspendLayout();
         // 
         // grid
         // 
         this.grid.AllowUserToAddRows = false;
         this.grid.AllowUserToOrderColumns = true;
         this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.grid.Enabled = false;
         this.grid.Location = new System.Drawing.Point(0, 0);
         this.grid.Name = "grid";
         this.grid.RowHeadersVisible = false;
         this.grid.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
         this.grid.Size = new System.Drawing.Size(384, 262);
         this.grid.TabIndex = 0;
         // 
         // contextMenu
         // 
         this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameTableToolStripMenuItem,
            this.saveTableAsToolStripMenuItem,
            this.closeAndDeleteTableToolStripMenuItem});
         this.contextMenu.Name = "contextMenuStrip1";
         this.contextMenu.ShowImageMargin = false;
         this.contextMenu.Size = new System.Drawing.Size(170, 92);
         // 
         // renameTableToolStripMenuItem
         // 
         this.renameTableToolStripMenuItem.Name = "renameTableToolStripMenuItem";
         this.renameTableToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
         this.renameTableToolStripMenuItem.Text = "Rename Table";
         this.renameTableToolStripMenuItem.Click += new System.EventHandler(this.renameTableToolStripMenuItem_Click);
         // 
         // saveTableAsToolStripMenuItem
         // 
         this.saveTableAsToolStripMenuItem.Name = "saveTableAsToolStripMenuItem";
         this.saveTableAsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
         this.saveTableAsToolStripMenuItem.Text = "Save Table As...";
         this.saveTableAsToolStripMenuItem.Click += new System.EventHandler(this.saveTableAsToolStripMenuItem_Click);
         // 
         // closeAndDeleteTableToolStripMenuItem
         // 
         this.closeAndDeleteTableToolStripMenuItem.Name = "closeAndDeleteTableToolStripMenuItem";
         this.closeAndDeleteTableToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
         this.closeAndDeleteTableToolStripMenuItem.Text = "Close and Delete Table";
         this.closeAndDeleteTableToolStripMenuItem.Click += new System.EventHandler(this.closeAndDeleteTableToolStripMenuItem_Click);
         // 
         // Table
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.ClientSize = new System.Drawing.Size(384, 262);
         this.ControlBox = false;
         this.Controls.Add(this.grid);
         this.DoubleBuffered = true;
         this.Name = "Table";
         this.ShowIcon = false;
         this.Load += new System.EventHandler(this.Table_Load);
         this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Table_MouseClick);
         ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
         this.contextMenu.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.DataGridView grid;
      private System.Windows.Forms.ContextMenuStrip contextMenu;
      private System.Windows.Forms.ToolStripMenuItem renameTableToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem saveTableAsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem closeAndDeleteTableToolStripMenuItem;
      
   }
}