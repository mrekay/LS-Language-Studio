using LongShiftLanguage.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LongShiftLanguage.Forms.FormElements
{
	public class ControlsBox : Panel
	{

		public PictureBox form_icon;
		public Label form_label;
		public Button close_button;
		public Button resize_button;
		public Button minimize_button;

		public LSForm Parent;

		public ControlsBox(LSForm parent)
		{

			Dock =  DockStyle.Top;
			Size = new System.Drawing.Size(0, 48);
			

			this.Parent = parent;
			this.Parent.Controls.Add(this);
		


			InitalizeControlDesign();
		}

		private void InitalizeControlDesign()
		{
			/*FormIcon*/
			if (Parent.ShowIcon)
			{
				form_icon = new PictureBox();
				form_icon.Size = new System.Drawing.Size(32, 32);
				form_icon.BackgroundImage = Properties.Resources.languages;
				form_icon.BackgroundImageLayout = ImageLayout.Stretch;
				form_icon.Location = new System.Drawing.Point(10, (Height /2)-(form_icon.Height/2));
				form_icon.Name = "form_icon";
				form_icon.Anchor = AnchorStyles.Left;
				this.Controls.Add(form_icon);
			}

			/* Form Label */
			form_label = new Label();
			form_label.AutoSize = true;
			form_label.Font = new Font("Segoe UI", 10f,FontStyle.Bold);
			form_label.Location = new System.Drawing.Point(form_icon.Width+15, (form_icon.Location.Y / 2) + (form_label.Height/2));
			form_label.ForeColor = config_definitions.APP_THEME;
			form_label.Name = "form_label";
            form_label.Text = GetTitle();
			form_label.Anchor = AnchorStyles.Left;
			this.Controls.Add(form_label);

		
			/* Close Button*/
			close_button = new Button();
			close_button.FlatStyle = FlatStyle.Flat;
			close_button.FlatAppearance.BorderSize = 0;
			close_button.BackgroundImage = Resources.icons8_close_48;
			close_button.BackgroundImageLayout = ImageLayout.Zoom;
			close_button.Size = new System.Drawing.Size(35,32);
			close_button.Location = new Point((Width-8)-close_button.Width, (Height / 2) - (close_button.Height / 2));
			close_button.Anchor = AnchorStyles.Right;
			close_button.Name = "btn_close";
			this.Controls.Add(close_button);
		
			if (Parent.MaximizeBox) { 
			/* Resize Button*/
			resize_button = new Button();
			resize_button.FlatStyle = FlatStyle.Flat;
			resize_button.FlatAppearance.BorderSize = 0;
			resize_button.BackgroundImage = Resources.icons8_maximize_window_48;
			resize_button.BackgroundImageLayout = ImageLayout.Zoom;
			resize_button.Size = new System.Drawing.Size(35,32);
			resize_button.Location = new Point(((close_button.Location.X-8))-resize_button.Width, (Height / 2) - (close_button.Height / 2));
			resize_button.Anchor = AnchorStyles.Right;
			resize_button.Name = "btn_resize";
			this.Controls.Add(resize_button);
			}

			if (Parent.MinimizeBox) { 
			/* Minimize Button*/
			minimize_button = new Button();
			minimize_button.FlatStyle = FlatStyle.Flat;
			minimize_button.FlatAppearance.BorderSize = 0;
			minimize_button.BackgroundImage = Resources.icons8_minus_48;
			minimize_button.BackgroundImageLayout = ImageLayout.Zoom;
			minimize_button.Size = new System.Drawing.Size(35,32);
			minimize_button.Location = new Point(((resize_button.Location.X-8))- minimize_button.Width, (Height / 2) - (close_button.Height / 2));
			minimize_button.Anchor = AnchorStyles.Right;
			minimize_button.Name = "btn_minimize";
			this.Controls.Add(minimize_button);
			}

		}

        private string GetTitle()
        {
			switch (Parent.formTextType)
			{
				case FormTextType.None:
					return "";
				case FormTextType.OnlyFormText:
					return Parent.Text;
				case FormTextType.Default:
				default:
					return config_definitions.ApplicationName + (!string.IsNullOrEmpty(Parent.Text) ? " - " + Parent.Text : "");
            }

        }


		public void AddCustomControl(Control control)
		{
			control.Location = new Point((Controls[Controls.Count -1].Location.X-8)-control.Width, (Height / 2) - (control.Height / 2));
			this.Controls.Add(control);
		}

		
	}
}
