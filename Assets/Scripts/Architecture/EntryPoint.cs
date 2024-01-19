using System;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Architecture
{
    public class EntryPoint : MonoBehaviour
    {
        //[SerializeField] private List<HealthSystem> _systems;
        //[SerializeField] private PlayerUISetter _manager;

        private void OnEnable()
        {
            EventBus.PlayerEvents.OnPlayerSpawned += HandlePlayerSpawn;
        }

        private void Start()
        {
            // foreach (var system in _systems)
            // {
            //     _manager.AddHealthBar(system);
            // }
        }

        private void HandlePlayerSpawn(Player player)
        {
            //_manager.AddHealthBar(player.Health);
        }
        
        private void OnDisable()
        {
            EventBus.PlayerEvents.OnPlayerSpawned -= HandlePlayerSpawn;
        }
    }
}