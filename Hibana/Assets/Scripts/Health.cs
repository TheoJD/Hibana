using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

//    public const int _maxHealth = 100;
//    private int _currentHealth = _maxHealth;

//    public Image _healthBar;
	
    void Start()
    {
    }

	public void TakeDamage(int amount)
    {
        GameManager.GetInstance().TakeDamage(amount);
 //       _healthBar.fillAmount = (float)_currentHealth / (float)_maxHealth;
    }
}
