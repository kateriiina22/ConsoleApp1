using ConsoleApp1.Domain;
using ConsoleApp1.Domain.Entities;
using ConsoleTables;
using System;
using System.Linq;

namespace ConsoleApp1
{
    public class Program
    {
        static ApplicationContext context = new ApplicationContext();
        static Order currentOrder = null;

        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Терминал для заказа.");
                Console.WriteLine("Введите номер действия.");
                Console.WriteLine("1. В зале");
                Console.WriteLine("2. С собой");
                Console.WriteLine("3. Просмотр заказов");
                Console.WriteLine("[q – завершить работу]");

                string input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }

                switch (input)
                {
                    case "1":
                        StartOrder("в зале");
                        break;
                    case "2":
                        StartOrder("с собой");
                        break;
                    case "3":
                        ViewOrders();
                        break;
                    default:
                        Console.WriteLine("Неверный ввод, попробуйте еще раз.");
                        break;
                }
            }
        }

        static void StartOrder(string place)
        {
            currentOrder = new Order(context.Orders.Count + 1)
            {
                Place = place,
                CreationDate = DateTime.Now,
                OrderNumber = GenerateOrderNumber()
            };
            SelectCategory();
        }

        static void SelectCategory()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Терминал для заказа.");
                Console.WriteLine("Введите категорию.");

                for (int i = 0; i < context.Categories.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {context.Categories[i].Name}");
                }
                Console.WriteLine("[b – назад, p – оформить заказ, c - отменить заказ, q – завершить работу]");

                string input = Console.ReadLine();

                if (input == "b")
                {
                    return;
                }
                else if (input == "p")
                {
                    ConfirmOrder();
                    return;
                }
                else if (input == "c")
                {
                    CancelOrder();
                    return;
                }
                else if (input == "q")
                {
                    Environment.Exit(0);
                }

                if (int.TryParse(input, out int categoryIndex) && categoryIndex > 0 && categoryIndex <= context.Categories.Count)
                {
                    SelectProduct(context.Categories[categoryIndex - 1]);
                }
                else
                {
                    Console.WriteLine("Неверный ввод, попробуйте еще раз.");
                }
            }
        }

        static void SelectProduct(Category category)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Терминал для заказа. Категория: {category.Name}");
                Console.WriteLine("Выберите продукт:");

                var products = context.Products
                    .Where(p => p.Categories.Any(c => c.Id == category.Id))
                    .ToList();

                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {products[i].Name} ({products[i].Price} руб.)");
                }

                Console.WriteLine("[b - назад, p - оформить заказ, c - отменить заказ, q - завершить работу]");

                string input = Console.ReadLine();

                if (input == "b")
                {
                    return;
                }
                else if (input == "p")
                {
                    ConfirmOrder();
                    return;
                }
                else if (input == "c")
                {
                    CancelOrder();
                    return;
                }
                else if (input == "q")
                {
                    Environment.Exit(0);
                }

                if (int.TryParse(input, out int productIndex) && productIndex > 0 && productIndex <= products.Count)
                {
                    AddProductToOrder(products[productIndex - 1]);
                }
                else
                {
                    Console.WriteLine("Неверный ввод, попробуйте еще раз.");
                }
            }
        }

        static void AddProductToOrder(Product product)
        {
            Console.Clear();
            Console.WriteLine("Терминал для заказа.");
            Console.WriteLine($"Введите количество для {product.Name}:");
            Console.WriteLine("[b – назад, p – оформить заказ, c - отменить заказ, q – завершить работу]");

            string input = Console.ReadLine();

            if (input == "b")
            {
                return;
            }

            else if (input == "p")
            {
                ConfirmOrder();
                return;
            }

            else if (input == "c")
            {
                CancelOrder();
                return;
            }
            else if (input == "q")
            {
                Environment.Exit(0);
            }

            if (int.TryParse(input, out int quantity) && quantity > 0)
            {
                currentOrder.Items.Add(new OrderItem(currentOrder.Items.Count + 1, product, quantity));
                ProductAddedToOrder();
            }
            else
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз.");
            }
        }

        static void ProductAddedToOrder()
        {
            Console.Clear();
            Console.WriteLine("Терминал для заказа.");
            Console.WriteLine("Продукт успешно добавлен в заказ. Введите номер действия.");
            Console.WriteLine("1. Продолжить выбор продуктов");
            Console.WriteLine("[b – назад, p – оформить заказ, c - отменить заказ, q – завершить работу]");

            string input = Console.ReadLine();

            if (input == "1")
            {
                SelectCategory();
            }
            else if (input == "b")
            {
                SelectCategory();
            }
            else if (input == "p")
            {
                ConfirmOrder();
            }
            else if (input == "c")
            {
                CancelOrder();
            }
            else if (input == "q")
            {
                Environment.Exit(0);
            }
        }

        static void ConfirmOrder()
        {
            Console.Clear();
            Console.WriteLine("Терминал для заказа.");
            Console.WriteLine("Ваш заказ сформирован.");
            decimal total = 0;
            foreach (var item in currentOrder.Items)
            {
                decimal itemTotal = item.Product.Price * item.Quantity;
                total += itemTotal;
                Console.WriteLine($"{item.Product.Name} x {item.Quantity} = {itemTotal} руб.");
            }
            Console.WriteLine($"Итого = {total} руб.");
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("[b – назад, a – подтвердить заказ, c - отменить заказ, q – завершить работу]");

            string input = Console.ReadLine();

            if (input == "b")
            {
                SelectCategory();
            }
            else if (input == "a")
            {
                FinalizeOrder();
            }
            else if (input == "c")
            {
                CancelOrder();
            }
            else if (input == "q")
            {
                Environment.Exit(0);
            }
        }

        static void FinalizeOrder()
        {
            Console.Clear();
            Console.WriteLine("Терминал для заказа.");
            Console.WriteLine("Ваш заказ оформлен!");
            context.Orders.Add(currentOrder);
            currentOrder = null;
            Console.WriteLine("[m – в меню, q – завершить работу]");

            string input = Console.ReadLine();

            if (input == "m")
            {
                MainMenu();
            }
            else if (input == "q")
            {
                Environment.Exit(0);
            }
        }

        static void CancelOrder()
        {
            Console.Clear();
            Console.WriteLine("Терминал для заказа.");
            Console.WriteLine("Ваш заказ отменен!");
            currentOrder = null;
            Console.WriteLine("[m – в меню, q – завершить работу]");

            string input = Console.ReadLine();

            if (input == "m")
            {
                MainMenu();
            }
            else if (input == "q")
            {
                Environment.Exit(0);
            }
        }

        static void ViewOrders()
        {
            Console.Clear();
            Console.WriteLine("Терминал для заказа.");
            Console.WriteLine("Список заказов:");

            var table = new ConsoleTable("Номер заказа", "Место", "Дата", "Продукты", "Цена");

            foreach (var order in context.Orders)
            {
                var products = string.Join(", ", order.Items.Select(item => $"{item.Product.Name} x {item.Quantity}"));
                table.AddRow(order.OrderNumber, order.Place, order.CreationDate.ToString("g"), products, order.Items.Sum(item => item.Product.Price * item.Quantity));
            }

            table.Options.EnableCount = false;
            table.Write(Format.MarkDown);

            Console.WriteLine("[m – в меню, q – завершить работу]");

            string input = Console.ReadLine();

            if (input == "m")
            {
                MainMenu();
            }
            else if (input == "q")
            {
                Environment.Exit(0);
            }
        }

        static string GenerateOrderNumber()
        {
            var lastOrder = context.Orders.OrderByDescending(o => o.Id).FirstOrDefault();
            if (lastOrder != null && lastOrder.OrderNumber != null)
            {
                string lastOrderNumber = lastOrder.OrderNumber;
                int lastNumber = int.Parse(lastOrderNumber.Split('-')[1]);

                int newNumber = (lastNumber + 1) % 100;
                return $"A-{newNumber:00}";
            }
            else
            {
                return "A-00";
            }
        }
    }
}