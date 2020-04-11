using System;
using System.Windows.Forms;

namespace Hive_Kompas
    
{
    public partial class Main : Form
    {
        private KompasConnector kompasConnector;
        private HiveParams hiveParams;

        public Main()
        {
            InitializeComponent();
            autoFill();
        }
        
        private void autoFill()
        {
            textBox1.Text = "200";
            textBox2.Text = "300";
            textBox3.Text = "300";
            textBox4.Text = "10";
            textBox5.Text = "100";
            textBox6.Text = "50";
            textBox7.Text = "50";
            textBox8.Text = "100";
        }

        private void validateAndSet_Values()
        {
            label18.Visible = true;
            button1.Enabled = false;
            int rightToken = 0;

            if ((textBox1.Text == "") || double.Parse(textBox1.Text) < 200 || double.Parse(textBox1.Text) > 800 || textBox1.Text.Length > 8)
            {
                textBox1.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                textBox1.BackColor = System.Drawing.Color.Green;
                rightToken++;
            }

            if ((textBox2.Text == "") || double.Parse(textBox2.Text) < 300 || (double.Parse(textBox2.Text)) > 1800 || textBox2.Text.Length > 8)
            {
                textBox2.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                textBox2.BackColor = System.Drawing.Color.Green;
                rightToken++;
            }

            if ((textBox3.Text == "") || double.Parse(textBox3.Text) < 300 || (double.Parse(textBox3.Text)) > 1800 || textBox3.Text.Length > 8)
            {
                textBox3.BackColor = System.Drawing.Color.Red;
                rightToken++;
            }
            else
            {
                textBox3.BackColor = System.Drawing.Color.Green;
                rightToken++;             
            }

            if ((textBox4.Text == "") || double.Parse(textBox4.Text) < 10 || (double.Parse(textBox4.Text)) > 100 || textBox4.Text.Length > 8)
            {
                textBox4.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                textBox4.BackColor = System.Drawing.Color.Green;
                rightToken++;
            }

            if ((textBox5.Text == "") || double.Parse(textBox5.Text) < 50 || (double.Parse(textBox5.Text)) > 1000 || textBox5.Text.Length > 8)
            {
                textBox5.BackColor = System.Drawing.Color.Red;               
            }
            else
            {
                textBox5.BackColor = System.Drawing.Color.Green;
                rightToken++;
            }

            if ((textBox6.Text == "") || double.Parse(textBox6.Text) < 50 || (double.Parse(textBox6.Text)) > 1000 || textBox6.Text.Length > 8)
            {
                textBox6.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                textBox6.BackColor = System.Drawing.Color.Green;
                rightToken++;
            }

            if ((textBox7.Text == "") || double.Parse(textBox7.Text) < 50 || (double.Parse(textBox7.Text)) > 1000 || textBox7.Text.Length > 8)
            {
                textBox7.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                textBox7.BackColor = System.Drawing.Color.Green;
                rightToken++;
            }

            if ((textBox8.Text == "") || double.Parse(textBox8.Text) < 100 || (double.Parse(textBox8.Text)) > 350 || textBox8.Text.Length > 8)
            {
                textBox8.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                textBox8.BackColor = System.Drawing.Color.Green;
                rightToken++;
            }

            if (rightToken == 8)
            {
                button1.Enabled = true;
                hiveParams = new HiveParams(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text),
                    Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox7.Text), Convert.ToDouble(textBox6.Text),
                    Convert.ToDouble(textBox5.Text), Convert.ToDouble(textBox8.Text));
                label18.Visible = false;
            }
        }

        private void textBox_LostFocus(object sender, EventArgs e)
        {
            validateAndSet_Values();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            validateAndSet_Values();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kompasConnector = new KompasConnector(hiveParams);
            Builder builder = new Builder();
            builder.Build(kompasConnector.iPart, kompasConnector._kompas, hiveParams);   
        }
        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }
    }
}
