using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _mSpeed = 5.0f;
    [SerializeField] float jumpForce;
    [SerializeField] bool _isGrounded;

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
        _isGrounded = true;
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            Debug.Log("You're on the ground");
            // add animation for walking
        }
        else if (collision.gameObject.CompareTag("BadStuff"))
        {
            Debug.Log("You're Dead...I think");
        }
    }

    void Movement()
    {
        //Movement of player
        movement = new Vector2(Input.GetAxis("Horizontal"), 0);
        vertMovement = new Vector2(0, Input.GetAxis("Vertical"));

        var xMovement = movement.x * _mSpeed * Time.deltaTime;
        var yMovement = vertMovement.y * _mSpeed * Time.deltaTime;

        this.transform.Translate(new Vector3(xMovement, 0), Space.World);
        this.transform.Translate(new Vector3(0, yMovement), Space.World);

        //Flipping the player sprite left or right
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyDown(KeyCode.A))
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyDown(KeyCode.D))
        {
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
