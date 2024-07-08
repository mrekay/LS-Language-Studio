using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LongShiftLanguage.Classes.Components
{
    public class ToolMenuButton : Button
    {
        public string ToolTipText;

        public ToolMenuButton(Image image)
        {

            BackColor = Color.FromArgb(70, 73, 75);
            BackgroundImage = image;
            BackgroundImageLayout = ImageLayout.Stretch;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Size = new Size(24, 24);
        }

        public static ToolMenuButton Clone(ToolMenuButton original)
        {
            var returnObject = new ToolMenuButton(original.BackgroundImage);
            returnObject.ToolTipText = original.ToolTipText;
            return returnObject;
        }


    }
}
