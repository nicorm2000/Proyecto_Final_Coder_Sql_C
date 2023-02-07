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

        Usuario login = userManager.Login("tcasazza", "SoyTobiasCasazza");
        List<Usuario> allusers = userManager.GetUsers();
        Usuario oneuser = userManager.GetUserById(1);

        List<Venta> sales = saleManager.GetSalesById(1);
        List<Producto> productsales = productSaleManager.GetProductSales(1);
        List<Producto> products = productManager.GetProducts(1);

        Console.ReadLine();
    }
}