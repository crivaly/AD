using Gtk;
using System;
using SerpisAd;
using PArticulo;


public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnNewActionActivated (object sender, EventArgs e)
	{
		new ArticuloView ();
	}
}
