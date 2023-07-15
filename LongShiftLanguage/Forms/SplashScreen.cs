using LongShiftLanguage.Classes;
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

			label3.Text = "v"+ApplicationVersion;
			this.Region = functions.CalcRegion(Size,8);

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (label5.Text =="Veriler Getirildi") { 
			timer1.Stop();
			this.Visible = false;
			}
			else
			{
				label5.Text = "Veriler Getirildi";
			}

		}
	}
}
