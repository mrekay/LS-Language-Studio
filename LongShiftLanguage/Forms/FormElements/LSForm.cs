using LongShiftLanguage.Forms.FormElements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class LSForm : Form
{

	public bool ShowCustomControlBox = true;
	public string FormText;
	public ControlsBox ControlsBox;

	public LSForm()
	{
		Init();
    }

	private void Init()
	{
        this.DoubleClick += _DoubleClick;
        this.MouseDown += _MouseDown;
        this.MouseMove += _MouseMove;
        this.MouseUp += _MouseUp;

        this.Shown += LSForm_Shown;
    }

	private void LSForm_Shown(object sender, EventArgs e)
	{
		if (ShowCustomControlBox)
			InitalizeControlBox();

		if (FindObjectOfName("btn_close") != null) (FindObjectOfName("btn_close") as Button).Click += btn_close_Click;
		if (FindObjectOfName("btn_resize") != null) (FindObjectOfName("btn_resize") as Button).Click += btn_resize_Click;
		if (FindObjectOfName("btn_minimize") != null) (FindObjectOfName("btn_minimize") as Button).Click += btn_minimize_Click;
	}

	void InitalizeControlBox()
	{
		ControlsBox = new ControlsBox(this);
		ControlsBox.SendToBack();

		ControlsBox.DoubleClick += _DoubleClick;
		ControlsBox.MouseDown += _MouseDown;
		ControlsBox.MouseMove += _MouseMove;
		ControlsBox.MouseUp += _MouseUp;

	}


	public Object FindObjectOfName(string name, Control.ControlCollection control = null)
	{
		if (control == null) control = this.Controls;
		foreach (Control cntrl in control)
		{
			if (cntrl.Controls.Count > 0)
			{
				var obj = FindObjectOfName(name, cntrl.Controls);
				if (obj != null)
					return obj;
			}
			else {
				if (cntrl.Name == name) return cntrl; 
			}
		}
		return null;
	}

	#region FormEvents
	bool tutus;
	int FareX, FareY;

	private void _DoubleClick(object sender, EventArgs e)
	{
		if (!MaximizeBox) return;
		SetMaxSize();
		WindowState = WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
		
	}
	private void _MouseDown(object sender, MouseEventArgs e)
	{
		tutus = true;
		FareX = Cursor.Position.X - this.Left;
		FareY = Cursor.Position.Y - this.Top;
	}

	private void _MouseUp(object sender, MouseEventArgs e)
	{
		tutus = false;
		FareX = 0;
		FareY = 0;

		SetMaxSize();
	}
	private void _MouseMove(object sender, MouseEventArgs e)
	{
		if (tutus == true)
		{
			if (WindowState == FormWindowState.Maximized) WindowState = FormWindowState.Normal;
			this.Left = Cursor.Position.X - FareX;
			this.Top = Cursor.Position.Y - FareY;

		}
	}

	private void btn_close_Click(object sender, EventArgs e)
	{
		this.Close();
	}

	private void btn_resize_Click(object sender, EventArgs e)
	{
		WindowState = WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
	}

	private void btn_minimize_Click(object sender, EventArgs e)
	{
		WindowState = WindowState == FormWindowState.Minimized ? FormWindowState.Normal : FormWindowState.Minimized;
	}


	private void SetMaxSize()
	{
		try
		{
			Screen currentScreen = Screen.FromControl(this);
			Rectangle workingArea = currentScreen.WorkingArea;
			Rectangle desktopArea = currentScreen.Bounds;
			int taskbarHeight = desktopArea.Height - workingArea.Height;

			this.MaximumSize = new Size(int.MaxValue, (desktopArea.Height - taskbarHeight) + 24);
			
		}
		catch { Application.Exit(); }
	}
	#endregion
}

