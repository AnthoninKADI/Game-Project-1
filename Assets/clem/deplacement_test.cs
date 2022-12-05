using UnityEngine;

public class deplacement_test : MonoBehaviour
{
    public float speed = 5f;
    public float JumpForce = 2f;
    public Rigidbody2D rb;
    public Animator anim;
    public CapsuleCollider2D playerCollider;
    public bool isClimbing;
    public bool isGrounded;






    private void Start()
    {
        //Grab references for rigidBody and animator
        rb = GetComponent<Rigidbody2D>();

        //anim = GetComponent<Animator>();
    }


    private void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        var movement = horizontalInput;
        var movementy = verticalInput;

        if (!isClimbing)
        {
            //move right and left 

            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;

            // Jump
            if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }
        }
        else
        {
            //deplacement vertical
            transform.position += new Vector3(0, movementy, 0) * Time.deltaTime * speed;




        }

    }

}

