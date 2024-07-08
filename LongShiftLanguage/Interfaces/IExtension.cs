using LongShiftLanguage.Classes.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LongShiftLanguage.Interfaces
{
    public interface IExtension
    {
        void Execute();
        ToolStripMenuItem[] GetMenuItems();
        ToolMenuButton[] GetButtons(); 

    }
}
