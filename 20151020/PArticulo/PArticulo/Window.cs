using System;

namespace PArticulo
{
	public partial class Window : Gtk.Window
	{
		public Window () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

