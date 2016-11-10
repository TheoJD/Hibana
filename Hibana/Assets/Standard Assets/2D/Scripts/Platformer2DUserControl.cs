using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        protected PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool m_Attack;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        virtual protected void Update()
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
        }

        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump, m_Attack);
            m_Jump = false;
            m_Attack = false;
        }
    }
}
