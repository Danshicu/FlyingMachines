using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(HealthSystem))]
public class Player : MonoBehaviour
{
    public HealthSystem Health
    {
        get;
        private set;
    }
    private PlayerMovement _movement;
    
    
    void OnEnable()
    {
        
    }

    
    void Update()
    {
        
    }
}
