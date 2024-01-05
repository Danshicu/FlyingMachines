using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(HealthSystem))]
public class Player : NetworkBehaviour
{
    public HealthSystem Health;
    private PlayerMovement _movement;
    
    
    void OnEnable()
    {
        EventBus.PlayerEvents.CallOnPlayerSpawned(this);
    }

    
    void Update()
    {
        
    }
}
