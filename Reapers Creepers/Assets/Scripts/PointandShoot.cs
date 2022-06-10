using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointandShoot : MonoBehaviour
{
    private Vector3 target;
    public GameObject reticle;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        
        reticle.transform.position = new Vector2(target.x, target.y + 1.15f); 
    }

}