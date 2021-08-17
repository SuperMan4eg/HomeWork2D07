using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _healthBar;

    private Coroutine _healthBarChangerJob;
    private int _healthRate = 10;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        StartHealthBarChanger(health);
    }

    private void StartHealthBarChanger(int health)
    {
        if (_healthBarChangerJob != null)
        {
            StopCoroutine(_healthBarChangerJob);
        }
        _healthBarChangerJob = StartCoroutine(HealthBarChanger(health));
    }

    private IEnumerator HealthBarChanger(int health)
    {
        while (_healthBar.value != health)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, health, _healthRate * Time.deltaTime);

            yield return null;
        }
    }
}
