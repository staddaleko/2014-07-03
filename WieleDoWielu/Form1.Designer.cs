namespace WieleDoWielu
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
            this.components = new System.ComponentModel.Container();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.ksiazkiDataSet = new WieleDoWielu.KsiazkiDataSet();
            this.autorzyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.autorzyTableAdapter = new WieleDoWielu.KsiazkiDataSetTableAdapters.AutorzyTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ksiazkiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autorzyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.autorzyBindingSource;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(62, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(385, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(62, 93);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(385, 316);
            this.listBox1.TabIndex = 1;
            // 
            // ksiazkiDataSet
            // 
            this.ksiazkiDataSet.DataSetName = "KsiazkiDataSet";
            this.ksiazkiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // autorzyBindingSource
            // 
            this.autorzyBindingSource.DataMember = "Autorzy";
            this.autorzyBindingSource.DataSource = this.ksiazkiDataSet;
            // 
            // autorzyTableAdapter
            // 
            this.autorzyTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 459);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ksiazkiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autorzyBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox listBox1;
        private KsiazkiDataSet ksiazkiDataSet;
        private System.Windows.Forms.BindingSource autorzyBindingSource;
        private KsiazkiDataSetTableAdapters.AutorzyTableAdapter autorzyTableAdapter;
    }
}

