using RefactorizarCod.RefactoringCode;
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
        //        Console.WriteLine("Producto no encontrado.");
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
