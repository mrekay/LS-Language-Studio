﻿using LongShiftLanguage.Classes;
using LongShiftLanguage.Forms;
using LongShiftLanguage.libs.multilanguage_support;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LongShiftLanguage
{
	internal static class Program
	{
		/// <summary>
		/// Uygulamanın ana girdi noktası.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);


			var multiLangSupport = new LanguageController();
            var extentionManager = new ExtentionManager();
            var proj = new ProjectForm();
			if (!proj.IsDisposed)
				Application.Run(proj);
			else return;
			
		}
	}
}
