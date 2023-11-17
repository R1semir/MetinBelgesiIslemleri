using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace metinbelgesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        StreamWriter sw;
        string belgeadi, belgeyolu;

        private void button2_Click(object sender, EventArgs e)
        {
            belgeadi = textBox1.Text;
            sw = File.CreateText(belgeyolu + "\\" + ".txt");
            sw.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string satir = sr.ReadLine();
                while (satir!= null)
                {
                    listBox1.Items.Add(satir);
                    satir = sr.ReadLine();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ac = new OpenFileDialog();
            ac.Filter = "Metin Dosyası(*.txt) | *.txt";
            ac.Multiselect = false;
            if(ac.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox3.Text = ac.SafeFileName;
                try
                {
                    StreamReader oku = new StreamReader(ac.FileName);
                    richTextBox1.Text = oku.ReadToEnd();
                    oku.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("Bu Dosyayı Okurken Hata Oluştu");
                }
               

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Title = "Kayıt Yerini Seçin";
                saveFileDialog1.Filter = "Metin Dosyası(*.txt) | *.txt";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.InitialDirectory = "C:\\";
                saveFileDialog1.ShowDialog();
                StreamWriter sr1 = new StreamWriter(saveFileDialog1.FileName);
                sr1.WriteLine(richTextBox2.Text);
                sr1.Close();
                MessageBox.Show("Kaynak Metin Belgesine Yazdırıldı");
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu İşlem Gerçekleşmedi");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog()== DialogResult.OK)
            {
                belgeyolu = folderBrowserDialog1.SelectedPath.ToString();
                textBox2.Text = belgeyolu.ToString();
            }
        }
    }
}
