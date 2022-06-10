using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject reticle;
    public Camera cam;
    public float laserLength = 50.0f;

    private float _mSpeed = 5.0f;
    private float jumpForce = 5.5f;
    [SerializeField] bool _isGrounded;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 vertMovement;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        Jumping();

        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * laserLength, Color.red);

        if (Physics.Raycast(ray, out hit, laserLength))
        {

        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.LookRotation(ray.direction));
            if (hit.collider != null)
            {
                hit.rigidbody.AddForceAtPosition(ray.direction * _mSpeed, hit.point);
                Debug.Log("Hitting: " + hit.collider.name);
            }

        }

       /* Movement();
        Jumping();

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            shootBullet();
        }
        Vector3 reticlePosition = reticle.transform.position;

        RaycastHit2D hit = Physics2D.Raycast(reticlePosition, Vector2.right, laserLength);

        if (hit.collider != null)
        {
            Debug.Log("Hitting: " + hit.collider.name);
        }
       Debug.DrawRay(new Vector3(transform.position.x, transform.position.y), new Vector3(Input.mousePosition.x, Input.mousePosition.y), Color.red);
       */

    }
    /*private void FixedUpdate()
    {
        Vector3 reticlePosition = reticle.transform.position;

        RaycastHit2D hit = Physics2D.Raycast(reticlePosition, Vector2.right, laserLength);

        if (hit.collider != null)
        {
            Debug.Log("Hitting: " + hit.collider.name);
        }
        Debug.DrawRay(new Vector3(transform.position.x,transform.position.y), new Vector3(Input.mousePosition.x, Input.mousePosition.y), Color.red);
    }
    */
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

    /*public void shootBullet()
    {

        GameObject b = Instantiate(projectilePrefab) as GameObject;
        b.transform.position = new Vector2(transform.position.x, Quaternion.LookRotation();
    }
    */
}
