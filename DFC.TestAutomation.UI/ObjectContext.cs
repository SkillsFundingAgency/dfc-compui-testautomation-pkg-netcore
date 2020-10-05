// <copyright file="ObjectContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace DFC.TestAutomation.UI
{
    public class ObjectContext : IObjectContext
    {
        public ObjectContext()
        {
            this.Objects = new Dictionary<string, object>();
        }

        private Dictionary<string, object> Objects { get; set; }

        public string Get(string key)
        {
            return this.Objects.TryGetValue(key, out var value) ? value.ToString() : string.Empty;
        }

        public T Get<T>()
        {
            return this.Get<T>(typeof(T).FullName);
        }

        public T Get<T>(string key)
        {
            return this.Objects.TryGetValue(key, out var value) ? (T)value : default(T);
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.Objects.Values.OfType<T>();
        }

        public Dictionary<string, object> GetAll()
        {
            return this.Objects;
        }

        public void Set<T>(string key, T value)
        {
            this.Objects.Add(key, value);
        }

        public void Set<T>(T value)
        {
            this.Set(typeof(T).FullName, value);
        }

        public void Update<T>(T value)
        {
            this.Update(typeof(T).FullName, value);
        }

        public void Update<T>(string key, T value)
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
