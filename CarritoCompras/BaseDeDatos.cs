using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CarritoCompras
{
    public static class BaseDeDatos
    {
        public static List<Categoria> ObtenerCategorias()
        {
            return new List<Categoria>
            {
                new Categoria("Alimentos",   "Productos comestibles"),
                new Categoria("Electrónica", "Aparatos y gadgets"),
                new Categoria("Ropa",        "Prendas de vestir")
            };
        }

        public static List<Producto> ObtenerProductos(List<Categoria> cats)
        {
            var lista = new List<Producto>();
            int codigo = 1;
            var alim = cats.Find(c => c.Nombre == "Alimentos");
            var elec = cats.Find(c => c.Nombre == "Electrónica");
            var ropa = cats.Find(c => c.Nombre == "Ropa");

            lista.Add(new Producto(codigo++, "Manzana", 10.5m, 100, alim));
            lista.Add(new Producto(codigo++, "Leche", 45.0m, 50, alim));
            lista.Add(new Producto(codigo++, "Celular", 15000.0m, 10, elec));
            lista.Add(new Producto(codigo++, "Auriculares", 2500.0m, 20, elec));
            lista.Add(new Producto(codigo++, "Camisa", 1200.0m, 20, ropa));
            lista.Add(new Producto(codigo++, "Jean", 2500.0m, 15, ropa));

            return lista;
        }
    }
}
