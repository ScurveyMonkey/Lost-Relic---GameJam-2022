using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(TeleportPlayer());
    }

    IEnumerator TeleportPlayer()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            //Debug.Log("Teleport");
            yield return new WaitForSeconds(0.01f);
            gameObject.transform.position = new Vector2(1,1);
        }

        
    }
}
