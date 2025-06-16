using CarritoCompras;

ItemCarrito.cs:

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    public class ItemCarrito
    {
        public Producto Producto { get; }
        public int Cantidad { get; private set; }

        public ItemCarrito(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
        }

        public void AumentarCantidad(int cantidad)
        {
            Cantidad += cantidad;
        }

        public decimal Subtotal()
        {
            var total = Producto.Precio * Cantidad;
            if (Cantidad >= 5)
                total *= 0.85m;
            return total;
        }
    }
}