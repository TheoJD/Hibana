using UnityEngine;
using System.Collections;

public class HibanaCharacter : MonoBehaviour {

    [SerializeField] private float _maxSpeed = 2f;                    // The fastest the player can travel in the x axis.
    [SerializeField] private float _jumpForce = 450f;                  // Amount of force added when the player jumps.
    [SerializeField] private float _doubleJumpForce = 400f;            // Amount of force added when the player double jumps.
    [SerializeField] private bool _airControl = true;                 // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character
    [SerializeField] private bool _hasDoubleJump = true;
    [SerializeField] private AudioClip _jumpClip;
    [SerializeField] private AudioClip _doubleJumpClip;

    private Transform _groundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .08f; // Radius of the overlap circle to determine if grounded
    private bool _isGrounded;            // Whether or not the player is grounded.
    private bool _doubleJumpEnable = true;
 //   private Transform m_CeilingCheck;   // A position marking where to check for ceilings
    const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
    private Animator _animator;            // Reference to the player's animator component.
    private Rigidbody2D _rigidbody;
    private bool _isFacingRight = true;  // For determining which way the player is currently facing.
    private AudioSource _audioSource;

    private void Awake()
    {
        // Setting up references.
        _groundCheck = transform.Find("GroundCheck");
 //       m_CeilingCheck = transform.Find("CeilingCheck");
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }


    private void FixedUpdate()
    {
        _isGrounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Ground")
            {
                _isGrounded = true;
                _doubleJumpEnable = true;
            }
        }
        _animator.SetBool("Ground", _isGrounded);

        // Set the vertical animation
        _animator.SetFloat("vSpeed", _rigidbody.velocity.y);
    }


    public void Move(float move, bool jump, bool attack)
    {
        //only control the player if grounded or airControl is turned on
        if (_isGrounded || _airControl)
        {
            // Reduce the speed if crouching by the crouchSpeed multiplier
           // move = (crouch ? move * m_CrouchSpeed : move);

            // The Speed animator parameter is set to the absolute value of the horizontal input.
            _animator.SetFloat("Speed", Mathf.Abs(move));

            // Move the character
            _rigidbody.velocity = new Vector2(move * _maxSpeed, _rigidbody.velocity.y);

            // If the input is moving the player right and the player is facing left...
            // Or if the input is moving the player left and the player is facing right...
            if ((move > 0 && !_isFacingRight) || (move < 0 && _isFacingRight))
            {
                Flip();
            }
        }
        // If the player should jump...
        if (_isGrounded && jump && _animator.GetBool("Ground"))
        {
            // Add a vertical force to the player.
            _isGrounded = false;
            _animator.SetBool("Ground", false);
            _rigidbody.AddForce(new Vector2(0f, _jumpForce));
            _audioSource.clip = _jumpClip;
            _audioSource.Play();
        }
        else if (!_isGrounded && jump && _hasDoubleJump && _doubleJumpEnable)
        {
            _doubleJumpEnable = false;
            _rigidbody.AddForce(new Vector2(0f, _doubleJumpForce));
            _audioSource.clip = _doubleJumpClip;
            _audioSource.Play();
        }

        _animator.SetBool("Attacking", (attack && !_animator.GetBool("Attacking")));
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        _isFacingRight = !_isFacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public bool isFacingRight()
    {
        return _isFacingRight;
    }
}
