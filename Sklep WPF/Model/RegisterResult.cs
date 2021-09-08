using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_WPF.Model
{
    public class RegisterResult
    {
        public bool succeeded { get; set; }
        public List<Error> errors { get; set; }
        public RegisterResult() { }
    }
}
