using Google.Protobuf.WellKnownTypes;
using LongShiftLanguage.libs.multilanguage_support;
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
	
	public static NotifyIcon CreateNotification(string content,string title = "",Icon icon = null,int seconds = 3000,string content_long = "")
	{
		if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(title)) return null;

		if (icon == null) icon = SystemIcons.Information;
		notifyIcon.BalloonTipTitle = title;
		notifyIcon.BalloonTipText = content;
		notifyIcon.Tag = content_long;
        notifyIcon.Icon = icon;
		notifyIcon.Visible = true;
		notifyIcon.ShowBalloonTip(seconds);
        notifyIcon.BalloonTipClicked += (s, e) =>
        {
            MessageBox.Show(content_long, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
        };
        ;
        return notifyIcon;
    }

}

