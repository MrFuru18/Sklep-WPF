using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class Image
    {
        public Guid id { get; set; }
        public string imgName { get; set; }
        public byte[] img { get; set; }
    }
}
