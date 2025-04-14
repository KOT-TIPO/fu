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
using System.Windows.Shapes;
using Yagnov.Services;

namespace Yagnov
{
    /// <summary>
    /// Логика взаимодействия для reg.xaml
    /// </summary>
    public partial class Reg 
    {
        AuthService authService = new AuthService();
        public Reg()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            string login = tbxlogin.Text;
            string pass = tbxPass.Text;

            if (authService.CheckData(login,pass))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка, проверьте правильность введённых данных в полях");
            }
        }

 
    }
}
