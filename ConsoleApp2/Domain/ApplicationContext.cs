using ConsoleApp1.Domain.Entities;
using System.Collections.Generic;
namespace ConsoleApp1.Domain
{
    public class ApplicationContext
    {
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public ApplicationContext()
        {
            // Предварительное заполнение данных
            SeedData();
        }

        private void SeedData()
        {
            var categories = new[]
                {
                    new Category(0) { Name = "Пицца" },
                    new Category(1) { Name = "Бургеры" },
                    new Category(2) { Name = "Напитки" },
                    new Category(3) { Name = "Гарниры" },
                    new Category(4) { Name = "Десерты" }
                };

            // Создание продуктов
            var products = new[]
            {
                    new Product(0)
                    {
                        Name = "Пепперони",
                        Description = "Классическая пицца с пикантной пепперони,  моцареллой и томатным соусом.",
                        Categories = new List<Category> { categories[0] },
                        Protein = 15.0,
                        Fats = 11.2,
                        Carbohydrates = 20.6,
                        Calories = 269.3,
                        Price = 285.0m
                    },
                    new Product(1)
                    {
                        Name = "Маргарита",
                        Description = "Простая, но элегантная пицца с томатным соусом,  моцареллой и свежим базиликом.",
                        Categories = new List<Category> { categories[0] },
                        Protein = 10.5,
                        Fats = 9.0,
                        Carbohydrates = 24.0,
                        Calories = 208.0,
                        Price = 260.0m
                    },
                    new Product(2)
                    {
                        Name = "Чизбургер",
                        Description = "Сочный говяжий бургер с расплавленным сыром чеддер,  луком,  помидорами и маринованными огурцами.",
                        Categories = new List<Category> { categories[1] },
                        Protein = 16.0,
                        Fats = 12.0,
                        Carbohydrates = 31.0,
                        Calories = 302.0,
                        Price = 100.0m
                    },
                    new Product(3)
                    {
                        Name = "Воппер",
                        Description = "Большой,  сочный бургер с  говяжьей котлетой,  салатом,  помидором,  луком и  майонезом.",
                        Categories = new List<Category> { categories[1] },
                        Protein = 21.3,
                        Fats = 33.0,
                        Carbohydrates = 50.0,
                        Calories = 289.0,
                        Price = 120.0m
                    },
                    new Product(4)
                    {
                        Name = "Кола",
                        Description = "Классический газированный напиток, освежающий и утоляющий жажду.",
                        Categories = new List<Category> { categories[2] },
                        Protein = 0.0,
                        Fats = 0.0,
                        Carbohydrates = 10.6,
                        Calories = 42.0,
                        Price = 50.0m
                    },
                    new Product(5)
                    {
                        Name = "Фанта",
                        Description = "Свежий и фруктовый газированный напиток с ароматом цитрусовых.",
                        Categories = new List<Category> { categories[2] },
                        Protein = 0.0,
                        Fats = 0.0,
                        Carbohydrates = 8.0,
                        Calories = 33.0,
                        Price = 50.0m
                    },
                    new Product(6)
                    {
                        Name = "Картофель фри",
                        Description = "Золотистые, хрустящие картофельные брусочки, идеально сочетающиеся с любым блюдом.",
                        Categories = new List<Category> { categories[3] },
                        Protein = 3.8,
                        Fats = 15.5,
                        Carbohydrates = 30.0,
                        Calories = 276.0,
                        Price = 170.0m
                    },
                    new Product(7)
                    {
                        Name = "Кукурузные шарики",
                        Description = "Нежные кукурузные шарики, обжаренные до золотистой корочки, с легким сливочным вкусом.",
                        Categories = new List<Category> { categories[3] },
                        Protein = 7.0,
                        Fats = 37.0,
                        Carbohydrates = 50.0,
                        Calories = 350.0,
                        Price = 130.0m
                    },
                    new Product(8)
                    {
                        Name = "Чизкейк",
                        Description = "Нежный чизкейк с нежной текстурой и классическим сливочным вкусом.",
                        Categories = new List<Category> { categories[4] },
                        Protein = 3.0,
                        Fats = 21.0,
                        Carbohydrates = 22.0,
                        Calories = 293.0,
                        Price = 120.0m
                    },
                    new Product(9)
                    {
                        Name = "Сандей",
                        Description = "Холодный и освежающий десерт из мороженого, взбитых сливок и фруктового соуса.",
                        Categories = new List<Category> { categories[4] },
                        Protein = 4.6,
                        Fats = 5.0,
                        Carbohydrates = 36.0,
                        Calories = 223.0,
                        Price = 110.0m
                    }
                };
            Products.AddRange(products);
            Categories.AddRange(categories);
        }


    }
}
