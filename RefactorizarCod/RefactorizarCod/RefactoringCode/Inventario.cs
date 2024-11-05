namespace RefactorizarCod.RefactoringCode
{
    public class Inventario
    {

        private List<Producto> productos = new List<Producto>();

        // Crear nuevo producto
        public void CrearProducto(int id, string nombre, decimal precio, int cantidadStock)
        {
            if (productos.Any(p => p.ID == id))
            {
                Console.WriteLine("El producto con este ID ya existe.");
            }
            else
            {
                productos.Add(new Producto { ID = id, Nombre = nombre, Precio = precio, CantidadStock = cantidadStock });

                Console.WriteLine("Producto añadido exitosamente.");
            }

        }

        // Mostrar lista de productos
        public void MostrarProductos()
        //evaluar si hay productos antes para evitar hacer el loop
        {

            if (!productos.Any())
            {
                Console.WriteLine("No hay productos en la lista.");
                return;
            }

            Console.WriteLine("Lista de Productos:");
            foreach (var producto in productos)
            {
                Console.WriteLine($"ID: {producto.ID}, Nombre: {producto.Nombre}, Precio: {producto.Precio}, Stock: {producto.CantidadStock}");
            }
        }

        // Buscar producto por nombre
        public Producto BuscarProductoPorNombre(string nombre)
        {
            return productos.FirstOrDefault(p => p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
        }

        // Actualizar precio del producto
        public void ActualizarPrecioProducto(int id, decimal nuevoPrecio)
        {
            var producto = productos.FirstOrDefault(p => p.ID == id);
            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                Console.WriteLine($"El precio del producto con ID {id} ha sido actualizado a {nuevoPrecio:C}.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }
        static void Main(string[] args)
        {
            Inventario inventario = new Inventario();

            // Crear productos (simplificado)
            inventario.CrearProducto(1, "Laptop", 1500, 10);
            inventario.CrearProducto(2, "Mouse", 20, 100);

            // Mostrar productos
            inventario.MostrarProductos();

            // Buscar producto
            Console.WriteLine("Ingrese el nombre del producto a buscar:");
            string nombreProducto = Console.ReadLine();
            var producto = inventario.BuscarProductoPorNombre(nombreProducto);
            if (producto != null)
            {
                Console.WriteLine($"Producto encontrado: {producto.Nombre} - Precio: {producto.Precio:C}");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }

            // Actualizar precio
            Console.WriteLine("Ingrese el ID del producto a actualizar:");
            int idProducto = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo precio:");
            decimal nuevoPrecio = Convert.ToDecimal(Console.ReadLine());
            inventario.ActualizarPrecioProducto(idProducto, nuevoPrecio);

            // Mostrar productos actualizados
            inventario.MostrarProductos();
        }
    }
}
