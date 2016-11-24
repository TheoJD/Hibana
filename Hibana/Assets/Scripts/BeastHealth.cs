using UnityEngine;
using System.Collections;

public class BeastHealth : MonoBehaviour {

    public const int _maxHealth = 5;
    private int _currentHealth = _maxHealth;
    private AudioSource _damagesSound;

    void Start()
    {
        _damagesSound = GetComponent<AudioSource>();
    }

    public void TakeDamage(int amount)
    {
        _damagesSound.Play();
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            GameManager.GetInstance().BeastKilled();
            Destroy(gameObject, 0.5f);
        }
    }
}
