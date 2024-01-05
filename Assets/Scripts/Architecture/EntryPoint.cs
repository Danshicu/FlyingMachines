using System;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Architecture
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private List<HealthSystem> _systems;
        [SerializeField] private HealthBarsManager _manager;

        private void Start()
        {
            foreach (var system in _systems)
            {
                _manager.AddHealthBar(system);
            }
        }
    }
}