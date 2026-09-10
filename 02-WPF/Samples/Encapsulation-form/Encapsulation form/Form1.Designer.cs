
namespace Encapsulation_form
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.id = new System.Windows.Forms.Label();
            this.Age = new System.Windows.Forms.Label();
            this.Name = new System.Windows.Forms.Label();
            this.postions = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtage = new System.Windows.Forms.TextBox();
            this.textposition = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.Location = new System.Drawing.Point(44, 70);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(71, 20);
            this.id.TabIndex = 0;
            this.id.Text = "Emp. Id";
            this.id.Click += new System.EventHandler(this.label1_Click);
            // 
            // Age
            // 
            this.Age.AutoSize = true;
            this.Age.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Age.Location = new System.Drawing.Point(44, 182);
            this.Age.Name = "Age";
            this.Age.Size = new System.Drawing.Size(87, 20);
            this.Age.TabIndex = 1;
            this.Age.Text = "Emp. Age";
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name.Location = new System.Drawing.Point(44, 128);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(101, 20);
            this.Name.TabIndex = 2;
            this.Name.Text = "Emp. Name";
            // 
            // postions
            // 
            this.postions.AutoSize = true;
            this.postions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postions.Location = new System.Drawing.Point(44, 236);
            this.postions.Name = "postions";
            this.postions.Size = new System.Drawing.Size(128, 20);
            this.postions.TabIndex = 3;
            this.postions.Text = "Emp. Positions";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(116, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 43);
            this.button1.TabIndex = 4;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(199, 70);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(196, 20);
            this.txtId.TabIndex = 5;
            this.txtId.TextChanged += new System.EventHandler(this.txtId_TextChanged);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(199, 128);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(196, 20);
            this.txtname.TabIndex = 6;
            // 
            // txtage
            // 
            this.txtage.Location = new System.Drawing.Point(199, 182);
            this.txtage.Name = "txtage";
            this.txtage.Size = new System.Drawing.Size(196, 20);
            this.txtage.TabIndex = 7;
            // 
            // textposition
            // 
            this.textposition.Location = new System.Drawing.Point(199, 236);
            this.textposition.Name = "textposition";
            this.textposition.Size = new System.Drawing.Size(196, 20);
            this.textposition.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 381);
            this.Controls.Add(this.textposition);
            this.Controls.Add(this.txtage);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.postions);
            this.Controls.Add(this.Name);
            this.Controls.Add(this.Age);
            this.Controls.Add(this.id);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label id;
        public System.Windows.Forms.Label Age;
        public System.Windows.Forms.Label Name;
        public System.Windows.Forms.Label postions;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox txtId;
        public System.Windows.Forms.TextBox txtname;
        public System.Windows.Forms.TextBox txtage;
        public System.Windows.Forms.TextBox textposition;
    }
}