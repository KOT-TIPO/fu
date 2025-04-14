using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yagnov.BDModel;
using Yagnov.Model;
using System.Data.Entity;

namespace Yagnov.Services
{
    public class AuthService 
    {
        ShopDBEntities dbContext = new ShopDBEntities();

        public bool CheckData(string login, string pass)
        {
            var user = dbContext.Users.Include(u => u.Role).FirstOrDefault(u => u.Login == login && u.Pass == pass);

            if (user != null && user.Pass == pass)
            {
                MainWindow Window = new MainWindow(user);
                Window.Show();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
