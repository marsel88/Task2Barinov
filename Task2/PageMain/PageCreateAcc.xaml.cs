using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Task2.ApplicationData;

namespace Task2.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageCreateAcc.xaml
    /// </summary>
    public partial class PageCreateAcc : Page
    {
        public PageCreateAcc()
        {
            InitializeComponent();
        }
        private void NumberValidationTB(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void TextValidationTB(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void regBT_Click(object sender, RoutedEventArgs e)
        {
            if(AppConnect.modeldb.Users.Count(x => x.login == loginTB.Text) >0 )
            {
                MessageBox.Show("Пользователь уже существует");
            }
            try
            {
                Users userObj = new Users()
                {
                    login = loginTB.Text,
                    password = passwordTB.Text
                };
                AppConnect.modeldb.Users.Add(userObj);
                AppConnect.modeldb.SaveChanges();
                MessageBox.Show("Данные успешно сохранены");
                AppFrame.frameMain.Navigate(new PageLogin());
            }
            catch (Exception ex) { }
        }
    }

}
