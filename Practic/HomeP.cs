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
    public partial class HomeP : Form
    {
        public HomeP()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e) ///Кнопка выхода из аккаунта, перебрасывает на форму входа
        {
            Properties.Settings.Default.Username = null;
            Properties.Settings.Default.Password = null;
            Properties.Settings.Default.IsLogged = false;
            Properties.Settings.Default.Save();

            Вход redirectForm = new Вход();
            redirectForm.Show();
            Hide();
        }
        
        private void HomeP_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
