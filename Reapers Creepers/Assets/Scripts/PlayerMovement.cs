using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject reticle;
    public Camera cam;

    private float _mSpeed = 5.0f;
    private float jumpForce = 5.5f;
    private float _maxWeaponRange = 10.0f;
    [SerializeField] bool _isGrounded;
    [SerializeField] private Transform firePoint;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 vertMovement;
    private Vector2 lookDirection;
    float lookAngle;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Come back to this Need the weapon to follow the mouse.
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        lookDirection = new Vector2(lookDirection.x - transform.position.x, lookDirection.y - transform.position.y);
        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
 

        Movement();
        Jumping();

        if (Input.GetButtonDown("Fire1"))
        {
            shootBullet();
        }

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
        if(collision.gameObject.CompareTag(""))
        _isGrounded = false;
        Debug.Log("Jumping");
    }

    void Movement()
    {
        //Movement of player
        movement = new Vector2(Input.GetAxis("Horizontal"), 0);

        var xMovement = movement.x * _mSpeed * Time.deltaTime;

        this.transform.Translate(new Vector3(xMovement, 0), Space.World);

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

    public void shootBullet()
    {

        var projectileInstance = Instantiate(projectilePrefab);
        projectileInstance.transform.position = firePoint.position;
        projectileInstance.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

        projectileInstance.GetComponent<Rigidbody2D>().velocity = firePoint.right * _mSpeed;
    }
    
}
