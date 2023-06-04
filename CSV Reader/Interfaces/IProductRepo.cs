using CSV_Reader.Entities;

namespace CSV_Reader.Interfaces
{
    public interface IProductRepo : IGenericRepo<Product>
    {
        void DropTable(string tableName);
        void Insert(List<Product> entity);
        void Save();
    }
}