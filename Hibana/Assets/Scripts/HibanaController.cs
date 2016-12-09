using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class HibanaController : MonoBehaviour
{
    public bool _canFire = true;
    public GameObject _firePrefab;
    public GameObject _fireSpawn;
    public float _fireSpeed = 0.6f;
    public float _timeBetweenFires = 1.0f;
    public float _fireTimeOfLife = 1.0f;
    protected HibanaCharacter _character;
    private bool _jump;
    private bool _attack;

    private void Awake()
    {
        _character = GetComponent<HibanaCharacter>();
    }

    void Update ()
    {
        if (!GameManager.GetInstance().isControlEnable())
            return;
        if (!_jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            _jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
        if (!_attack)
        {
            _attack = Input.GetMouseButtonDown(0);
        }
        if (_canFire && _attack && GameManager.GetInstance().getLoads() > 0)
        {
            StartCoroutine(Fire());
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.GetInstance().isControlEnable())
            return;
        // Read the inputs.
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        _character.Move(h, _jump, _attack);
        _jump = false;
        _attack = false;
    }

    private IEnumerator Fire()
    {
        _canFire = false;
        Transform fireSpawn = _fireSpawn.transform;
        _fireSpawn.GetComponent<AudioSource>().Play();
        Vector3 direction = _character.isFacingRight() ? fireSpawn.right : -fireSpawn.right;

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
