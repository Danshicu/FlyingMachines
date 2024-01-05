using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _barImage;
        private float _maxValue;
        
        public void Bind(HealthSystem healthSystem)
        {
            healthSystem.OnHealthChanged += RefreshHealth;
            _maxValue = healthSystem.MaxHealth;
            RefreshHealth(healthSystem.CurrentHealth);
        }

        private void RefreshHealth(int value)
        {
            _barImage.fillAmount = value / _maxValue;
        }
    }
}