using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 10.0f;
    bool facingRight = true;

    bool grounded = false;
    public float jumpPower = 10.0f;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround0;
    public LayerMask whatIsGround1;
    public LayerMask whatIsGround2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        grounded = false;
        if (Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround0) || 
            Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround1) ||
            Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround2))
        {
            grounded = true;
        }

        float move = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Vertical");
        if (grounded && jump > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, jumpPower);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }
     
	}

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
    }
}
