using System;
using System.Reflection;

namespace PReflection
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			//todo esto esta comentado porque vamos  a trabajar con la clase Foo

			// el {0} coge el valor de la variable que hay a continuación

//			object i = 33;
//			Type typeI= i.GetType ();
//			//antes de crear el método utilizamos esto: Console.WriteLine ("typeI.Name={0}", typeI.Name);
//			showType (typeI);
//
//			object s="hola";
//			Type typeS = s.GetType ();
//			//antes de crear el método utilizamos esto: Console.WriteLine ("typeS.Name={0}", typeS.Name);
//			showType (typeS);
//
//			Type typeX = typeof(string);
//			//antes de crear el método utilizamos esto: Console.WriteLine ("typeX.Name={0}", typeX.Name);
//			showType (typeX);
//
//			Type typeO = typeof(object); //falla con object porque éste no tiene BaseType
//			showType (typeO);

//			
//			Type typeFoo = typeof(Foo);
//			showType (typeFoo); // muestra la clase Foo (el tipo: Foo)
			
			Articulo articulo = new Articulo ();
//			showType (articulo.GetType());
//			articulo.Nombre = "nuevo 33";
//			articulo.Categoria = 2;
//			articulo.Precio=decimal.Parse("3,5");

			setValues (articulo,
			           new object []{33L, "nuevo 33 modificado", 3L, decimal.Parse("33,33")});
			showObject (articulo);

		}


		private static void showType (Type type){
			Console.WriteLine ("type.Name={0} type.FullName ={1} type.BaseType={2}",
			                   type.Name, type.FullName, type.BaseType);
			PropertyInfo[] propertyInfos = type.GetProperties ();
			foreach (PropertyInfo propertyInfo in propertyInfos)
				Console.WriteLine ("propertyInfo.Name={0} propertyInfo.PropertyType={1}",
				                   propertyInfo.Name, propertyInfo.PropertyType);

		}

		private static void showObject (object obj){
			Type type = obj.GetType ();
			PropertyInfo[] propertyInfos = type.GetProperties ();
			foreach (PropertyInfo propertyInfo in propertyInfos) {
				Console.WriteLine ("{0}={1}", propertyInfo.Name, 
				                   propertyInfo.GetValue (obj, null));
					
			}	
		}
		
		private static void setValues (object obj,object []values){
			Type type = obj.GetType ();
			PropertyInfo[] propertyInfos = type.GetProperties ();
			int index=0;
			foreach (PropertyInfo propertyInfo in propertyInfos){
				propertyInfo.SetValue (obj, values[index++],null);
			}	
		}
	


	public class Foo { //la clase es un tipo, en este caso de tipo Foo
		private object id;

		public object Id {
			get {
				return id;
			}
			set {
				id = value;
			}
		}


		private	string name;

		public string Name {
			get {
				return name;
			}
			set {
				name = value;
			}
		}
	}
		// [Entity]
		public class Articulo
		{
			public Articulo ()
			{
			}

			private object id;
			private string nombre;
			private object categoria;
			private decimal precio;

			//[Id]
			public object Id {
				get { 
					return id;
				}
				set { 
					id = value;
				}
			}

			//[Colum("name")]
			public string Nombre {
				get {
					return nombre;
				}
				set { 
					nombre = value; 
				}
			}


			public object Categoria {
				get {
					return categoria;
				}
				set {
					categoria = value;
				}
			}


			public decimal Precio {
				get {
					return precio;
				}
				set {
					precio = value;
				}
			}
		}
	}
}
