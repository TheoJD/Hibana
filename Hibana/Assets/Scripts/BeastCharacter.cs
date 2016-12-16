using UnityEngine;
using System.Collections;

public class BeastCharacter : MonoBehaviour {

    [SerializeField]
    private float m_MaxSpeed = 2.0f;                    // The fastest the player can travel in the x axis.
    [SerializeField]
    private float _jumpForce = 400f;                  // Amount of force added when the player jumps.
    [SerializeField]
    private float _doubleJumpForce = 300f;            // Amount of force added when the player double jumps.
    [SerializeField]
    private bool _airControl = true;                 // Whether or not a player can steer while jumping;
    [SerializeField]
    private LayerMask _whatIsGround;                  // A mask determining what is ground to the character
    [SerializeField]
    private bool _hasDoubleJump = true;

    private Transform _groundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .08f; // Radius of the overlap circle to determine if grounded
    private bool _grounded;            // Whether or not the player is grounded.
    private bool _doubleJumpEnable;
    //private Transform m_CeilingCheck;   // A position marking where to check for ceilings
    const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
    private Animator _animator;            // Reference to the player's animator component.
    private Rigidbody2D _rigidbody;
    private bool _isFacingRight = true;  // For determining which way the player is currently facing.
    private BeastHealth _healthScript;

    private void Awake()
    {
        // Setting up references.
        _groundCheck = transform.Find("GroundCheck");
        //m_CeilingCheck = transform.Find("CeilingCheck");
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _healthScript = GetComponent<BeastHealth>();
        _doubleJumpEnable = true;
    }


    private void FixedUpdate()
    {
        _grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, k_GroundedRadius, _whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Ground")
            {
                _grounded = true;
                _doubleJumpEnable = true;
            }
        }
        _animator.SetBool("Ground", _grounded);

        // Set the vertical animation
        _animator.SetFloat("vSpeed", _rigidbody.velocity.y);
    }

    public void Move(float move, bool jump, bool attack)
    {
        //only control the player if grounded or airControl is turned on
        if (_grounded || _airControl)
        {
            // The Speed animator parameter is set to the absolute value of the horizontal input.
            _animator.SetFloat("Speed", Mathf.Abs(move));

            // Move the character
            _rigidbody.velocity = new Vector2(move * m_MaxSpeed, _rigidbody.velocity.y);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !_isFacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && _isFacingRight)
            {
                // ... flip the player.
                _healthScript.Flip();
                Flip();
            }
        }
        // If the player should jump...
        if (_grounded && jump && _animator.GetBool("Ground"))
        {
            // Add a vertical force to the player.
            _grounded = false;
            _animator.SetBool("Ground", false);
            _rigidbody.AddForce(new Vector2(0f, _jumpForce));
        }
        else if (!_grounded && jump && _hasDoubleJump && _doubleJumpEnable)
        {
            _rigidbody.AddForce(new Vector2(0f, _doubleJumpForce));
            _doubleJumpEnable = false;
        }

        // If the player should attack...
        if (attack && !_animator.GetBool("Attacking"))
        {
            _animator.SetBool("Attacking", true);
        }
        else
        {
            _animator.SetBool("Attacking", false);
        }
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
