using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class EnemyController : MonoBehaviour
    {
        public bool _playerDetected = true;
        private bool _canJump = false;
        private PlatformerCharacter2D _character;
        public Transform _playerTransform;
        // Use this for initialization
        void Start()
        {
            _character = GetComponent<PlatformerCharacter2D>();
            StartCoroutine(WaitForJump());
        }

        // Update is called once per frame
        void Update()
        {
            if (_playerDetected)
            {
                float direction = Random.Range(0.0f,1.0f);
                bool jump = false;
                Vector3 distance = _playerTransform.position - transform.position;
                if (distance.x < 0)
                    direction = Random.Range(-1.0f, 0.0f);
                if (_canJump && distance.y > 1)
                {
                    jump = true;
                    _canJump = false;
                    Debug.Log("Gonna Jump");
                }
                _character.Move(direction, false, jump);
            }
        }

        IEnumerator WaitForJump()
        {
            while (true)
            {
                if (!_canJump)
                {
                    _canJump = true;
                    Debug.Log("Enabling jump");
                    yield return new WaitForSeconds(2);
                }
            }
        }
    }
}