﻿namespace Dynamic.Translator.Core.Optimizers
{
    #region using

    using System.Collections.Concurrent;

    #endregion

    public class Pool<T> : IPool<T>
    {
        private readonly ConcurrentDictionary<T, T> _pool = new ConcurrentDictionary<T, T>();

        public T GetOrCreate(T obj)
        {
            T result;

            if (!_pool.TryGetValue(obj, out result))
            {
                _pool[obj] = obj;
                result = obj;
            }
            return result;
        }
    }
}