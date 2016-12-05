using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BeastHealth : MonoBehaviour {

    public const int _maxHealth = 5;
    private int _currentHealth = _maxHealth;
    private AudioSource _damagesSound;
    public Image _healthBar;
    private Vector3 _flipVector = new Vector3(0f, 0f, 180f);

    void Start()
    {
        _damagesSound = GetComponent<AudioSource>();
    }

    public void Flip()
    {
        _healthBar.transform.Rotate(_flipVector);
    }

    public void TakeDamage(int amount)
    {
        _damagesSound.Play();
        _currentHealth -= amount;
        _healthBar.fillAmount = (float)_currentHealth / (float)_maxHealth;
        if (_currentHealth <= 0)
        {
            GameManager.GetInstance().BeastKilled();
            Destroy(gameObject, 0.3f);
        }
    }
}
