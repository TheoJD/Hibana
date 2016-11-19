using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class HibanaController : MonoBehaviour
{
    public bool _canFire = true;
    public GameObject _firePrefab;
    public Transform _fireSpawn;
    public float _fireSpeed = 0.6f;
    public float _timeBetweenFires = 1.0f;
    public float _fireTimeOfLife = 1.0f;
    protected HibanaCharacter m_Character;
    private bool m_Jump;
    private bool m_Attack;

    private void Awake()
    {
        m_Character = GetComponent<HibanaCharacter>();
    }

    void Update ()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
        if (!m_Attack)
        {
            m_Attack = Input.GetMouseButtonDown(0);
        }
        if (_canFire && Input.GetMouseButtonDown(0) && GameManager.GetInstance().getLoads() > 0)
        {
            StartCoroutine(Fire());
        }
    }

    private void FixedUpdate()
    {
        // Read the inputs.
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        m_Character.Move(h, m_Jump, m_Attack);
        m_Jump = false;
        m_Attack = false;
    }

    private IEnumerator Fire()
    {
        _canFire = false;
        Transform fireSpawn = _fireSpawn;
        Vector3 direction = m_Character.isFacingRight() ? fireSpawn.right : -fireSpawn.right;

        var fire = (GameObject)Instantiate(_firePrefab, fireSpawn.position, fireSpawn.rotation);
        fire.GetComponent<Rigidbody2D>().velocity = direction * _fireSpeed;
        Destroy(fire, _fireTimeOfLife);
        GameManager.GetInstance().LoadMunition(-1);
        float _subTime = _timeBetweenFires / 100f;
        GameManager.GetInstance().SetHUDLoadWait(0f);
        for (float i=0.01f; i<=1f; i+=0.01f)
        {
            yield return new WaitForSeconds(_subTime);
            GameManager.GetInstance().SetHUDLoadWait(i);
        }
        _canFire = true;
    }
}
