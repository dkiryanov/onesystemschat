using System;
using System.Collections.Generic;

namespace DAL.Repositories.Interfaces
{
    /// <summary>
    /// Generic repository pattern's interface.
    /// </summary>
    public interface ICommonRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets all entities from DB
        /// </summary>
        /// <returns>A collection of the entities</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Gets an entity by its ID
        /// </summary>
        /// <param name="id">Entit's ID</param>
        /// <returns>Entity, if it was found by ID given, null another way.</returns>
        TEntity Get(object id);

        /// <summary>
        /// Finds the entities by predicate given 
        /// </summary>
        /// <param name="predicate">A predicate to search through the entities.</param>
        /// <returns>A collection of the entities that match the predicate given.</returns>
        IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate);

        /// <summary>
        /// Adds an entity to DB.
        /// </summary>
        /// <param name="entity">An entity to add.</param>
        /// <returns>Added entity</returns>
        TEntity Create(TEntity entity);

        /// <summary>
        /// Updates entity.
        /// </summary>
        /// <param name="entity">An entity to update.</param>
        /// <returns>Updated entity</returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Deletes an entity form DB.
        /// </summary>
        /// <param name="id">Entity's ID</param>
        /// <returns>An entity that has been deleted from the DB.</returns>
        TEntity Delete(int id);
    }
}