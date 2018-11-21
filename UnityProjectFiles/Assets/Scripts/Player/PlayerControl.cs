using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;				// Condition for whether the player should jump.
	public bool crouch = false;
	public bool skip = false;

	public float moveForce = 5f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	public float jumpForce = 1000f;			// Amount of force added when the player jumps.
	private float xSpeed = 0f;


	public Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	private Animator anim;					// Reference to the player's animator component.

	// Sounds
 public AudioClip jumpSound;
 private AudioSource soundSource;



	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("GroundCheck");
		anim = GetComponent<Animator>();
		soundSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("Ground", grounded);

		// If the jump button is pressed and the player is grounded then the player should jump.
		if(Input.GetButtonDown("Jump") && grounded) {
			soundSource.PlayOneShot(jumpSound);
			jump = true;
		}
		if (Input.GetKey(KeyCode.LeftControl) && !jump) {
			crouch = true;
		}
		if (jump && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Q)))
			skip = true;
	}


	void FixedUpdate ()
	{

		if(Input.GetKey(KeyCode.D) == false & jump == false){
			GetComponent<Rigidbody2D>().velocity = new Vector3(0, GetComponent<Rigidbody2D>().velocity.y, 0);
		}
		if(Input.GetKey(KeyCode.Q) == false & jump == false){
			GetComponent<Rigidbody2D>().velocity = new Vector3(0, GetComponent<Rigidbody2D>().velocity.y, 0);
		}
		if(Input.GetKey(KeyCode.D) == true){
			GetComponent<Rigidbody2D>().velocity = new Vector3(moveForce, GetComponent<Rigidbody2D>().velocity.y, 0);
			if (!facingRight)
				Flip();
		}
		if(Input.GetKey(KeyCode.Q) == true){
			GetComponent<Rigidbody2D>().velocity = new Vector3(-moveForce, GetComponent<Rigidbody2D>().velocity.y, 0);
			if (facingRight)
				Flip();
		}
		xSpeed = GetComponent<Rigidbody2D>().velocity.x;
		if (xSpeed < 0)
			xSpeed = -xSpeed;

		anim.SetFloat("Speed", xSpeed);
		// If the player should jump...
		if(jump && !skip)
		{
			Jump();
		} else if (jump && skip) {
			Skip();
		}

		if (crouch) {
			Crouch();
		} else {
			anim.SetBool("Crouch", false);
		}

	}

	void Jump() {
		// Set the Jump animator trigger parameter.
		anim.SetTrigger("Jump");

		// Add a vertical force to the player.
		GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));

		// Make sure the player can't jump again until the jump conditions from Update are satisfied.
		jump = false;

	}

	void Crouch() {
		anim.SetBool("Crouch", true);
		crouch = false;
	}

	void Skip() {
		anim.SetTrigger("Skip");
		GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
		skip = false;
		jump = false;
	}

	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
