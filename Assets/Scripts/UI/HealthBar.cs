using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        private HealthSystem _healthSystem;
        [SerializeField] private Slider _barSlider;
        private float _maxValue;
        
        
        public void Bind(HealthSystem healthSystem)
        {
            _healthSystem = healthSystem;
            _healthSystem.OnHealthChanged += RefreshHealth;
            _maxValue = healthSystem.MaxHealth;
            RefreshHealth(healthSystem.CurrentHealth);
        }

        private void RefreshHealth(int value)
        {
            _barSlider.value = value / _maxValue;
        }

        private void OnDisable()
        {
            _healthSystem.OnHealthChanged -= RefreshHealth;
        }
    }
}