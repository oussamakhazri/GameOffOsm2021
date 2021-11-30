using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight;
    public float airmvmt;

    private int extraJumps;
    public int extraJumpValue;

    private bool facingRight = true;
    private float moveInput;

   

    [SerializeField] private LayerMask platformLayerMask;

    [SerializeField] private BoxCollider2D boxCollider2d;
    private void Awake()
    {
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        
    }


    private void Start()
    {
        extraJumps = extraJumpValue;
    }
    // Update is called once per frame
    void Update()
    {
        Jump();
        moveInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }


        if (Input.GetKeyDown(KeyCode.R))
            {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }


    void Jump()
    {
        if (IsGrounded())
        {
            extraJumps = extraJumpValue;
            airmvmt = 0f;

        }
        
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0 )
        {

            jumpHeight = Random.Range(10f, 25f);
            airmvmt = Random.Range(-5f, 5f);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(airmvmt, jumpHeight), ForceMode2D.Impulse);
            FindObjectOfType<AudioManager>().Play("Jump");


            extraJumps--;
            
        }
        else if (IsGrounded() && Input.GetKeyDown(KeyCode.Space) && extraJumps == 0)
        {

            jumpHeight = Random.Range(10f, 25f);
            airmvmt = Random.Range(-5f, 5f);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(airmvmt, jumpHeight), ForceMode2D.Impulse);
            FindObjectOfType<AudioManager>().Play("Jump");

        }


    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 0.02f, platformLayerMask);
        return raycastHit2d.collider != null;


    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;


    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<AudioManager>().Play("Hit");
        }
    }



}
