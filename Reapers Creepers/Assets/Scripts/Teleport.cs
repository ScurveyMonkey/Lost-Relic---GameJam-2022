using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    PlayerMovement playerController;
    [SerializeField] Barrel barrel;
    // Start is called before the first frame update
    void Start()
    {
        playerController = gameObject.GetComponent<PlayerMovement>();
        barrel = gameObject.GetComponent<Barrel>();
        
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
            Debug.Log("Teleport");
            yield return new WaitForSeconds(0.01f);
            gameObject.transform.position = new Vector2(3,3);
        }

        
    }
}
