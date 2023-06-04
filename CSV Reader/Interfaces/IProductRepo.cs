using CSV_Reader.Entities;

namespace CSV_Reader.Interfaces
{
    public interface IProductRepo : IGenericRepo<Product>
    {
        void Save();
    }
}