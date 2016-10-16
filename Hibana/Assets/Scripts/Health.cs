using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public const int _maxHealth = 100;
    private int _currentHealth = _maxHealth;

    public Image _healthBar;
	
    void Start()
    {
//        StartCoroutine(LoseLife());
    }

	public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            Debug.Log("Game over !");
        }
        _healthBar.fillAmount = (float)_currentHealth / (float)_maxHealth;
    }

/*    public IEnumerator LoseLife()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            TakeDamage(Random.Range(5, 20));
            yield return new WaitForSeconds(2);
        }
    }*/
}
