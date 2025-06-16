using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarritoCompras
{
    public class Tienda
    {
        public List<Categoria> Categorias { get; }
        public List<Producto> Productos { get; }
        public Carrito Carrito { get; }

        public Tienda()
        {
            Categorias = BaseDeDatos.ObtenerCategorias();
            Productos = BaseDeDatos.ObtenerProductos(Categorias);
            Carrito = new Carrito();
        }

        public List<Producto> ObtenerProductosPorCategoria(string nombreCat)
        {
            return Productos.FindAll(p =>
                p.Categoria.Nombre.ToLower() ==
                nombreCat.ToLower());
        }

        public Producto ObtenerProductoPorCodigo(int codigo)
        {
            return Productos.Find(p => p.Codigo == codigo);
        }
    }
}