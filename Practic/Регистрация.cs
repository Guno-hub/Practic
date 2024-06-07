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
    public partial class Регистрация : Form
    {
        public Регистрация()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Регистрация_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) ///Кнопка регистрации
        {
            var username = textBox1.Text;
            var password = textBox2.Text;
            var passwordx2 = textBox3.Text;

            const string requirements = "Пароль не соответсвует требованиям:" +
                                        "\n- Как минимум 6 символов" +
                                        "\n- Спепиальный символ" +
                                        "\n- Цифру" +
                                        "\n- Заглавную букву" +
                                        "\n- Прописную букву";

            if (username == "" || password == "" || passwordx2 == "")
            {
                MessageBox.Show("Поле имени пользователя или пароля пусты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != passwordx2)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Registration.IsPasswordValid(password))
            {
                MessageBox.Show(requirements, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Registration.IsUsernameAvailable(username))
            {
                MessageBox.Show("Такой логин уже занят.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (DataBaseContext context = new DataBaseContext())
            {
                var newUser = new User { Username = username, Password = password };
                context.Set<User>().Add(newUser);
                context.SaveChanges();
            }

            MessageBox.Show("Аккаунт успешно создан!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            HomeP redirectForm = new HomeP();
            redirectForm.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e) ///Кнопка если уже есть аккаунт и надо войти
        {
            new Вход().Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) ///Показ пароля или нет
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
            }
        }
    }
}
