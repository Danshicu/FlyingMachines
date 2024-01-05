using System;
using System.Collections;
using System.Collections.Generic;
using Systems;
using UnityEngine;
using Weapons.Shootables;

public class HealthSystem : MonoBehaviour, IBeatable
{
    [SerializeField] private int _maxHealth;
    public int MaxHealth => _maxHealth;

    [SerializeField]
    private int _currentHealth;

    public Action<int> OnHealthChanged;
    
    public int CurrentHealth
    {
        get => _currentHealth;
        private set
        {
            _currentHealth = value;
            OnHealthChanged?.Invoke(_currentHealth);
            if (value < 0)
            {
                Die();
            }
            
        }
    }

    private void OnEnable()
    {
        CurrentHealth = _maxHealth;
    }

    public void TakeDamage(IShootable shootable)
    {
        var health = CurrentHealth - shootable.Damage;
        CurrentHealth = health;
    }

    private void Die()
    {
       gameObject.SetActive(false); 
    }
}
