using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.ViewModel
{
    public class UserView
    {
        public string email { get; set; }
        public string nr_tel { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }

        public UserView(User user)
        {
            imie = user.imie;
            nazwisko = user.nazwisko;
            email = user.Email;
            nr_tel = user.PhoneNumber;
        }
    }
}
