﻿namespace CSV_Reader.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        void CreateDataBase();
        void Delete(object id);
        void Delete(T? entityToDelete);
        IQueryable<T> GetAll();
        Task<T?> GetByIDAsync(int? id);
        void Insert(T entity);
        void Update(T entityToUpdate);
    }
}