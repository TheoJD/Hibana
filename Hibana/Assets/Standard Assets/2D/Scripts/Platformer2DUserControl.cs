using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        public bool _canFire = true;
        public GameObject _firePrefab;
        public Transform _fireSpawn;
        public int _fireSpeed = 6;
        public float _timeBetweenFires = 1.0f;
        public float _fireTimeOfLife = 1.0f;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
            if (_canFire)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine(Fire());
                }
            }
        }

        private IEnumerator Fire()
        {
            _canFire = false;
            Transform fireSpawn =_fireSpawn;
            Vector3 direction = m_Character.isFacingRight() ? fireSpawn.right : -fireSpawn.right;

            var fire = (GameObject)Instantiate( _firePrefab, fireSpawn.position, fireSpawn.rotation);
  /*          Vector3 direction = Input.mousePosition - transform.position;
            direction.z = transform.position.z;*/
            fire.GetComponent<Rigidbody2D>().velocity = direction * _fireSpeed;
            Destroy(fire, _fireTimeOfLife);
            yield return new WaitForSeconds(_timeBetweenFires);
            _canFire = true;
        }

        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
