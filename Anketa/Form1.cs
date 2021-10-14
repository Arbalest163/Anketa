using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Anketa
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            var anketa = new Anketa();
            if (saveAnketa(anketa))
            {
                saveFile(anketa);
            }

        }

        private void saveFile(Anketa anketa)
        {
            try
            {
               
                using SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter myStream = new StreamWriter(saveFileDialog1.FileName);

                    myStream.WriteLine($"Фамилия: {anketa.LastName}\n" +
                                       $"Имя: {anketa.FirstName}\n" +
                                       $"Отчество: {anketa.Patronimyc}\n" +
                                       $"Пол: {anketa.Sex}\n" +
                                       $"Дата рождения: {anketa.BirthDay}\n" +
                                       $"Семейное положение: {anketa.MaritalStatus}\n" +
                                       $"Дополнительная информация: {anketa.Info}\n");

                    myStream.Close();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool saveAnketa(Anketa anketa)
        {
            try
            {
                if (textBox_LastName.Text == "" || textBox_FirstName.Text == "" ||
                    textBox_Patronymic.Text == "" || textBox_Sex.Text == "" ||
                    textBox_BirthDay.Text == "" || textBox_MaritalStatus.Text == "" ||
                    textBox_Info.Text == "")
                {
                    throw new Exception();
                }
                else 
                {
                    anketa.LastName = textBox_LastName.Text;
                    anketa.FirstName = textBox_FirstName.Text;
                    anketa.Patronimyc = textBox_Patronymic.Text;
                    anketa.Sex = textBox_Sex.Text;
                    anketa.BirthDay = textBox_BirthDay.Text;
                    anketa.MaritalStatus = textBox_MaritalStatus.Text;
                    anketa.Info = textBox_Info.Text;
                }

            }
            catch (Exception) {
                MessageBox.Show("Анкета не заполнена");
                return false;
            }
            return true;
        }
    }
    public class Anketa
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronimyc { get; set; }
        public string Sex { get; set; }
        public string BirthDay { get; set; }
        public string MaritalStatus { get; set; }
        public string Info { get; set; }

    }
}
