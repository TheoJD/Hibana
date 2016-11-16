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
    public float _attackMagnitude = 1.0f;
    public int _attackPower = 10;
    private PlatformerCharacter2D _character;
    public Transform _playerTransform;
    private float direction;
    private Vector3 distance;
    private bool jump;

    void Start()
    {
        _character = GetComponent<PlatformerCharacter2D>();
        _nextJump = Time.time + _jumpDelay;
        _nextAttack = Time.time + _attackDelay;
        GameManager.GetInstance().NewBeast();
    }

    private void FixedUpdate()
    {
        if (_isPlayerDetected)
        {
            Purchase();
        }
        else
        {
            _character.Move(0, false, false, false);
        }
    }

    void PlayerDetected(bool detected)
    {
        _isPlayerDetected = detected;
    }

    bool isPlayerClosed (double magnitude)
    {
        return (magnitude <= _attackMagnitude);
    }

    void Purchase()
    {
        distance = _playerTransform.position - transform.position;
        if (isPlayerClosed(distance.magnitude))
        {
            bool attack = false;
            if (_nextAttack <= Time.time)
            {
                GameManager.GetInstance().TakeDamage(_attackPower);
                _nextAttack = Time.time + _attackDelay;
                attack = true;
            }
            _character.Move(0, false, false, attack);
        }
        else
        {
            jump = false;
            direction = Random.Range(0.0f, 1.0f);
            if (distance.x < 0) direction = -direction;
            if ((distance.y > 1) && (_nextJump <= Time.time))
            {
                jump = true;
                _nextJump = Time.time + _jumpDelay;
            }
            _character.Move(direction, false, jump, false);
        }
    }
}
