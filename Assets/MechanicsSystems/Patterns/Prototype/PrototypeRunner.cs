
using UnityEngine;

namespace LevelManager.MechanicsSystems.Patterns.Prototype
{
    public static class PrototypeRunner
    {
        static PrototypeRunner()
        {
            MainPrivate();
        }

        private static void MainPrivate()
        {
            Debug.Log("From Static constructor");
        }

        public static void Awake()
        {
            
        }

        public static void Start()
        {
        }

        public static void OnEnable()
        {
        }
    }
}