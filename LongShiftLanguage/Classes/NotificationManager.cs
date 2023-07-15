using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
public static class NotificationManager
	{

	private static NotifyIcon notifyIcon = new NotifyIcon();
	
	public static void CreateNotification(string content,string title = "",Icon icon = null,int seconds = 3000)
	{
		if (icon == null) icon = SystemIcons.Information;
		notifyIcon.BalloonTipTitle = title;
		notifyIcon.BalloonTipText = content;
		notifyIcon.Icon = icon;
		notifyIcon.Visible = true;
		notifyIcon.ShowBalloonTip(seconds); 
	}


}

