using System.Collections.Generic;
using ProductsValidation.Models;

namespace ProductsValidation.Services
{
    public class Data
    {
        public List<Product> Products = new()
        {
            new Product() {Id = 1, Name = "Product2", Description = "ProductDescription", Type = Product.Category.Technique},
            new Product() {Id = 2, Name = "Product3", Description = "ProductDescription"},
            new Product() {Id = 3, Name = "Product4", Description = "ProductDescription", Type = Product.Category.Clothes},
            new Product() {Id = 4, Name = "Product5", Description = "ProductDescription"},
            new Product() {Id = 5, Name = "Product6", Description = "ProductDescription", Type = Product.Category.Transport},
            new Product() {Id = 6, Name = "Product1", Description = "ProductDescription", Type = Product.Category.Transport}
        };

        public List<User> Users = new List<User>
        {
            new User() {Id = 1, Name = "UserAdmin", Email = "admin@gmail.com", Role = "admin"},
            new User() {Id = 2, Name = "Guest", Email = "guest@gmail.com", Role = "guest"},
            new User() {Id = 3, Name = "User", Email = "user1@gmail.com", Role = "user"},
            new User() {Id = 4, Name = "User2", Email = "user2@gmail.com", Role = "user"},
        };

        
    }
}
