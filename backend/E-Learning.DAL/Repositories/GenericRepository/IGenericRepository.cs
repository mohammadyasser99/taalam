﻿namespace E_Learning.DAL.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        /*------------------------------------------------------------------------*/
        // Get All
        IEnumerable<T> GetAll();
        /*------------------------------------------------------------------------*/
        // Get One By Id
        T? GetById(int id);
        /*------------------------------------------------------------------------*/
        // Create
        void Create(T entity);
        /*------------------------------------------------------------------------*/
        // Update
        void Update(T entity);
        /*------------------------------------------------------------------------*/
        // Delete
        void Delete(T entity);
        /*------------------------------------------------------------------------*/
    }
}