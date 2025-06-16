using CarritoCompras;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    public class Producto
    {
        public int Codigo { get; }
        public string Nombre { get; }
        public decimal Precio { get; }
        public int Stock { get; private set; }
        public Categoria Categoria { get; }

        public Producto(int codigo, string nombre, decimal precio, int stock, Categoria categoria)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
            Categoria = categoria;
        }

        public bool ReducirStock(int cantidad)
        {
            if (cantidad <= 0 || cantidad > Stock) return false;
            Stock -= cantidad;
            return true;
        }

        public void AumentarStock(int cantidad)
        {
            if (cantidad > 0) Stock += cantidad;
        }
    }
}