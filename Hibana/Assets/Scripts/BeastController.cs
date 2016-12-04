using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class BeastController : MonoBehaviour
{
    public bool _isPlayerDetected = false;
    public float _jumpDelay = 2.0f;
    private float _nextJump;
    public float _attackDelay = 2.0f;
    private float _nextAttack;
    public float _attackMagnitude = 0.2f;
    public int _attackPower = 10;
    private BeastCharacter _character;
    private Transform _playerTransform;
    private float direction;
    private Vector3 distance;
    private bool jump;
    private bool _isPlayerClosed = false;

    void Start()
    {
        _character = GetComponent<BeastCharacter>();
        _nextJump = Time.time + _jumpDelay;
        _nextAttack = Time.time + _attackDelay;
        GameManager.GetInstance().NewBeast();
    }

    private void FixedUpdate()
    {
        if (!GameManager.GetInstance().isControlEnable())
            return;
        if (_isPlayerDetected)
        {
            Purchase();
        }
        else
        {
            _character.Move(0, false, false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == GameManager.GetInstance().GetPlayerTag())
            _isPlayerClosed = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == GameManager.GetInstance().GetPlayerTag())
            _isPlayerClosed = false;
    }

    void PlayerDetected(Transform playerTransform)
    {
        _isPlayerDetected = true;
        _playerTransform = playerTransform;
    }

    void PlayerRunAway()
    {
        _isPlayerDetected = false;
        _playerTransform = null;
    }

    void Purchase()
    {
        distance = _playerTransform.position - transform.position;
        if (_isPlayerClosed)
        {
            bool attack = false;
            if (_nextAttack <= Time.time)
            {
                GameManager.GetInstance().TakeDamage(_attackPower);
                _nextAttack = Time.time + _attackDelay;
                attack = true;
            }
            _character.Move(0, false, attack);
        }
        else
        {
            jump = false;
            direction = Random.Range(0.0f, 1.0f);
            if (distance.x < 0) direction = -direction;
            if ((distance.y > 0.1f) && (_nextJump <= Time.time))
            {
                jump = true;
                _nextJump = Time.time + _jumpDelay;
            }
            _character.Move(direction, jump, false);
        }
    }
}
