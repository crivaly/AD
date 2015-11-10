using System;
using Gtk;

using SerpisAd;
using PArticulo;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		Console.WriteLine ("MainWindow ctor.");
		fillTreeView ();

		newAction.Activated += delegate {
			new ArticuloView();
		};

		refreshAction.Activated += delegate {
			fillTreeView();
		};
		//newAction.Activated += newActionActivated;
	}

	private void fillTreeView() {
		QueryResult queryResult = PersisterHelper.Get ("select * from articulo");
		TreeViewHelper.Fill (treeView, queryResult);
	}

//	void newActionActivated (object sender, EventArgs e)
//	{
//		new ArticuloView ();
//	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

}
