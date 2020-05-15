using System;
using System.Collections.Generic;
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
        /// Проверяет правильность введенных данных в поля, если же все данные верны то присваивает значения.
        /// </summary>
        private void ValidateAndSet_Values()
        {
            label18.Visible = true;
            button1.Enabled = false;

            List<TextBox> TextBoxList = new List<TextBox>();

            TextBoxList.AddRange(new TextBox[]
            { HheightTextBox,
              HlengthTextBox,
              HwidthTextBox,
              InLetDiamTextBox,
              LlengthTextBox,
              LwidthTextBox,
              LheigthTextBox,
              RoofThicknessTextBox
            });

            List<double> MinInputList = new List<double>();
            MinInputList.AddRange(new double[] { 200, 300, 300, 10, 50, 50, 50, 5 });
            List<double> MaxInputList = new List<double>();
            MaxInputList.AddRange(new double[] { 1800, 1800, 1800, 75, 600, 600, 1000, 50 });
            int i = 0;
            for (i = 0; i != 8; i++)
            {
                if ((TextBoxList[i].Text == "") || double.Parse(TextBoxList[i].Text) < MinInputList[i] ||
                    double.Parse(TextBoxList[i].Text) > MaxInputList[i] || TextBoxList[i].Text.Length > 8)
                {
                    TextBoxList[i].BackColor = System.Drawing.Color.Red;
                    label18.Visible = true;
                    break;
                }
                else
                {
                    TextBoxList[i].BackColor = System.Drawing.Color.Green;
                    label18.Visible = false;
                }
            }
            if (i == 8)
            {
                if ((double.Parse(LlengthTextBox.Text) - 1) >= (double.Parse(HlengthTextBox.Text) / 3))
                {
                    label18.Visible = true;
                    label18.Text = "Длина ножек должны быть в 3 раза меньше, чем у улья!";
                    LlengthTextBox.BackColor = System.Drawing.Color.Red;
                }
                else if ((double.Parse(LwidthTextBox.Text)) - 1 >= (double.Parse(HwidthTextBox.Text)) / 3)
                {
                    label18.Visible = true;
                    label18.Text = "Ширина ножек должны быть в 3 раза меньше, чем у улья!";
                    LwidthTextBox.BackColor = System.Drawing.Color.Red;
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
            bool BackSide = false;
            bool LeftSide = false;
            bool RightSide = false;

            kompasConnector = new KompasConnector();

            if (BackSidecheckBox.Checked)
            { BackSide = true; }

            if (LeftSidecheckBox.Checked)
            { LeftSide = true; }

            if (RightSidecheckBox.Checked)
            { RightSide = true; }

            Builder builder = new Builder();
            builder.Build(kompasConnector.iPart, kompasConnector.kompas, hiveParams, BackSide, LeftSide, RightSide);   
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
