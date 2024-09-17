using LongShiftLanguage.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LongShiftLanguage.Classes.Components
{
    public class AppButton : PictureBox
    {

        public Label appNameLabel;
        public Button deleteLanguageButton;

        public AppButton(Image imageData, string ProjectName, int projectID)
        {

            Size = new Size(400, 160);
            BackgroundImage = imageData;
            BackgroundImageLayout = ImageLayout.Zoom;
            Cursor = Cursors.Hand;
            Tag = projectID;

            if (imageData == null)
            {
                BackColor = Color.FromArgb(60,63,65);
                appNameLabel = new Label();
                appNameLabel.Text = ProjectName;
                appNameLabel.ForeColor = Color.White;
                appNameLabel.AutoSize = true;
                appNameLabel.Font = new Font("Seoge UI", 24, FontStyle.Bold);
                appNameLabel.TextAlign = ContentAlignment.MiddleCenter;
                Controls.Add(appNameLabel);
                appNameLabel.Location = new Point((this.Width - appNameLabel.Width)/2, (this.Height - appNameLabel.Height)/2);
                appNameLabel.Click += AppNameLabel_Click;
            }
            
            deleteLanguageButton = new Button() { FlatStyle =  FlatStyle.Flat,Text = "",BackgroundImageLayout = ImageLayout.Stretch, BackgroundImage = Resources.icons8_close_48,Size = new Size(32,32)};
            Controls.Add(deleteLanguageButton);
            deleteLanguageButton.FlatAppearance.BorderSize = 0;
            deleteLanguageButton.Location = new Point(Width - deleteLanguageButton.Width - 8, 8);
            deleteLanguageButton.Visible = false;
            deleteLanguageButton.Tag = projectID;
        }

        private void AppNameLabel_Click(object sender, EventArgs e)
        {
            //todo: yapılacak
            
        }
    }
}
