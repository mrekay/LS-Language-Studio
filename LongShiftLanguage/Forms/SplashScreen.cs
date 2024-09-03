using LongShiftLanguage.Classes;
using LongShiftLanguage.libs.multilanguage_support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static config_definitions;
namespace LongShiftLanguage.Forms
{
	public partial class SplashScreen : Form
	{

		

		public SplashScreen()
		{
			InitializeComponent();
			LoadLanguageTexts();

			label3.Text = "v"+ApplicationVersion;
			this.Region = functions.CalcRegion(Size,8);

		}

        private void LoadLanguageTexts()
        {
			label5.Text = LangCtrl.GetText("LOADING_DATAS");
        }

        private void timer1_Tick(object sender, EventArgs e)
		{
			if (label5.Text == LangCtrl.GetText("DATAS_LOADED")) { 
			timer1.Stop();
			this.Visible = false;
			}
			else
			{
                label5.Text = LangCtrl.GetText("DATAS_LOADED");
            }

		}
	}
}
