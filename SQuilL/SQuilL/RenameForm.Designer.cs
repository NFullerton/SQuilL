namespace SQuilL {
   partial class RenameForm {
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
         this.setButton = new System.Windows.Forms.Button();
         this.cancelButton = new System.Windows.Forms.Button();
         this.label = new System.Windows.Forms.Label();
         this.textBox = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // setButton
         // 
         this.setButton.Location = new System.Drawing.Point(16, 91);
         this.setButton.Name = "setButton";
         this.setButton.Size = new System.Drawing.Size(75, 23);
         this.setButton.TabIndex = 0;
         this.setButton.Text = "OK";
         this.setButton.UseVisualStyleBackColor = true;
         this.setButton.Click += new System.EventHandler(this.setButton_Click);
         // 
         // cancelButton
         // 
         this.cancelButton.Location = new System.Drawing.Point(177, 91);
         this.cancelButton.Name = "cancelButton";
         this.cancelButton.Size = new System.Drawing.Size(75, 23);
         this.cancelButton.TabIndex = 1;
         this.cancelButton.Text = "Cancel";
         this.cancelButton.UseVisualStyleBackColor = true;
         this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
         // 
         // label
         // 
         this.label.AutoSize = true;
         this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label.Location = new System.Drawing.Point(12, 9);
         this.label.Name = "label";
         this.label.Size = new System.Drawing.Size(240, 16);
         this.label.TabIndex = 2;
         this.label.Text = "Please enter the new name of the table:";
         // 
         // textBox
         // 
         this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textBox.Location = new System.Drawing.Point(16, 45);
         this.textBox.Name = "textBox";
         this.textBox.Size = new System.Drawing.Size(236, 22);
         this.textBox.TabIndex = 3;
         // 
         // RenameForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(269, 136);
         this.ControlBox = false;
         this.Controls.Add(this.textBox);
         this.Controls.Add(this.label);
         this.Controls.Add(this.cancelButton);
         this.Controls.Add(this.setButton);
         this.Name = "RenameForm";
         this.ShowIcon = false;
         this.Text = "Rename Table:";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button setButton;
      private System.Windows.Forms.Button cancelButton;
      private System.Windows.Forms.Label label;
      private System.Windows.Forms.TextBox textBox;
   }
}