namespace Integrador
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            ApellidoTextBox = new TextBox();
            NombreTextBox = new TextBox();
            DniTextBox = new TextBox();
            IdPersonaTextBox = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            AutosDePersonaDataGridView = new DataGridView();
            EliminarPersonaButton = new Button();
            GuardarPersonaButton = new Button();
            NuevoPersonaButton = new Button();
            PersonasDataGridView = new DataGridView();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AutosDePersonaDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PersonasDataGridView).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(ApellidoTextBox);
            panel1.Controls.Add(NombreTextBox);
            panel1.Controls.Add(DniTextBox);
            panel1.Controls.Add(IdPersonaTextBox);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(AutosDePersonaDataGridView);
            panel1.Controls.Add(EliminarPersonaButton);
            panel1.Controls.Add(GuardarPersonaButton);
            panel1.Controls.Add(NuevoPersonaButton);
            panel1.Controls.Add(PersonasDataGridView);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(549, 490);
            panel1.TabIndex = 0;
            // 
            // ApellidoTextBox
            // 
            ApellidoTextBox.Location = new Point(433, 376);
            ApellidoTextBox.Name = "ApellidoTextBox";
            ApellidoTextBox.Size = new Size(100, 25);
            ApellidoTextBox.TabIndex = 14;
            // 
            // NombreTextBox
            // 
            NombreTextBox.Location = new Point(433, 345);
            NombreTextBox.Name = "NombreTextBox";
            NombreTextBox.Size = new Size(100, 25);
            NombreTextBox.TabIndex = 13;
            // 
            // DniTextBox
            // 
            DniTextBox.Location = new Point(433, 314);
            DniTextBox.Name = "DniTextBox";
            DniTextBox.Size = new Size(100, 25);
            DniTextBox.TabIndex = 12;
            // 
            // IdPersonaTextBox
            // 
            IdPersonaTextBox.Location = new Point(433, 283);
            IdPersonaTextBox.Name = "IdPersonaTextBox";
            IdPersonaTextBox.ReadOnly = true;
            IdPersonaTextBox.Size = new Size(100, 25);
            IdPersonaTextBox.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(329, 383);
            label6.Name = "label6";
            label6.Size = new Size(61, 18);
            label6.TabIndex = 10;
            label6.Text = "Apellido";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(329, 352);
            label5.Name = "label5";
            label5.Size = new Size(59, 18);
            label5.TabIndex = 9;
            label5.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(329, 321);
            label4.Name = "label4";
            label4.Size = new Size(31, 18);
            label4.TabIndex = 8;
            label4.Text = "DNI";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(329, 290);
            label3.Name = "label3";
            label3.Size = new Size(20, 18);
            label3.TabIndex = 7;
            label3.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 22F);
            label2.Location = new Point(467, 213);
            label2.Name = "label2";
            label2.Size = new Size(76, 37);
            label2.TabIndex = 6;
            label2.Text = "Total";
            // 
            // AutosDePersonaDataGridView
            // 
            AutosDePersonaDataGridView.AllowUserToAddRows = false;
            AutosDePersonaDataGridView.AllowUserToDeleteRows = false;
            AutosDePersonaDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            AutosDePersonaDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AutosDePersonaDataGridView.Location = new Point(319, 50);
            AutosDePersonaDataGridView.Name = "AutosDePersonaDataGridView";
            AutosDePersonaDataGridView.ReadOnly = true;
            AutosDePersonaDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AutosDePersonaDataGridView.Size = new Size(214, 150);
            AutosDePersonaDataGridView.TabIndex = 5;
            // 
            // EliminarPersonaButton
            // 
            EliminarPersonaButton.AutoSize = true;
            EliminarPersonaButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            EliminarPersonaButton.Location = new Point(464, 445);
            EliminarPersonaButton.Name = "EliminarPersonaButton";
            EliminarPersonaButton.Size = new Size(69, 28);
            EliminarPersonaButton.TabIndex = 4;
            EliminarPersonaButton.Text = "Eliminar";
            EliminarPersonaButton.UseVisualStyleBackColor = true;
            // 
            // GuardarPersonaButton
            // 
            GuardarPersonaButton.AutoSize = true;
            GuardarPersonaButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            GuardarPersonaButton.Location = new Point(391, 445);
            GuardarPersonaButton.Name = "GuardarPersonaButton";
            GuardarPersonaButton.Size = new Size(67, 28);
            GuardarPersonaButton.TabIndex = 3;
            GuardarPersonaButton.Text = "Guardar";
            GuardarPersonaButton.UseVisualStyleBackColor = true;
            // 
            // NuevoPersonaButton
            // 
            NuevoPersonaButton.AutoSize = true;
            NuevoPersonaButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            NuevoPersonaButton.Location = new Point(319, 445);
            NuevoPersonaButton.Name = "NuevoPersonaButton";
            NuevoPersonaButton.Size = new Size(66, 28);
            NuevoPersonaButton.TabIndex = 2;
            NuevoPersonaButton.Text = "Agregar";
            NuevoPersonaButton.UseVisualStyleBackColor = true;
            // 
            // PersonasDataGridView
            // 
            PersonasDataGridView.AllowUserToAddRows = false;
            PersonasDataGridView.AllowUserToDeleteRows = false;
            PersonasDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            PersonasDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PersonasDataGridView.Location = new Point(13, 50);
            PersonasDataGridView.Name = "PersonasDataGridView";
            PersonasDataGridView.ReadOnly = true;
            PersonasDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PersonasDataGridView.Size = new Size(300, 423);
            PersonasDataGridView.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 22F);
            label1.Location = new Point(13, 10);
            label1.Name = "label1";
            label1.Size = new Size(126, 37);
            label1.TabIndex = 0;
            label1.Text = "Personas";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 617);
            Controls.Add(panel1);
            Font = new Font("Calibri", 11F);
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AutosDePersonaDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)PersonasDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private DataGridView PersonasDataGridView;
        private Button EliminarPersonaButton;
        private Button GuardarPersonaButton;
        private Button NuevoPersonaButton;
        private DataGridView AutosDePersonaDataGridView;
        private Label label2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox ApellidoTextBox;
        private TextBox NombreTextBox;
        private TextBox DniTextBox;
        private TextBox IdPersonaTextBox;
    }
}
