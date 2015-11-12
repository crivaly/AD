using System;
using Gtk;

using SerpisAd;
using PArticulo;
using System.Collections;

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

		deleteAction.Activated += delegate {
			object id = TreeViewHelper.GetId(treeView);
			/*antes de hacer el método: Console.WriteLine ("click en deleteAction id={0}",GetId(treeView));
			if (id == null)
				return;
			*/
			Console.WriteLine("click en deleteAction id={0}",id);
			delete(id);

		};
		// cada vez que cambia la seleccion salta este evento
		treeView.Selection.Changed += delegate {
			Console.WriteLine ("ha pasado un treeView.Selection.Changed");
			//hacemos el método para poner la linea siguiente en vez de esta: deleteAction.Sensitive = GetId (treeView) != null; //si vuelves a pinchar en el objeto se deshabilitan las acciones
			deleteAction.Sensitive = TreeViewHelper.IsSelected(treeView);
		};

		deleteAction.Sensitive = false;

		//newAction.Activated += newActionActivated;
	}

	//método para confirmar eliminación de elemento seleccionado
	private void delete (object id){
		if (ConfirmDelete(this))
			Console.WriteLine ("Dice que sí (eliminar)");

		/* se quita este código y se llama al método: MessageDialog messageDialog = new MessageDialog (
			this,
			DialogFlags.DestroyWithParent,
			MessageType.Question,
			ButtonsType.YesNo,
			"¿Quieres eliminar definitivamente el elemento?"
		);

		ResponseType response = (ResponseType)messageDialog.Run ();
		messageDialog.Destroy ();
		if (response == ResponseType.Yes)
			Console.WriteLine ("Dice que sí (eliminar)");
		*/

	}

	public bool ConfirmDelete ( Window window){
		//TO DO localización del ¿quieres eliminar...?

		MessageDialog messageDialog = new MessageDialog (
			window,
			DialogFlags.DestroyWithParent,
			MessageType.Question,
			ButtonsType.YesNo,
			"¿Quieres eliminar definitivamente el elemento?"
			);

		messageDialog.Title = window.Title;
		ResponseType response = (ResponseType)messageDialog.Run ();
		messageDialog.Destroy ();
		return response == ResponseType.Yes;
	}
		
	


	private void fillTreeView() {
		QueryResult queryResult = PersisterHelper.Get ("select * from articulo");
		TreeViewHelper.Fill (treeView, queryResult);
	}

//	void newActionActivated (object sender, EventArgs e)
//	{
//		new ArticuloView ();
//	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a){
		Application.Quit ();
		a.RetVal = true;
	}

}
