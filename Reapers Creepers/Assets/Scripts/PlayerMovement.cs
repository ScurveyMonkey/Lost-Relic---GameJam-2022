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

    public AudioClip playerJump;
    public AudioClip playerDeath;
    public AudioClip playerWalk;
    public AudioClip playerWin;


    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator _anim;
    private AudioSource playerSource;
    public GameManager gameManager;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        playerSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_dead == false && _soulCaptured == false)
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
        if (collision.gameObject.CompareTag("Soul") && !_dead)
        {
            _soulCaptured = true;
            _isGrounded = false;
            playerSource.PlayOneShot(playerWin);
            Destroy(collision.gameObject);
        }

        //traps
        if (collision.gameObject.CompareTag("Spikes") && !_dead)
        {
            _dead = true;
            playerSource.PlayOneShot(playerDeath);
        }
        if (collision.gameObject.CompareTag("Fire") && !_dead)
        {
            _dead = true;
            playerSource.PlayOneShot(playerDeath);
        }
        if (collision.gameObject.CompareTag("Sensor") && !_dead)
        {
            _dead = true;
            playerSource.PlayOneShot(playerDeath);
            Destroy(gameObject, 2f);
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
    }

    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            playerSource.PlayOneShot(playerJump);
            _isGrounded = false;
        }
    }

}
