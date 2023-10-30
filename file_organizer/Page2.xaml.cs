using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace file_organizer
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void registr_Click(object sender, RoutedEventArgs e)
        {
            
            var login = loginBox.Text;
            var password = PasswordBox.Text;

            var context = new AppDbCont();

            var user_exists = context.Users.SingleOrDefault(x => x.Login == login && x.Password == password);
            if (user_exists != null)
            {
                MessageBox.Show ("Такой пользователь уже сужествует");
                return;
            }
            if (PasswordBox.Text != PassCheckBox.Text)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            var user = new User { Login = login, Password = password };
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
