// <copyright file="IObjectContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace DFC.TestAutomation.UI.TestSupport
{
    public interface IObjectContext
    {
        public string Get(string key);

        public T Get<T>();

        public T Get<T>(string key);

        public IEnumerable<T> GetAll<T>();

        public Dictionary<string, object> GetAll();

        public void Set<T>(string key, T value);

        public void Set<T>(T value);

        public void Update<T>(T value);

        public void Update<T>(string key, T value);
    }
}
