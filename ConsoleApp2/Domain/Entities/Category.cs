namespace ConsoleApp1.Domain.Entities
{
    public class Category
    {
        private static int _nextId = 0; // Статическое поле для хранения следующего идентификатора

        public int Id { get; }  // идентификатор категории, доступен только для чтения
        public string Name { get; set; }  



        public Category(int id)  // конструктор с одним параметром – идентификатором
        {
            Id = id;
        }
        private static int GetNextId()
        {
            return _nextId++;
        }
    }
}
