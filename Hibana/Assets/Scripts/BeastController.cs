using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class BeastController : MonoBehaviour
{
    public bool _isPlayerDetected = false;
    public float _jumpDelay = 2.0f;
    private float _nextJump;
    private PlatformerCharacter2D _character;
    public Transform _playerTransform;

    void Start()
    {
        _character = GetComponent<PlatformerCharacter2D>();
        _nextJump = Time.time + _jumpDelay;
    }

    private void FixedUpdate()
    {
        float direction;
        Vector3 distance;
        bool jump;
        if (_isPlayerDetected)
        {
            direction = Random.Range(0.0f, 1.0f);
            distance = _playerTransform.position - transform.position;
            jump = false;
            if (distance.x < 0)
                direction = Random.Range(-1.0f, 0.0f);
            if ((distance.y > 1) && (_nextJump <= Time.time))
            {
                jump = true;
                _nextJump = Time.time + _jumpDelay;
            }
            _character.Move(direction, false, jump);
        }
        else
        {
            _character.Move(0, false, false);
        }
    }

    void PlayerDetected(bool detected)
    {
        _isPlayerDetected = detected;
    }
}
