﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class ObjectContext
    {
        private readonly Dictionary<string, object> _objects;

        public ObjectContext()
        {
            _objects = new Dictionary<string, object>();
        }

        #region Getters

        public string Get(string key)
        {
            return _objects.TryGetValue(key, out var value) ? value.ToString() : string.Empty;
        }

        public T Get<T>()
        {
            return Get<T>(typeof(T).FullName);
        }

        public T Get<T>(string key)
        {
            return _objects.TryGetValue(key, out var value) ? (T)value : default(T);
        }

        public IEnumerable<T> GetAll<T>()
        {
            return _objects.Values.OfType<T>();
        }

        public Dictionary<string, object> GetAll()
        {
            return _objects;
        }

        #endregion

        #region Setters

        public void Set<T>(string key, T value)
        {
            _objects.Add(key, value);
        }

        public void Set<T>(T value)
        {
            Set(typeof(T).FullName, value);
        }

        public void Update<T>(T value)
        {
            Update<T>(typeof(T).FullName, value);
        }

        public void Update<T>(string key, T value)
        {
            if (KeyExists<T>(key))
            {
                _objects[key] = value;
            }
            else
            {
                throw new Exception("Object key does not exist and cannot be updated");
            }
        }

        public void Replace<T>(T value)
        {
            Replace<T>(typeof(T).FullName, value);
        }

        public void Replace<T>(string key, T value)
        {
            if (KeyExists<T>(key))
            {
                _objects[key] = value;
            }
            else
            {
                Set(key, value);
            }
        }

        #endregion

        public bool KeyExists<T>(string key)
        {
            return _objects.ContainsKey(key);
        }
    }
}
