using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    private int _minHealth = 0;
    private int _maxHealth = 100;

    public event UnityAction<int> HealthChanged;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void ApplyDamage(int damage)
    {
        if (_health > _minHealth)
        {
            _health -= damage;
            HealthChanged?.Invoke(_health);
        }
    }

    public void ApplyHeal(int heal)
    {
        if (_health < _maxHealth)
        {
            _health += heal;
            HealthChanged?.Invoke(_health);
        }
    }
}
