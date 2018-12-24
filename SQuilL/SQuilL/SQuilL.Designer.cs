namespace SQuilL {
   partial class SQuilL {
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQuilL));
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.newSchemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.importSchemaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.importTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.saveSchemaAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
         this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
         this.timer = new System.Windows.Forms.Timer(this.components);
         this.stmtPanel = new System.Windows.Forms.Panel();
         this.groupBox = new System.Windows.Forms.GroupBox();
         this.equalsButton = new System.Windows.Forms.Button();
         this.onButton = new System.Windows.Forms.Button();
         this.productButton = new System.Windows.Forms.Button();
         this.wcButton = new System.Windows.Forms.Button();
         this.clearButton = new System.Windows.Forms.Button();
         this.isQueryTableChck = new System.Windows.Forms.CheckBox();
         this.rightJoinButton = new System.Windows.Forms.Button();
         this.fullJoinButton = new System.Windows.Forms.Button();
         this.tablesBox = new System.Windows.Forms.ComboBox();
         this.fieldsBox = new System.Windows.Forms.ComboBox();
         this.innerJoinButton = new System.Windows.Forms.Button();
         this.selectButton = new System.Windows.Forms.Button();
         this.leftJoinButton = new System.Windows.Forms.Button();
         this.fromButton = new System.Windows.Forms.Button();
         this.stmtField = new System.Windows.Forms.TextBox();
         this.parseButton = new System.Windows.Forms.Button();
         this.selectTT = new System.Windows.Forms.ToolTip(this.components);
         this.fromTT = new System.Windows.Forms.ToolTip(this.components);
         this.ijTT = new System.Windows.Forms.ToolTip(this.components);
         this.fjTT = new System.Windows.Forms.ToolTip(this.components);
         this.ljTT = new System.Windows.Forms.ToolTip(this.components);
         this.rjTT = new System.Windows.Forms.ToolTip(this.components);
         this.fieldsTT = new System.Windows.Forms.ToolTip(this.components);
         this.tablesTT = new System.Windows.Forms.ToolTip(this.components);
         this.ckTT = new System.Windows.Forms.ToolTip(this.components);
         this.fieldTT = new System.Windows.Forms.ToolTip(this.components);
         this.parseTT = new System.Windows.Forms.ToolTip(this.components);
         this.clearTT = new System.Windows.Forms.ToolTip(this.components);
         this.wcTT = new System.Windows.Forms.ToolTip(this.components);
         this.productTT = new System.Windows.Forms.ToolTip(this.components);
         this.onTT = new System.Windows.Forms.ToolTip(this.components);
         this.equalsTT = new System.Windows.Forms.ToolTip(this.components);
         this.menuStrip1.SuspendLayout();
         this.stmtPanel.SuspendLayout();
         this.groupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
         this.menuStrip1.TabIndex = 3;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSchemaToolStripMenuItem,
            this.importSchemaMenuItem,
            this.importTableToolStripMenuItem,
            this.saveSchemaAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.quitToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "File";
         // 
         // newSchemaToolStripMenuItem
         // 
         this.newSchemaToolStripMenuItem.Name = "newSchemaToolStripMenuItem";
         this.newSchemaToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
         this.newSchemaToolStripMenuItem.Text = "New Schema...";
         this.newSchemaToolStripMenuItem.Click += new System.EventHandler(this.newSchemaToolStripMenuItem_Click);
         // 
         // importSchemaMenuItem
         // 
         this.importSchemaMenuItem.Name = "importSchemaMenuItem";
         this.importSchemaMenuItem.Size = new System.Drawing.Size(168, 22);
         this.importSchemaMenuItem.Text = "Import Schema...";
         this.importSchemaMenuItem.Click += new System.EventHandler(this.importSchemaMenuItem_Click);
         // 
         // importTableToolStripMenuItem
         // 
         this.importTableToolStripMenuItem.Name = "importTableToolStripMenuItem";
         this.importTableToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
         this.importTableToolStripMenuItem.Text = "Import Table...";
         this.importTableToolStripMenuItem.Click += new System.EventHandler(this.importTableToolStripMenuItem_Click);
         // 
         // saveSchemaAsToolStripMenuItem
         // 
         this.saveSchemaAsToolStripMenuItem.Name = "saveSchemaAsToolStripMenuItem";
         this.saveSchemaAsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
         this.saveSchemaAsToolStripMenuItem.Text = "Save Schema As...";
         this.saveSchemaAsToolStripMenuItem.Click += new System.EventHandler(this.saveSchemaAsToolStripMenuItem_Click);
         // 
         // toolStripMenuItem1
         // 
         this.toolStripMenuItem1.Name = "toolStripMenuItem1";
         this.toolStripMenuItem1.Size = new System.Drawing.Size(165, 6);
         // 
         // quitToolStripMenuItem
         // 
         this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
         this.quitToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
         this.quitToolStripMenuItem.Text = "Quit";
         this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
         // 
         // viewToolStripMenuItem
         // 
         this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
         this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
         this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this.viewToolStripMenuItem.Text = "View";
         // 
         // toolStripMenuItem2
         // 
         this.toolStripMenuItem2.Checked = true;
         this.toolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
         this.toolStripMenuItem2.Name = "toolStripMenuItem2";
         this.toolStripMenuItem2.Size = new System.Drawing.Size(175, 22);
         this.toolStripMenuItem2.Text = "Statement Window";
         this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
         // 
         // stmtPanel
         // 
         this.stmtPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.stmtPanel.Controls.Add(this.groupBox);
         this.stmtPanel.Location = new System.Drawing.Point(0, 24);
         this.stmtPanel.Name = "stmtPanel";
         this.stmtPanel.Size = new System.Drawing.Size(1008, 150);
         this.stmtPanel.TabIndex = 5;
         // 
         // groupBox
         // 
         this.groupBox.Controls.Add(this.equalsButton);
         this.groupBox.Controls.Add(this.onButton);
         this.groupBox.Controls.Add(this.productButton);
         this.groupBox.Controls.Add(this.wcButton);
         this.groupBox.Controls.Add(this.clearButton);
         this.groupBox.Controls.Add(this.isQueryTableChck);
         this.groupBox.Controls.Add(this.rightJoinButton);
         this.groupBox.Controls.Add(this.fullJoinButton);
         this.groupBox.Controls.Add(this.tablesBox);
         this.groupBox.Controls.Add(this.fieldsBox);
         this.groupBox.Controls.Add(this.innerJoinButton);
         this.groupBox.Controls.Add(this.selectButton);
         this.groupBox.Controls.Add(this.leftJoinButton);
         this.groupBox.Controls.Add(this.fromButton);
         this.groupBox.Controls.Add(this.stmtField);
         this.groupBox.Controls.Add(this.parseButton);
         this.groupBox.Location = new System.Drawing.Point(12, 3);
         this.groupBox.Name = "groupBox";
         this.groupBox.Size = new System.Drawing.Size(971, 144);
         this.groupBox.TabIndex = 3;
         this.groupBox.TabStop = false;
         this.groupBox.Text = "Statement Entry: ";
         // 
         // equalsButton
         // 
         this.equalsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.equalsButton.Location = new System.Drawing.Point(315, 78);
         this.equalsButton.Name = "equalsButton";
         this.equalsButton.Size = new System.Drawing.Size(75, 23);
         this.equalsButton.TabIndex = 16;
         this.equalsButton.Text = "=";
         this.equalsButton.UseVisualStyleBackColor = true;
         this.equalsButton.Click += new System.EventHandler(this.equalsButton_Click);
         // 
         // onButton
         // 
         this.onButton.Location = new System.Drawing.Point(205, 78);
         this.onButton.Name = "onButton";
         this.onButton.Size = new System.Drawing.Size(75, 23);
         this.onButton.TabIndex = 15;
         this.onButton.Text = "ON";
         this.onButton.UseVisualStyleBackColor = true;
         this.onButton.Click += new System.EventHandler(this.onButton_Click);
         // 
         // productButton
         // 
         this.productButton.Location = new System.Drawing.Point(98, 49);
         this.productButton.Name = "productButton";
         this.productButton.Size = new System.Drawing.Size(87, 23);
         this.productButton.TabIndex = 14;
         this.productButton.Text = "PRODUCT";
         this.productButton.UseVisualStyleBackColor = true;
         this.productButton.Click += new System.EventHandler(this.productButton_Click);
         // 
         // wcButton
         // 
         this.wcButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.wcButton.Location = new System.Drawing.Point(98, 21);
         this.wcButton.Name = "wcButton";
         this.wcButton.Size = new System.Drawing.Size(87, 23);
         this.wcButton.TabIndex = 13;
         this.wcButton.Text = "*";
         this.wcButton.UseVisualStyleBackColor = true;
         this.wcButton.Click += new System.EventHandler(this.wcButton_Click);
         // 
         // clearButton
         // 
         this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.clearButton.Location = new System.Drawing.Point(843, 88);
         this.clearButton.Name = "clearButton";
         this.clearButton.Size = new System.Drawing.Size(113, 41);
         this.clearButton.TabIndex = 12;
         this.clearButton.Text = "Clear Statement";
         this.clearButton.UseVisualStyleBackColor = true;
         this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
         // 
         // isQueryTableChck
         // 
         this.isQueryTableChck.AutoSize = true;
         this.isQueryTableChck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.isQueryTableChck.Checked = true;
         this.isQueryTableChck.CheckState = System.Windows.Forms.CheckState.Checked;
         this.isQueryTableChck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.isQueryTableChck.Location = new System.Drawing.Point(214, 109);
         this.isQueryTableChck.Name = "isQueryTableChck";
         this.isQueryTableChck.Size = new System.Drawing.Size(176, 19);
         this.isQueryTableChck.TabIndex = 11;
         this.isQueryTableChck.Text = "Show Query As New Table: ";
         this.isQueryTableChck.UseVisualStyleBackColor = true;
         // 
         // rightJoinButton
         // 
         this.rightJoinButton.Location = new System.Drawing.Point(98, 107);
         this.rightJoinButton.Name = "rightJoinButton";
         this.rightJoinButton.Size = new System.Drawing.Size(87, 23);
         this.rightJoinButton.TabIndex = 10;
         this.rightJoinButton.Text = "RIGHT JOIN";
         this.rightJoinButton.UseVisualStyleBackColor = true;
         this.rightJoinButton.Click += new System.EventHandler(this.rightJoinButton_Click);
         // 
         // fullJoinButton
         // 
         this.fullJoinButton.Location = new System.Drawing.Point(98, 78);
         this.fullJoinButton.Name = "fullJoinButton";
         this.fullJoinButton.Size = new System.Drawing.Size(87, 23);
         this.fullJoinButton.TabIndex = 9;
         this.fullJoinButton.Text = "FULL JOIN";
         this.fullJoinButton.UseVisualStyleBackColor = true;
         this.fullJoinButton.Click += new System.EventHandler(this.button1_Click);
         // 
         // tablesBox
         // 
         this.tablesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.tablesBox.FormattingEnabled = true;
         this.tablesBox.Items.AddRange(new object[] {
            "( Select Table...)"});
         this.tablesBox.Location = new System.Drawing.Point(205, 51);
         this.tablesBox.Name = "tablesBox";
         this.tablesBox.Size = new System.Drawing.Size(185, 21);
         this.tablesBox.TabIndex = 8;
         this.tablesBox.SelectedIndexChanged += new System.EventHandler(this.tablesBox_SelectedIndexChanged);
         // 
         // fieldsBox
         // 
         this.fieldsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.fieldsBox.FormattingEnabled = true;
         this.fieldsBox.Items.AddRange(new object[] {
            "( Select Column...)"});
         this.fieldsBox.Location = new System.Drawing.Point(205, 19);
         this.fieldsBox.Name = "fieldsBox";
         this.fieldsBox.Size = new System.Drawing.Size(185, 21);
         this.fieldsBox.TabIndex = 7;
         this.fieldsBox.SelectedIndexChanged += new System.EventHandler(this.fieldsBox_SelectedIndexChanged);
         // 
         // innerJoinButton
         // 
         this.innerJoinButton.Location = new System.Drawing.Point(6, 78);
         this.innerJoinButton.Name = "innerJoinButton";
         this.innerJoinButton.Size = new System.Drawing.Size(86, 23);
         this.innerJoinButton.TabIndex = 6;
         this.innerJoinButton.Text = "INNER JOIN";
         this.innerJoinButton.UseVisualStyleBackColor = true;
         this.innerJoinButton.Click += new System.EventHandler(this.innerJoinButton_Click);
         // 
         // selectButton
         // 
         this.selectButton.Location = new System.Drawing.Point(6, 20);
         this.selectButton.Name = "selectButton";
         this.selectButton.Size = new System.Drawing.Size(86, 23);
         this.selectButton.TabIndex = 5;
         this.selectButton.Text = "SELECT";
         this.selectButton.UseVisualStyleBackColor = true;
         this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
         // 
         // leftJoinButton
         // 
         this.leftJoinButton.Location = new System.Drawing.Point(6, 107);
         this.leftJoinButton.Name = "leftJoinButton";
         this.leftJoinButton.Size = new System.Drawing.Size(86, 23);
         this.leftJoinButton.TabIndex = 4;
         this.leftJoinButton.Text = "LEFT JOIN";
         this.leftJoinButton.UseVisualStyleBackColor = true;
         this.leftJoinButton.Click += new System.EventHandler(this.leftJoinButton_Click);
         // 
         // fromButton
         // 
         this.fromButton.Location = new System.Drawing.Point(6, 49);
         this.fromButton.Name = "fromButton";
         this.fromButton.Size = new System.Drawing.Size(86, 23);
         this.fromButton.TabIndex = 3;
         this.fromButton.Text = "FROM";
         this.fromButton.UseVisualStyleBackColor = true;
         this.fromButton.Click += new System.EventHandler(this.fromButton_Click);
         // 
         // stmtField
         // 
         this.stmtField.Enabled = false;
         this.stmtField.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.stmtField.Location = new System.Drawing.Point(410, 20);
         this.stmtField.Multiline = true;
         this.stmtField.Name = "stmtField";
         this.stmtField.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.stmtField.Size = new System.Drawing.Size(412, 108);
         this.stmtField.TabIndex = 1;
         // 
         // parseButton
         // 
         this.parseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.parseButton.Location = new System.Drawing.Point(843, 20);
         this.parseButton.Name = "parseButton";
         this.parseButton.Size = new System.Drawing.Size(113, 41);
         this.parseButton.TabIndex = 2;
         this.parseButton.Text = "Execute!";
         this.parseButton.UseVisualStyleBackColor = true;
         this.parseButton.Click += new System.EventHandler(this.parseButton_Click);
         // 
         // SQuilL
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1008, 730);
         this.Controls.Add(this.stmtPanel);
         this.Controls.Add(this.menuStrip1);
         this.DoubleBuffered = true;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.IsMdiContainer = true;
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "SQuilL";
         this.Opacity = 0D;
         this.Text = "SQuilL";
         this.Load += new System.EventHandler(this.SQuilL_Load);
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.stmtPanel.ResumeLayout(false);
         this.groupBox.ResumeLayout(false);
         this.groupBox.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem newSchemaToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem importTableToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem saveSchemaAsToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
      private System.Windows.Forms.Timer timer;
      private System.Windows.Forms.Panel stmtPanel;
      private System.Windows.Forms.TextBox stmtField;
      private System.Windows.Forms.Button parseButton;
      private System.Windows.Forms.GroupBox groupBox;
      private System.Windows.Forms.Button rightJoinButton;
      private System.Windows.Forms.Button fullJoinButton;
      private System.Windows.Forms.ComboBox tablesBox;
      private System.Windows.Forms.ComboBox fieldsBox;
      private System.Windows.Forms.Button innerJoinButton;
      private System.Windows.Forms.Button selectButton;
      private System.Windows.Forms.Button leftJoinButton;
      private System.Windows.Forms.Button fromButton;
      private System.Windows.Forms.ToolStripMenuItem importSchemaMenuItem;
      private System.Windows.Forms.CheckBox isQueryTableChck;
      private System.Windows.Forms.Button clearButton;
      private System.Windows.Forms.ToolTip selectTT;
      private System.Windows.Forms.ToolTip fromTT;
      private System.Windows.Forms.ToolTip ijTT;
      private System.Windows.Forms.ToolTip fjTT;
      private System.Windows.Forms.ToolTip ljTT;
      private System.Windows.Forms.ToolTip rjTT;
      private System.Windows.Forms.ToolTip fieldsTT;
      private System.Windows.Forms.ToolTip tablesTT;
      private System.Windows.Forms.ToolTip ckTT;
      private System.Windows.Forms.ToolTip fieldTT;
      private System.Windows.Forms.ToolTip parseTT;
      private System.Windows.Forms.ToolTip clearTT;
      private System.Windows.Forms.ToolTip wcTT;
      private System.Windows.Forms.ToolTip productTT;
      private System.Windows.Forms.Button productButton;
      private System.Windows.Forms.Button wcButton;
      private System.Windows.Forms.Button equalsButton;
      private System.Windows.Forms.Button onButton;
      private System.Windows.Forms.ToolTip onTT;
      private System.Windows.Forms.ToolTip equalsTT;

   }
}

