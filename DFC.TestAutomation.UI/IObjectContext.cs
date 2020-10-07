// <copyright file="IObjectContext.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace DFC.TestAutomation.UI
{
    /// <summary>
    /// An interface containing definitions for all object context operations.
    /// </summary>
    public interface IObjectContext
    {
        /// <summary>
        /// Gets an object using the object key.
        /// </summary>
        /// <param name="key">The key used to store the object.</param>
        /// <returns>The object.</returns>
        public string GetObject(string key);

        /// <summary>
        /// Gets an object using the object type.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <returns>The object.</returns>
        public T GetObject<T>();

        /// <summary>
        /// Gets an object using the object key.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="key">The key used to store the object.</param>
        /// <returns>The object.</returns>
        public T GetObject<T>(string key);

        /// <summary>
        /// Gets all objects with a given type.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <returns>All objects with a specific type.</returns>
        public IEnumerable<T> GetAll<T>();

        /// <summary>
        /// Gets all objects.
        /// </summary>
        /// <returns>All objects.</returns>
        public Dictionary<string, object> GetAll();

        /// <summary>
        /// Sets an object with a key.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The object.</param>
        public void SetObject<T>(string key, T value);

        /// <summary>
        /// Sets an object with a type.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="value">The object.</param>
        public void SetObject<T>(T value);

        /// <summary>
        /// Overwrites an existing object using the object type.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="value">The object.</param>
        public void UpdateObject<T>(T value);

        /// <summary>
        /// Overwrites an existing object using the object key.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="key">The object key.</param>
        /// <param name="value">The object.</param>
        public void UpdateObject<T>(string key, T value);
    }
}
