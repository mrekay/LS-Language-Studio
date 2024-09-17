using LongShiftLanguage.libs.multilanguage_support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LongShiftLanguage.Forms
{
    public partial class AboutLSL : LSForm
    {
        public AboutLSL()
        {
            formTextType = FormTextType.OnlyFormText;
            InitializeComponent();

            label3.Text = "v" + LangCtrl.GetText("ABOUT");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://icons8.com/icons/deco");
        }
    }
}
