using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private float movement;
	[SerializeField] private float walkSpeed;
	[SerializeField] private float runSpeed;
	[SerializeField] private float speed;
	
	[SerializeField] bool faceRight = true;
	[Header("JUMP")]
	[Range(1,10)]
	[SerializeField] float jumpForce;
	[SerializeField] float fallMultiplier = 2.5f;
	[SerializeField] float lowJumpMultiplier = 2f;
	[SerializeField] LayerMask whatIsGround;
	[SerializeField] bool isGrounded = false;
	[SerializeField] Transform groundCheck;
	[SerializeField] float checkRadius;
	
	Rigidbody2D rb;
	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		speed = walkSpeed;
	}

	// Update is called once per frame
	void Update()
	{
		Movement();
		ProcessInput();
		GroundCheck();		
		
		if (faceRight == false && movement > 0)
		{
			Flip();
		}
		else if(faceRight == true && movement < 0)
		{
			Flip();
		}        
		
		if (rb.velocity.y < 0)
		{
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}
		else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
		{
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}
	}
	
	void Movement()
	{
		movement = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(movement * speed, rb.velocity.y);
		
		
	}
	
	void ProcessInput()
	{
		if(Input.GetKey(KeyCode.LeftShift))
		{
			speed = runSpeed;
		}
		else		
		{
			speed = walkSpeed;
		}
		
		if(isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}
	}
	
	void Flip()
	{
		faceRight = !faceRight;
		transform.Rotate(0, 180, 0);
	}
	
	void GroundCheck()
	{
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
	}
	
	void Jump()
	{				
		rb.velocity = Vector2.up * jumpForce;		
	}
	
	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
	}
}
