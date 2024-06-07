using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Practic
{
    public partial class Вход : Form
    {
        public Вход()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Вход_Shown(object sender, EventArgs e) ///Сама форма
        {
            if (Properties.Settings.Default.IsLogged)
            {
                string username = Properties.Settings.Default.Username;
                string password = Properties.Settings.Default.Password;
                if (Login.IsCredentialsValid(username, password))
                {
                    HomeP redirectForm = new HomeP();
                    redirectForm.Show();
                    this.Hide();
                }
                else
                {
                    Properties.Settings.Default.Username = null;
                    Properties.Settings.Default.Password = null;
                    Properties.Settings.Default.IsLogged = false;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Вы вышли из аккаунт, т.к. пароль был изменен");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e) ///Кнопка входа
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (Login.IsCredentialsValid(username, password))
            {
                Properties.Settings.Default.Username = username;
                Properties.Settings.Default.Password = password;
                Properties.Settings.Default.IsLogged = true;
                Properties.Settings.Default.Save();

                HomeP redirectForm = new HomeP();
                redirectForm.Show();
                Hide();
            }
            else
                MessageBox.Show("Неверный логин или пароль");
        }
        private void button2_Click(object sender, EventArgs e) ///Кнопка если нету аккаунта и надо создать
        {
            new Регистрация().Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Вход_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) ///Показ пароля или нет
        {
            if (checkBox1.Checked)
            {
                textBox1.PasswordChar = '\0';
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox1.PasswordChar = '*';
                textBox2.PasswordChar = '*';

            }
        }
    }
}
