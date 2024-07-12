
using System;
using System.Collections.Generic;

namespace ConsoleApp1.Domain.Entities
{
    public class Order
    {
        private static int _nextId = 0;
        public int Id { get; }  
        public string OrderNumber { get; set; }  
        public string Place { get; set; }  
        public DateTime CreationDate { get; set; }  
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();  
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();


        public Order(int id)  // конструктор с одним параметром – идентификатором
        {
            Id = id;
        }
        private static int GetNextId()
        {
            return _nextId++;
        }

    }
}
