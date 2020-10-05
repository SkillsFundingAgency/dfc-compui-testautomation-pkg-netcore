// <copyright file="IMongoDatabaseHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// An interface containing definitions for all Mongo database related operations.
    /// </summary>
    public interface IMongoDatabaseHelper
    {
        /// <summary>
        /// Deletes a single document from a collection.
        /// </summary>
        /// <typeparam name="T">The document type.</typeparam>
        /// <param name="collectionName">The name of the collection.</param>
        /// <param name="filterDefinition">A Mongo database filter definition.</param>
        /// <returns>A task containing information on the result of the delete operation.</returns>
        Task<DeleteResult> DeleteDocumentAsync<T>(string collectionName, FilterDefinition<T> filterDefinition);

        /// <summary>
        /// Creates a single document from a collection.
        /// </summary>
        /// <typeparam name="T">The document type.</typeparam>
        /// <param name="collectionName">The name of the collection.</param>
        /// <param name="data">A collection of document models.</param>
        /// <returns>A task representing the asyncronous operation.</returns>
        Task CreateMultipleDocumentsAsync<T>(string collectionName, IEnumerable<T> data);
    }
}
