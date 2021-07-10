using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.ViewModel
{
    public class UserView
    {
        public string nazwa { get; set; }
        public string email { get; set; }
        //public string imie { get; set; }
        //public string nazwisko { get; set; }
        public string nr_tel { get; set; }
        public virtual ICollection<AddressView> adresy { get; set; }
        //public string token { get; set; }

        public UserView(User user)
        {
            nazwa = user.UserName;
            email = user.Email;
            //imie = user.;
            //nazwisko = user.nazwisko;
            nr_tel = user.PhoneNumber;
            adresy = new List<AddressView>();
            if (user.adresy != null)
                foreach (Address x in user.adresy)
                {
                    adresy.Add(new AddressView(x));
                }
        }
    }
}
