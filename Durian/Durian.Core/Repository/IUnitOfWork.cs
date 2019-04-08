﻿// Copyright (c) Arch team. All rights reserved.

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Durian.Core.Repository
{
    /// <summary>
    /// Defines the interface(s) for unit of work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the specified repository for the <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="hasCustomRepository"><c>True</c> if providing custom repositry</param>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>An instance of type inherited from <see cref="IRepository{TEntity}"/> interface.</returns>
        IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class;

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        int SaveChanges();

        /// <summary>
        /// Asynchronously saves all changes made in this unit of work to the database.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous save operation. The task result contains the number of state entities written to database.</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Uses TrackGraph Api to attach disconnected entities
        /// </summary>
        /// <param name="rootEntity"> Root entity</param>
        /// <param name="callback">Delegate to convert Object's State properties to Entities entry state.</param>
        void TrackGraph(object rootEntity, Action<EntityEntryGraphNode> callback);

        void Begin();
        void Commit();
    }
}
