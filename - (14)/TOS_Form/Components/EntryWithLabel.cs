using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TOS_Form.Components.EntryWithLabel;

namespace TOS_Form.Components
{
    public class EntryWithLabel
    {
        public class InputComponent
        {
            public Label title { get; set; }
            public TextBox input { get; set; } 
        }

        public InputComponent Create(string title,int posx, int posy, Control.ControlCollection control)
        {
            var titleLabel = new Label()
            {
                Text = title,
                TabIndex = 10,
                Location = new Point(posx,posy),
                Name = title + "titleLabel",
            };
            titleLabel.AutoSize = true;
            var input = new TextBox()
            {
                TabIndex = 10,
                Location = new Point(posx, posy+23),
                Name = title + "textBox",
            };
            input.Size = new Size(150, 13);

            control.Add(titleLabel);
            control.Add(input);

            return new InputComponent { title=titleLabel, input=input }; 
        }
    }
}
