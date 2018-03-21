using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CNC
{
    public partial class Form1 : Form
    {        
        double y1, y2, f1, f2, f3, f4;
       
        string fileName;
        public Form1()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Выбрать .nc";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {               
                label1.Text = openFileDialog1.FileName;
                fileName = openFileDialog1.SafeFileName;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                y1 = double.Parse(textBox1.Text.Replace(',', '.'));
                y2 = double.Parse(textBox2.Text.Replace(',', '.'));
                f1 = double.Parse(textBox3.Text.Replace(',', '.'));
                f2 = double.Parse(textBox4.Text.Replace(',', '.'));
                f3 = double.Parse(textBox5.Text.Replace(',', '.'));
                f4 = double.Parse(textBox6.Text.Replace(',', '.'));
                
                if (y1 <= y2)
                {
                    throw new AppDomainUnloadedException();
                }

                saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.FileName = $"{fileName.Replace(".nc", "")}_new.nc";
                saveFileDialog1.Filter = "Nc File | *.nc";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Parser parser = new Parser(y1, y2, f1, f2, f3, f4);
                    using (StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding(1251)))
                    {
                        using (StreamWriter sw = new StreamWriter(saveFileDialog1.OpenFile(), Encoding.GetEncoding(1251)))
                        {
                            int i = 1;
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                
                                try
                                {
                                    sw.WriteLine(parser.AddF(line));
                                    i++;
                                }
                                catch
                                {
                                    MessageBox.Show($"В {i} строке ошибка");
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("Готово");

            }
            catch (AppDomainUnloadedException)
            {
                MessageBox.Show("y1 должен быть больше y2");
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверные параметры");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Не выбран файл");
            }
            catch (Exception)
            {
                MessageBox.Show("Неизвестная ошибка");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '-' && e.KeyChar != ',' && e.KeyChar != '.')
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '-' && e.KeyChar != ',' && e.KeyChar != '.')
                e.Handled = true;
        }

       

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '-' && e.KeyChar != ',' && e.KeyChar != '.')
                e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '-' && e.KeyChar != ',' && e.KeyChar != '.')
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '-' && e.KeyChar != ',' && e.KeyChar != '.')
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '-' && e.KeyChar != ',' && e.KeyChar != '.')
                e.Handled = true;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
