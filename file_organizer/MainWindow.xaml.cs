using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace file_organizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainframe.Navigate(new Page1());
            LogReg.MainFrame = mainframe;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            LogReg.MainFrame.Navigate(new Page1());
            logmenu.Background = Brushes.White;
            regmenu.Background = Brushes.LightGray;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            LogReg.MainFrame.Navigate(new Page2());
            regmenu.Background = Brushes.White;
            logmenu.Background = Brushes.LightGray;
        }

    }

    /*public class LogScreen
    {
        public void sp() 
        {
            StackPanel sp1 = new StackPanel();
            sp1.Width = 200;
            sp1.Height = 200;
            sp1.HorizontalAlignment = HorizontalAlignment.Center;
            sp1.VerticalAlignment = VerticalAlignment.Center;

            TextBlock lg = new TextBlock();
            lg.Text = "Логин";
            lg.FontSize = 12;
            sp1.Children.Add(lg);

            TextBox log = new TextBox();
            log.Width = 200;

             MainWindow.Content = sp1;
        }
        
    }*/

    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
    public class AppDbCont : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transport> transports { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UsersDb;Integrated Security=True;Connect Timeout=30;Encrypt=False; Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
    public class Transport
    {
        public int Id { get; set; }
        public User Owner { get; set; }
        public string Identifier { get; set; }
    }

}
