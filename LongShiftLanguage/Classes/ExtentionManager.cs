using LongShiftLanguage.Classes.Components;
using LongShiftLanguage.Interfaces;
using LongShiftLanguage.libs.multilanguage_support;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LongShiftLanguage.Classes
{
    public class ExtentionManager
    {

        public ExtentionManager() { LoadExtentions(); }

        public static List<ToolMenuButton> menuButtons = new List<ToolMenuButton>();
        public static List<ToolStripMenuItem> menuItems = new List<ToolStripMenuItem>();


        public void LoadExtentions()
        {
            string extensionsPath = AppDomain.CurrentDomain.BaseDirectory + config_definitions.ExtensionPath;

            if (Directory.Exists(extensionsPath))
            {
                // Extensions klasöründeki tüm DLL dosyalarını bulun
                var dllFiles = Directory.GetFiles(extensionsPath, "*.dll");

                foreach (var dll in dllFiles)
                {
                    try { 
                    // DLL dosyasını yükleyin
                    Assembly assembly = Assembly.LoadFrom(dll);

                    // Yüklenen assembly içindeki tüm türleri alın
                    var types = assembly.GetTypes();

                    foreach (var type in types)
                    {
                        // IExtension arayüzünü uygulayan sınıfları bulun
                        if (typeof(IExtension).IsAssignableFrom(type) && !type.IsInterface)
                        {
                            // Sınıftan bir örnek oluşturun
                            var instance = Activator.CreateInstance(type) as IExtension;

                            if (instance != null)
                            {
                                // Execute metodunu çağırın
                                instance.Execute();

                                // MenuStrip itemlarını alın
                                ToolStripMenuItem[] _menuItems = instance.GetMenuItems();
                                if (_menuItems != null)
                                {
                                    foreach (var menuItem in _menuItems)
                                    {
                                        menuItems.Add(menuItem);
                                    }
                                }

                                // Button arrayini alın
                                ToolMenuButton[] buttons = instance.GetButtons();
                                if (buttons != null)
                                {
                                    foreach (var button in buttons)
                                    {
                                        menuButtons.Add(button);
                                    }
                                }
                            }
                        }
                    }
                    }catch (Exception ex) {

                        NotificationManager.CreateNotification(LangCtrl.GetText("SOME_EXTENTIONS_WONT_LOAD"), LangCtrl.GetText("ERROR"), SystemIcons.Warning);
                    
                    }
                }
            }
            else
            {
                Console.WriteLine("Extensions klasörü bulunamadı.");
            }
        }


    }
}
