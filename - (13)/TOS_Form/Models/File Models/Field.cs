using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOS_Form.Models
{
    public class Field
    {
        public string _Data { get; set; }
        public int _Length { get; set; }
        public bool _IsAlphaNumeric { get; set; }

        public Field(string data, int length, bool isAlphaNumeric)
        {
            _Data = data;
            _Length = length;
            _IsAlphaNumeric = isAlphaNumeric;
        }

        public Field(string data, int length)
        {
            _Data = data;
            _Length = length;
            _IsAlphaNumeric = false;
        }
    }
}
