using Proyecto_Final_Coder2023;
using Proyecto_Final_Coder2023.Managers;
using Proyecto_Final_Coder2023.Models;
using System.Collections.Generic;
using System;

public class Program
{
    private static void Main(string[] args)
    {
        UserManager userManager = new UserManager();
        SaleManager saleManager = new SaleManager();
        ProductSaleManager productSaleManager = new ProductSaleManager();
        ProductManager productManager = new ProductManager();

        List<Usuario> allusers = userManager.GetUsers();
        
        Usuario oneuser = userManager.GetUserById(1);

        Console.WriteLine(oneuser);

        List<Producto> products = productManager.GetProducts(1);

        foreach (var product in products)
        {
            Console.WriteLine(product.Descripciones);
        }

        List<Producto> productsales = productSaleManager.GetProductSales(1);
        
        foreach (var product in productsales)
        {
            Console.WriteLine(product.Descripciones);
        }

        List<Venta> sales = saleManager.GetSalesById(1);

        foreach (var sale in sales)
        {
            Console.WriteLine($"Venta {sale.Id}, realizada por usuario: {sale.IdUsuario}");
        }

        Usuario login = userManager.Login("eperez", "SoyErnestoPerez");

        if (login.Username != null)
        {
            Console.WriteLine($"Bienvenido {login.Username}");
        }
        else
        {
            Console.WriteLine("El ingreso no fue realizado");
        }
    }
}