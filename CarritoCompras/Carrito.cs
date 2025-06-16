using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CarritoCompras
{
    public class Carrito
    {
        private List<ItemCarrito> items = new List<ItemCarrito>();
        public IReadOnlyList<ItemCarrito> Items => items.AsReadOnly();

        public bool AgregarProducto(Producto prod, int cantidad)
        {
            if (cantidad <= 0) return false;
            if (prod.Stock < cantidad) return false;

            var existente = items.Find(i => i.Producto.Codigo == prod.Codigo);
            if (existente != null)
            {
                if (prod.Stock < existente.Cantidad + cantidad) return false;
                existente.AumentarCantidad(cantidad);
            }
            else
            {
                items.Add(new ItemCarrito(prod, cantidad));
            }
            return true;
        }

        public bool EliminarProducto(int codigo)
        {
            var item = items.Find(i => i.Producto.Codigo == codigo);
            if (item == null) return false;
            items.Remove(item);
            return true;
        }

        public decimal CalcularSubtotal()
        {
            decimal suma = 0;
            foreach (var i in items)
                suma += i.Subtotal();
            return suma;
        }

        public decimal CalcularTotal()
        {
            var sub = CalcularSubtotal();
            return sub * 1.21m;
        }

        public void Vaciar()
        {
            items.Clear();
        }
    }
}