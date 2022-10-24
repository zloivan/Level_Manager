using System;
using LevelManager.MechanicsSystems.Patterns.Prototype;
using UnityEngine;

namespace LevelManager.MechanicsSystems
{
    public class ProjectRootContext : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("Run from start");
            PrototypeRunner.Start();
        }

        private void Awake()
        {
            Debug.Log("Run from awake");
            PrototypeRunner.Awake();
        }

        private void OnEnable()
        {
            Debug.Log("Run from OnEnables");
            PrototypeRunner.OnEnable();
        }
    }
}