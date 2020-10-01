using System;
using System.Collections.Generic;
using System.Linq;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class ObjectContext : IObjectContext
    {
        private Dictionary<string, object> Objects { get; set; }

        public ObjectContext()
        {
            Objects = new Dictionary<string, object>();
        }

        public string Get(string key)
        {
            return Objects.TryGetValue(key, out var value) ? value.ToString() : string.Empty;
        }

        public T Get<T>()
        {
            return Get<T>(typeof(T).FullName);
        }

        public T Get<T>(string key)
        {
            return Objects.TryGetValue(key, out var value) ? (T)value : default(T);
        }

        public IEnumerable<T> GetAll<T>()
        {
            return Objects.Values.OfType<T>();
        }

        public Dictionary<string, object> GetAll()
        {
            return Objects;
        }

        public void Set<T>(string key, T value)
        {
            Objects.Add(key, value);
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
            if (Objects.ContainsKey(key))
            {
                Objects[key] = value;
            }
            else
            {
                throw new Exception("Object key does not exist and cannot be updated");
            }
        }
    }
}
