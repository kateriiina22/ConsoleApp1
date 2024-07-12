
namespace ConsoleApp1.Domain.Entities
{
    public class OrderItem
    {
        private static int _nextId = 0;
        public int Id { get; }  
        public int ProductId { get; set; }  
        public Product Product { get; set; }  
        public int Quantity { get; set; }  

        public OrderItem(int id, Product product, int quantity)  // конструктор с одним параметром – идентификатором
        {
            Id = id;
            Product = product;
            ProductId = product?.Id ?? 0;  // устанавливаем ProductId на основе Id продукта
            Quantity = quantity;
        }

        private static int GetNextId()
        {
            return _nextId++;
        }
    }
}
