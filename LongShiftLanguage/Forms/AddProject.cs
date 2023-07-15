using LongShiftLanguage.Classes;
using LongShiftLanguage.Classes.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LongShiftLanguage.Forms
{
	public partial class AddProject : LSForm
	{

		DatabaseConnection database;
		public AddProject(DatabaseConnection database)
		{
			InitializeComponent();
			this.database = database;
		}

		public string base64Img;

		private void btn_loadimage_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string imagePath = openFileDialog.FileName;
				byte[] imageBytes = File.ReadAllBytes(imagePath);
				string base64String = Convert.ToBase64String(imageBytes);
				base64Img = base64String;

				// Base64 stringini PictureBox kontrolünde görüntüle
				pb_project_image.Image = ConvertBase64ToImage(base64String);
			}
		}

		private Image ConvertBase64ToImage(string base64String)
		{
			byte[] imageBytes = Convert.FromBase64String(base64String);

			using (MemoryStream ms = new MemoryStream(imageBytes))
			{
				Image image = Image.FromStream(ms);
				return image;
			}
		}

		private void btn_continue_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(tb_proj_name.Text))
			{

				NotificationManager.CreateNotification("Proje Adı Boş Olamaz", "Uyarı", SystemIcons.Error);

				return;
			}

			Project project = new Project(database,0);
			project.name = tb_proj_name.Text;
			project.photo = base64Img;
			if (project.CreateProject())
			{
				NotificationManager.CreateNotification("Proje Oluşturuldu", "İşlem Başarılı", SystemIcons.Information);
				this.Close();
			}
			else
			{
				NotificationManager.CreateNotification("Proje Oluşturulamadı", "İşlem Başarısız", SystemIcons.Error);

			}


		}
	}
}
