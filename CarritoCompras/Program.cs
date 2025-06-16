using System;

namespace CarritoCompras
{
    class Program
    {
        static void Main(string[] args)
        {
            var tienda = new Tienda();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine();
                Console.WriteLine("== El Supermerk2 de Rubin y el Mondo ===");
                Console.WriteLine("1- Ver categorías");
                Console.WriteLine("2- Ver todos los productos");
                Console.WriteLine("3- Ver productos por categoría");
                Console.WriteLine("4- Agregar producto al carrito");
                Console.WriteLine("5- Eliminar producto del carrito");
                Console.WriteLine("6- Ver carrito");
                Console.WriteLine("7- Ver total a pagar");
                Console.WriteLine("8- Finalizar compra");
                Console.Write("Elegí opción: ");

                var op = Console.ReadLine();
                Console.WriteLine();

                switch (op)
                {
                    case "1":
                        Console.WriteLine("Categorías:");
                        foreach (var c in tienda.Categorias)
                            Console.WriteLine($"- {c.Nombre}: {c.Descripcion}");
                        break;

                    case "2":
                        Console.WriteLine("Productos:");
                        foreach (var p in tienda.Productos)
                            Console.WriteLine($"[{p.Codigo}] {p.Nombre} - ${p.Precio} - stock: {p.Stock}");
                        break;

                    case "3":
                        Console.Write("¿Qué categoría? ");
                        var cat = Console.ReadLine();
                        var lista = tienda.ObtenerProductosPorCategoria(cat);
                        if (lista.Count == 0) Console.WriteLine("Esa no existe o está vacía.");
                        else foreach (var p in lista)
                                Console.WriteLine($"[{p.Codigo}] {p.Nombre} - ${p.Precio} - stock: {p.Stock}");
                        break;

                    case "4":
                        Console.Write("Código a agregar: ");
                        if (int.TryParse(Console.ReadLine(), out int codA))
                        {
                            var prodA = tienda.ObtenerProductoPorCodigo(codA);
                            if (prodA == null) { Console.WriteLine("Código inválido."); break; }
                            Console.Write("Cantidad: ");
                            if (int.TryParse(Console.ReadLine(), out int cantA))
                            {
                                if (tienda.Carrito.AgregarProducto(prodA, cantA))
                                    Console.WriteLine("Agregado al carrito ");
                                else
                                    Console.WriteLine("No se pudo agregar (stock/valor inválido).");
                            }
                            else Console.WriteLine("Cantidad inválida.");
                        }
                        else Console.WriteLine("Código inválido.");
                        break;

                    case "5":
                        Console.Write("Código a quitar: ");
                        if (int.TryParse(Console.ReadLine(), out int codR))
                        {
                            if (tienda.Carrito.EliminarProducto(codR))
                                Console.WriteLine("eliminado del carrito ");
                            else
                                Console.WriteLine("No está en el carrito.");
                        }
                        else Console.WriteLine("Código inválido.");
                        break;

                    case "6":
                        Console.WriteLine("Carrito:");
                        if (tienda.Carrito.Items.Count == 0)
                        {
                            Console.WriteLine("  (vacío)");
                        }
                        else
                        {
                            foreach (var it in tienda.Carrito.Items)
                                Console.WriteLine(
                                  $"[{it.Producto.Codigo}] {it.Producto.Nombre} x{it.Cantidad} -> Sub: ${it.Subtotal():0.00}");
                        }
                        break;

                    case "7":
                        Console.WriteLine($"Subtotal: ${tienda.Carrito.CalcularSubtotal():0.00}");
                        Console.WriteLine($"Total (+IVA21%): ${tienda.Carrito.CalcularTotal():0.00}");
                        break;

                    case "8":
                        Console.WriteLine($"Total a pagar: ${tienda.Carrito.CalcularTotal():0.00}");
                        Console.Write("Confirmás compra? (s/n) ");
                        var resp = Console.ReadLine();
                        if (resp?.ToLower() == "s")
                        {
                            foreach (var it in tienda.Carrito.Items)
                                it.Producto.ReducirStock(it.Cantidad);
                            tienda.Carrito.Vaciar();
                            Console.WriteLine("Compra hecha, gracias wacho, volve pronto");
                        }
                        else Console.WriteLine("Compra cancelada.");
                        break;



                    default:
                        Console.WriteLine("Opción inválida, probá de nuevo.");
                        break;
                }
            }
        }
    }
}