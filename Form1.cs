using System;
using System.Windows.Forms;
using Kompas6API5;
using Kompas6Constants;

namespace KompasFormProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем значение из текстбокса
                double length = double.Parse(textBoxLength.Text);

                // Запускаем КОМПАС
                KompasObject kompas = (KompasObject)Activator.CreateInstance(
                    Type.GetTypeFromProgID("Kompas.Application.5"));

                kompas.Visible = true;
                kompas.ActivateControllerAPI();

                // Создаем новый 2D документ
                ksDocument2D doc2D = kompas.Document2D();
                doc2D.Create(false, true);

                // Рисуем горизонтальную линию длиной length
                doc2D.ksLine(0, 0, length, 0, 1); // от (0,0) до (length,0)

                MessageBox.Show("Линия построена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private Button buttonBuild;

        private void InitializeComponent()
        {
            this.buttonBuild = new System.Windows.Forms.Button();
            this.textBoxLength = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonBuild
            // 
            this.buttonBuild.Location = new System.Drawing.Point(94, 156);
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.Size = new System.Drawing.Size(75, 23);
            this.buttonBuild.TabIndex = 0;
            this.buttonBuild.Text = "button1";
            this.buttonBuild.UseVisualStyleBackColor = true;
            // 
            // textBoxLength
            // 
            this.textBoxLength.Location = new System.Drawing.Point(94, 88);
            this.textBoxLength.Name = "textBoxLength";
            this.textBoxLength.Size = new System.Drawing.Size(88, 20);
            this.textBoxLength.TabIndex = 1;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBoxLength);
            this.Controls.Add(this.buttonBuild);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private TextBox textBoxLength;
    }
}
