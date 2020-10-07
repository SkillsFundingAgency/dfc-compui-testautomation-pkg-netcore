// <copyright file="ObjectContext.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace DFC.TestAutomation.UI
{
    /// <summary>
    /// The object context is used to store all test related objects during a test run. This provides a container for any object
    /// to be stored so the object is accessible across different classes.
    /// </summary>
    public class ObjectContext : IObjectContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectContext"/> class.
        /// </summary>
        public ObjectContext()
        {
            this.Objects = new Dictionary<string, object>();
        }

        private Dictionary<string, object> Objects { get; set; }

        /// <summary>
        /// Gets an object using the object key.
        /// </summary>
        /// <param name="key">The key used to store the object.</param>
        /// <returns>The object.</returns>
        public string GetObject(string key)
        {
            return this.Objects.TryGetValue(key, out var value) ? value.ToString() : string.Empty;
        }

        /// <summary>
        /// Gets an object using the object type.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <returns>The object.</returns>
        public T GetObject<T>()
        {
            return this.GetObject<T>(typeof(T).FullName);
        }

        /// <summary>
        /// Gets an object using the object key.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="key">The key used to store the object.</param>
        /// <returns>The object.</returns>
        public T GetObject<T>(string key)
        {
            return this.Objects.TryGetValue(key, out var value) ? (T)value : default(T);
        }

        /// <summary>
        /// Gets all objects with a given type.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <returns>All objects with a specific type.</returns>
        public IEnumerable<T> GetAll<T>()
        {
            return this.Objects.Values.OfType<T>();
        }

        /// <summary>
        /// Gets all objects.
        /// </summary>
        /// <returns>All objects.</returns>
        public Dictionary<string, object> GetAll()
        {
            return this.Objects;
        }

        /// <summary>
        /// Sets an object with a key.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The object.</param>
        public void SetObject<T>(string key, T value)
        {
            this.Objects.Add(key, value);
        }

        /// <summary>
        /// Sets an object with a type.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="value">The object.</param>
        public void SetObject<T>(T value)
        {
            this.SetObject(typeof(T).FullName, value);
        }

        /// <summary>
        /// Overwrites an existing object using the object type.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="value">The object.</param>
        public void UpdateObject<T>(T value)
        {
            this.UpdateObject(typeof(T).FullName, value);
        }

        /// <summary>
        /// Overwrites an existing object using the object key.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="key">The object key.</param>
        /// <param name="value">The object.</param>
        public void UpdateObject<T>(string key, T value)
        {
            if (this.Objects.ContainsKey(key))
            {
                this.Objects[key] = value;
            }
            else
            {
                throw new Exception("Object key does not exist and cannot be updated");
            }
        }
    }
}
