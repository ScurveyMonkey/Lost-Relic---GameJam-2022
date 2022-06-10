using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject projectilePrefab;
    private Vector2 lookDirection;
    float lookAngle;
    [SerializeField] private Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0f, 0f, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            shootBullet();
        }
    }
    public void shootBullet()
    {
        GameObject firedBullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = firePoint.right * 10f;
    }
}
