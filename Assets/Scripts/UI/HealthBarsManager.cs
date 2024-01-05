using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class HealthBarsManager : MonoBehaviour
    {
        [SerializeField] private HealthBar _healthBarPrefab;
        private List<Tuple<HealthBar, HealthSystem>> _healthbars = new List<Tuple<HealthBar, HealthSystem>>();

        public void AddHealthBar(HealthSystem system)
        {
            var healthbar = Instantiate(_healthBarPrefab, system.transform);
            healthbar.Bind(system);
            _healthbars.Add(new Tuple<HealthBar, HealthSystem>(healthbar, system));
        }


        private void Update()
        {
            foreach (var healthbar in _healthbars)
            {
                Vector3 screenPosition = Camera.main.WorldToScreenPoint(healthbar.Item2.transform.position);
                healthbar.Item1.transform.position = screenPosition;
            }
        }
    }
}