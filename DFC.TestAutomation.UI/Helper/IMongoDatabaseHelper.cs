// <copyright file="IMongoDatabaseHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.TestAutomation.UI.Helper
{
    public interface IMongoDatabaseHelper
    {
        Task<DeleteResult> DeleteDocumentAsync<T>(string collectionName, FilterDefinition<T> filterDefinition);

        Task CreateMultipleDocumentsAsync<T>(string collectionName, IEnumerable<T> data);
    }
}
