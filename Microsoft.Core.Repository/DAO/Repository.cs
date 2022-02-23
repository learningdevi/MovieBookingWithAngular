/*
 * Copyright - Microsoft
 */
using Microsoft.Core.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Microsoft.Core.Repository.DAO
{
    /// <summary>
    /// This class represents API to connect to DB.
    /// </summary>
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly ILogger<Repository<T>> logger;

        private MovieBookingContext MovieBookingContext { get; set; }

        private DbSet<T> DbSet { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="dbContext">Represents <see cref="MovieBookingContext"/>.</param>
        /// <param name="logger">Represents <see cref="Logger"/>object.</param>
        public Repository(MovieBookingContext dbContext, ILogger<Repository<T>> logger)
        {
            MovieBookingContext = dbContext;
            DbSet = dbContext.Set<T>();
            this.logger = logger;
        }

        /// <summary>
        /// Get the data from DB
        /// </summary>
        /// <param name="includes">Represents include list</param>
        /// <returns>Returns list of object</returns>
        public IEnumerable<T> GetAll(string[] includes)
        {
            try
            {
                return LoadDependentEntity(includes);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading DB : {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Get the data by Id
        /// </summary>
        /// <param name="id">Represents Id</param>
        /// <returns>Returns list of object</returns>
        public T Get(int id)
        {
            T? entity = null;
            try
            {
                entity = DbSet.Find(id);
            }
            catch(Exception ex)
            {
                logger.LogError($"Exception occured while reading DB : { ex.Message}");
            }
            return entity;
        }

        /// <summary>
        /// Save the data into DB
        /// </summary>
        /// <param name="entity">Represents entity</param>
        /// <returns>Returns entity which is saved to DB</returns>
        public T Save(T entity)
        {
            try
            {
                SaveChanges(entity);
                return entity;
            }
            catch(Exception ex)
            {
                logger.LogError($"Exception occured while saving data in DB : {ex.Message}");
                return entity;
            }
        }

        private void SaveChanges(T entity)
        {
            bool isExistingRecord = DbSet.Contains(entity);

            if (isExistingRecord)
                MovieBookingContext.Update(entity);
            else
                MovieBookingContext.Add(entity);

            MovieBookingContext.SaveChanges();
        }

        /// <summary>
        /// Eagerly load all the dependent entity
        /// </summary>
        /// <param name="includes">Represents include list</param>
        /// <returns>Returns record collection of type T </returns>
        private IEnumerable<T> LoadDependentEntity(string[] includes)
        {
            if (includes != null && includes.Length > 0)
            {
                IQueryable<T> query = this.DbSet;

                foreach (var item in includes)
                {
                    query = query.Include(item);
                }

                return query.ToList();
            }

            return this.DbSet.ToList();
        }
    }
}
