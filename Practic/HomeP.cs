using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
        private void button3_Click(object sender, EventArgs e) ///Кнопка очистки полей
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        private void button4_Click(object sender, EventArgs e) ///Кнопка просмотра услуг, выводит на экран сообщение с перечнем услуг
        {
            MessageBox.Show("1. Натальная карта и гороскоп - детальный анализ личности, характера и потенциала, стоимость от 2000 рублей.\r\n2. Годовой прогноз - предсказание ключевых событий и возможностей на год вперед, стоимость от 1500 рублей.\r\n3. Любовный гороскоп - изучение взаимоотношений пары или поиск идеального партнера, стоимость от 2500 рублей.\r\n4. Карьерный гороскоп - помощь в выборе профессионального пути и повышении эффективности на работе, стоимость от 1800 рублей.\r\n5. Детский гороскоп - помогает родителям понять особенности характера и потенциала ребенка, стоимость от 1500 рублей.\r\n6. Основания для брака - анализ совместимости и будущего в браке, стоимость от 2200 рублей.\r\n7. Карма и предназначение - разгадка кармических связей и целей в текущей жизни, стоимость от 2500 рублей.\r\n8. Астрологическое консультирование - помощь в решении текущих жизненных вопросов и проблем, стоимость от 1200 рублей.\r\n9. Психологическое астрологическое сопровождение - поддержка и помощь в преодолении личных трудностей, стоимость от 3000 рублей.\r\n10. Астрологический курс обучения - углубленное изучение астрологии и натальной карты, стоимость от 5000 рублей.");
        }
        private void button2_Click(object sender, EventArgs e) ///Кнопка для записи на прием
        {
            var name = textBox2.Text;
            var order = textBox3.Text;
            var datad = textBox4.Text;

            using (DataBaseContext context = new DataBaseContext())
            {
                var newOrder = new User { Name = name, Order = order, DateD =  datad };
                context.Set<User>().Add(newOrder);
                context.SaveChanges();
                MessageBox.Show("Запись создана");
            }
        }
        
        private void HomeP_Load(object sender, EventArgs e)
        {

        }
    }
}
