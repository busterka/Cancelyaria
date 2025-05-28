using Cancelyaria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class CartService
{
    private static List<Product> cartProducts = new List<Product>();

    public static void AddProduct(Product product)
    {
        cartProducts.Add(product);
    }

    public static List<Product> GetCartProducts()
    {
        return cartProducts;
    }

    public static void ClearCart()
    {
        cartProducts.Clear();
    }
}