using System;
using System.Windows.Forms;
using Hive_Kompas.API;
using Hive_Kompas.Logic;

namespace Hive_Kompas.GUI
    
{
    public partial class Main : Form
    {
        private KompasConnector kompasConnector;
        private HiveParams hiveParams;

        public Main()
        {
            InitializeComponent();
            AutoFill();
        }
        
        /// <summary>
        /// Функция, которая производит автозаполнение данных в поля.
        /// </summary>
        private void AutoFill()
        {
            HheightTextBox.Text = "300";
            HlengthTextBox.Text = "300";
            HwidthTextBox.Text = "300";
            InLetDiamTextBox.Text = "10";
            LlengthTextBox.Text = "100";
            LwidthTextBox.Text = "50";
            LheigthTextBox.Text = "50";
            RoofThicknessTextBox.Text = "5";
        }

        /// <summary>
        /// Функция проверяет правильность введенных данных в поля, если же все данные верны то присваивает значения.
        /// </summary>
        private void ValidateAndSet_Values()
        {
            label18.Visible = true;
            button1.Enabled = false;

            int rightToken = 0;

            if ((HheightTextBox.Text == "") || double.Parse(HheightTextBox.Text) < 200 || double.Parse(HheightTextBox.Text) > 1800 || HheightTextBox.Text.Length > 8)
            {
                HheightTextBox.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                HheightTextBox.BackColor = System.Drawing.Color.Green;
                rightToken++;
            }

            if ((HlengthTextBox.Text == "") || double.Parse(HlengthTextBox.Text) < 300 || (double.Parse(HlengthTextBox.Text)) > 1800 || HlengthTextBox.Text.Length > 8)
            {
                HlengthTextBox.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                HlengthTextBox.BackColor = System.Drawing.Color.Green;
                rightToken++;
            }

            if ((HwidthTextBox.Text == "") || double.Parse(HwidthTextBox.Text) < 300 || (double.Parse(HwidthTextBox.Text)) > 1800 || HwidthTextBox.Text.Length > 8)
            {
                HwidthTextBox.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                HwidthTextBox.BackColor = System.Drawing.Color.Green;
                rightToken++;             
            }

            if ((InLetDiamTextBox.Text == "") || double.Parse(InLetDiamTextBox.Text) < 10 || (double.Parse(InLetDiamTextBox.Text)) > 100 || InLetDiamTextBox.Text.Length > 8)
            {
                InLetDiamTextBox.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                InLetDiamTextBox.BackColor = System.Drawing.Color.Green;
                rightToken++;
            }

            if ((LlengthTextBox.Text == "") || double.Parse(LlengthTextBox.Text) < 50 || (double.Parse(LlengthTextBox.Text)) > 600 || LlengthTextBox.Text.Length > 8)
            {
                LlengthTextBox.BackColor = System.Drawing.Color.Red;               
            }
            else
            {
                LlengthTextBox.BackColor = System.Drawing.Color.Green;
                rightToken++;
            }

            if ((LwidthTextBox.Text == "") || double.Parse(LwidthTextBox.Text) < 50 || (double.Parse(LwidthTextBox.Text)) > 600 || LwidthTextBox.Text.Length > 8)
            {
                LwidthTextBox.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                LwidthTextBox.BackColor = System.Drawing.Color.Green;
                rightToken++;
            }

            if ((LheigthTextBox.Text == "") || double.Parse(LheigthTextBox.Text) < 50 || (double.Parse(LheigthTextBox.Text)) > 1000 || LheigthTextBox.Text.Length > 8)
            {
                LheigthTextBox.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                LheigthTextBox.BackColor = System.Drawing.Color.Green;
                rightToken++;
            }

            if ((RoofThicknessTextBox.Text == "") || double.Parse(RoofThicknessTextBox.Text) < 5 || (double.Parse(RoofThicknessTextBox.Text)) > 100 || RoofThicknessTextBox.Text.Length > 8)
            {
                RoofThicknessTextBox.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                RoofThicknessTextBox.BackColor = System.Drawing.Color.Green;
                rightToken++;
            }

            if (rightToken == 8)
            {
                if ((double.Parse(LlengthTextBox.Text) - 1) >= (double.Parse(HlengthTextBox.Text) / 3))
                {
                    label18.Visible = true;
                    label18.Text = "Длина ножек должны быть в 3 раза меньше, чем у улья!";
                    LlengthTextBox.BackColor = System.Drawing.Color.Red;
                    rightToken = 0;
                }
                else if ((double.Parse(LwidthTextBox.Text)) - 1 >= (double.Parse(HwidthTextBox.Text)) / 3)
                {
                    label18.Visible = true;
                    label18.Text = "Ширина ножек должны быть в 3 раза меньше, чем у улья!";
                    LwidthTextBox.BackColor = System.Drawing.Color.Red;
                    rightToken = 0;
                }
                else
                { 
                    button1.Enabled = true;
                    hiveParams = new HiveParams(Convert.ToDouble(HheightTextBox.Text), Convert.ToDouble(HlengthTextBox.Text), Convert.ToDouble(HwidthTextBox.Text),
                    Convert.ToDouble(InLetDiamTextBox.Text), Convert.ToDouble(LheigthTextBox.Text), Convert.ToDouble(LlengthTextBox.Text),
                    Convert.ToDouble(LwidthTextBox.Text), Convert.ToDouble(RoofThicknessTextBox.Text));
                    label18.Visible = false;
                    label18.Text = "Проверьте правильность введёных данных!";
                }
            }
        }

        /// <summary>
        /// Функция, которая является обработчиком события(срабатывает при изменение значения  в текстовом поле).
        /// </summary>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateAndSet_Values();
        }

        /// <summary>
        /// Обработчик кнопки "Построить."
        /// </summary>
        private void Button1_Click(object sender, EventArgs e)
        {
            kompasConnector = new KompasConnector();
            
            Builder builder = new Builder();
            builder.Build(kompasConnector.iPart, kompasConnector.kompas, hiveParams);   
        }
        /// <summary>
        /// Обработчик, который ограничивает ввод символов в поля.
        /// </summary>
        private void Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44) 
            {
                e.Handled = true;
            }
        }
    }
}
