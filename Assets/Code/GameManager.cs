using System;
using UnityEngine;

namespace AIEnemy
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GridSystem gridSystem;
        
        private void Awake()
        {
            gridSystem.Resolve();    
        }
    }
}