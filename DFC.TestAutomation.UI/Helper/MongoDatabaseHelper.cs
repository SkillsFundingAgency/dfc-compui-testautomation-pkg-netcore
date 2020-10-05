// <copyright file="MongoDatabaseHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// Provides helper functions for all Mongo database related operations.
    /// </summary>
    public class MongoDatabaseHelper : IMongoDatabaseHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDatabaseHelper"/> class.
        /// </summary>
        /// <param name="mongoDatabaseSettings">Mongo database settings.</param>
        public MongoDatabaseHelper(Settings.MongoDatabaseSettings mongoDatabaseSettings)
        {
            var client = new MongoClient(mongoDatabaseSettings?.ConnectionString);
            this.Database = client.GetDatabase(mongoDatabaseSettings.DatabaseName);
        }

        private IMongoDatabase Database { get; set; }

        /// <summary>
        /// Deletes a single document from a collection.
        /// </summary>
        /// <typeparam name="T">The document type.</typeparam>
        /// <param name="collectionName">The name of the collection.</param>
        /// <param name="filterDefinition">A Mongo database filter definition.</param>
        /// <returns>A task containing information on the result of the delete operation.</returns>
        public async Task<DeleteResult> DeleteDocumentAsync<T>(string collectionName, FilterDefinition<T> filterDefinition)
        {
            return await this.Database.GetCollection<T>(collectionName).DeleteOneAsync(filterDefinition).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a single document from a collection.
        /// </summary>
        /// <typeparam name="T">The document type.</typeparam>
        /// <param name="collectionName">The name of the collection.</param>
        /// <param name="data">A collection of document models.</param>
        /// <returns>A task representing the asyncronous operation.</returns>
        public async Task CreateMultipleDocumentsAsync<T>(string collectionName, IEnumerable<T> data)
        {
            await this.Database.GetCollection<T>(collectionName).InsertManyAsync(data).ConfigureAwait(false);
        }
    }
}
