using UnityEngine;
using System.Collections;

public class BeastHealth : MonoBehaviour {

    public const int _maxHealth = 5;
    private int _currentHealth = _maxHealth;

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            Debug.Log("Beast Killed");
            SendMessageUpwards("BeastKilled");
            Destroy(gameObject, 1.0f);
        }
    }
}
