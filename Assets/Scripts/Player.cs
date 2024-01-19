using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UI;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(HealthSystem))]
[RequireComponent(typeof(PlayerInputActions))]
[RequireComponent(typeof(PlayerInput))]
public class Player : NetworkBehaviour
{
    
    public HealthSystem Health;
    [SerializeField] private PlayerUISetter _uiSetter;
    [SerializeField] private WeaponController _weaponController;
    private PlayerMovement _movement;
    private PlayerInput _playerInput;
    
    void OnEnable()
    {
        _playerInput = GetComponent<PlayerInput>();
        _movement = GetComponent<PlayerMovement>();
        EventBus.PlayerEvents.CallOnPlayerSpawned(this);
        _uiSetter.AddHealthBar(Health);
        var playerInputActions = new PlayerInputActions();
        _movement.GetInputListener(playerInputActions);
        _weaponController.StartControlWeapons(playerInputActions.InMatchInput.Fire);
    }

    
    void Update()
    {
        
    }
}
