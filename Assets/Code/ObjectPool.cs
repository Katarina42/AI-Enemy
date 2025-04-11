using System.Collections.Generic;
using UnityEngine;

namespace AIEnemy
{
    public class ObjectPool<T> : IObjectPool<T> where T : MonoBehaviour 
    {
        private readonly int poolSize;
        private readonly T prefab;
        private readonly Queue<T> pool = new();
    
        public ObjectPool(T prefab, int poolSize)
        {
            this.poolSize = poolSize;
            this.prefab = prefab;
        }
        
        public T Get()
        {
            if (IsPoolEmpty())
            {
                PopulatePool();
            }
            
            return pool.Dequeue();
        }

        public void Return(T obj)
        {
            pool.Enqueue(obj);
        }
        
        private bool IsPoolEmpty()
        {
            return pool.Count == 0;
        }

        private void PopulatePool()
        {
            for (var i = 0; i < poolSize; i++)
            {
                var poolObject = Object.Instantiate(prefab);
                pool.Enqueue(poolObject);
            }
        }

    }

}