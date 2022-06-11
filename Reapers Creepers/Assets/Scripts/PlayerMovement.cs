using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float _mSpeed = 5.0f;
    private float jumpForce = 5.5f;
    //private float _maxWeaponRange = 10.0f;
    [SerializeField] bool _isGrounded;
    public bool _facingRight;


    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 vertMovement;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jumping();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            Debug.Log("You're on the ground");
            // add animation for walking
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(""))
            _isGrounded = false;
        Debug.Log("Jumping");
    }

    public void Movement()
    {
        //Movement of player
        movement = new Vector2(Input.GetAxis("Horizontal"), 0);

        var xMovement = movement.x * _mSpeed * Time.deltaTime;

        this.transform.Translate(new Vector3(xMovement, 0), Space.World);

        //Flipping the player sprite left or right
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyDown(KeyCode.A))
        {
            _facingRight = false;
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyDown(KeyCode.D))
        {
            _facingRight = true;
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }
    }

    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _isGrounded = false;
        }
    }

}
