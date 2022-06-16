using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _mSpeed = 5.0f;
    [SerializeField] private float jumpForce = 2.5f;
    [SerializeField] bool _isGrounded;
    public bool _facingRight;
    public bool _soulCaptured;
    public bool _dead;


    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator _anim;
    public GameManager gameManager;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_dead == false)
        {
            Movement();
            Jumping();
        }
        if (_dead == true)
        {
            _anim.SetBool("_Dead", true);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Soul"))
        {
            _soulCaptured = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Spikes"))
        {
            //_anim.SetBool("_Dead", true);
            _dead = true;
            Debug.Log("Dead" + _dead);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Ground" && _dead == false)
            _isGrounded = false;
    }

    public void Movement()
    {
        //Movement of player
        movement = new Vector2(Input.GetAxis("Horizontal"), 0);
        var xMovement = movement.x * _mSpeed * Time.deltaTime;
        this.transform.Translate(new Vector3(xMovement, 0), Space.World);


        //Flipping the player sprite left or right
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyDown(KeyCode.A) && _dead == false)
        {
            _facingRight = false;
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
            _anim.SetFloat("_mSpeed",1);
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyDown(KeyCode.D) && _dead == false)
        {
            _facingRight = true;
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            _anim.SetFloat("_mSpeed", 1);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) && _dead == false)
        {
            _anim.SetFloat("_mSpeed", 0);
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
