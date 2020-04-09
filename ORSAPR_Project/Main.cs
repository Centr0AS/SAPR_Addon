using System;
using System.Windows.Forms;

namespace ORSAPR_Project
    
{
    public partial class Main : Form
    {
        private KompasConnector kompasConnector;
        private HiveParams hiveParams;

        public Main()
        {
            InitializeComponent();
            autoFill();
            button1.PerformClick(); // Удалить в будущем, только для дебагинга.
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

            if ((textBox1.Text == "") || Convert.ToInt32(textBox1.Text) < 200 || (Convert.ToInt32(textBox1.Text)) > 1000)
            {
                textBox1.BackColor = System.Drawing.Color.Red;
                
            }
            else
            {
                textBox1.BackColor = System.Drawing.Color.Green;
                rightToken++;
                //hiveParams.HiveHeight = Convert.ToDouble(textBox1.Text);
              
            }

            if ((textBox2.Text == "") || Convert.ToInt32(textBox2.Text) < 300 || (Convert.ToInt32(textBox2.Text)) > 1000)
            {
                textBox2.BackColor = System.Drawing.Color.Red;
              
            }
            else
            {
                textBox2.BackColor = System.Drawing.Color.Green;
                //hiveParams.HiveLenght = Convert.ToDouble(textBox2.Text);
                rightToken++;
              
            }

            if ((textBox3.Text == "") || Convert.ToInt32(textBox3.Text) < 300 || (Convert.ToInt32(textBox3.Text)) > 1000)
            {
                textBox3.BackColor = System.Drawing.Color.Red;
                rightToken++;
               
            }
            else
            {
                textBox3.BackColor = System.Drawing.Color.Green;
                rightToken++;
                //hiveParams.HiveWidth = Convert.ToDouble(textBox3.Text);
                
            }

            if ((textBox4.Text == "") || Convert.ToInt32(textBox4.Text) < 10 || (Convert.ToInt32(textBox4.Text)) > 100)
            {
                textBox4.BackColor = System.Drawing.Color.Red;
                
            }
            else
            {
                textBox4.BackColor = System.Drawing.Color.Green;
                rightToken++;
                // hiveParams.InletDiameters = Convert.ToDouble(textBox4.Text);
              
            }

            if ((textBox5.Text == "") || Convert.ToInt32(textBox5.Text) < 50 || (Convert.ToInt32(textBox5.Text)) > 500)
            {
                textBox5.BackColor = System.Drawing.Color.Red;
               
            }
            else
            {
                textBox5.BackColor = System.Drawing.Color.Green;
                rightToken++;
                //  hiveParams.LegLength = Convert.ToDouble(textBox5.Text);
            
            }

            if ((textBox6.Text == "") || Convert.ToInt32(textBox6.Text) < 50 || (Convert.ToInt32(textBox6.Text)) > 500)
            {
                textBox6.BackColor = System.Drawing.Color.Red;
             
            }
            else
            {
                textBox6.BackColor = System.Drawing.Color.Green;
                rightToken++;
                // hiveParams.LegWidth = Convert.ToDouble(textBox6.Text);
               
            }

            if ((textBox7.Text == "") || Convert.ToInt32(textBox7.Text) < 50 || (Convert.ToInt32(textBox7.Text)) > 500)
            {
                textBox7.BackColor = System.Drawing.Color.Red;
            
            }
            else
            {
                textBox7.BackColor = System.Drawing.Color.Green;
                rightToken++;
                //  hiveParams.LegHeight = Convert.ToDouble(textBox7.Text);
              
            }

            if ((textBox8.Text == "") || Convert.ToInt32(textBox8.Text) < 100 || (Convert.ToInt32(textBox8.Text)) > 350)
            {
                textBox8.BackColor = System.Drawing.Color.Red;
              
            }
            else
            {
                textBox8.BackColor = System.Drawing.Color.Green;
                rightToken++;
                //  hiveParams.RoofThickness = Convert.ToDouble(textBox8.Text);
              
            }

            if (rightToken == 8)
            {
                button1.Enabled = true;
                hiveParams = new HiveParams(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text),
                    Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text), Convert.ToDouble(textBox6.Text),
                    Convert.ToDouble(textBox7.Text), Convert.ToDouble(textBox8.Text));
                label18.Visible = false;
            }
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
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

      
    }
}
