
using System.Collections.Generic;

namespace ConsoleApp1.Domain.Entities
{
    public class Product
    {
        private static int _nextId = 0; // Статическое поле для хранения следующего идентификатора

        public int Id { get; }  
        public string Name { get; set; } 
        public string Description { get; set; }  
        public List<Category> Categories { get; set; }  
        public double Protein { get; set; }  
        public double Fats { get; set; }  
        public double Carbohydrates { get; set; }  
        public double Calories { get; set; }  
        public decimal Price { get; set; }  


        public Product(int id)  // конструктор с одним параметром – идентификатором
        {
            Id = id;
        }
        private static int GetNextId()
        {
            return _nextId++;
        }
    }
}
