using UnityEngine;

namespace AIEnemy
{
    public interface IObjectPool<T> where T : MonoBehaviour
    {
        public T Get();
        public void Return(T obj);
    }
}