using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{    
    //public GameObject respawnLocation;
    //Vector3 winner = new Vector3(-1.8f, 7.0f, -75.0f);
    //public GameObject canvas;
    Vector3 originalPosition;
    Quaternion forward;

    public float timer = 3.0f;

    void Start()
    {
        forward.Set(0, 180, 0, 1);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Vector3 respawnLocation =  originalPosition - gameObject.transform.position;
        Debug.Log("TRIGGERED: " + other.tag);

        if (other.tag == "Killbox")
        {
            Debug.Log("About to reset player");
            //gameObject.GetComponent<CharacterController>().Move(respawnLocation);
            //gameObject.transform.position = new Vector3(0, 1, 0);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.transform.position = originalPosition;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            //gameObject.transform.rotation = forward;


        }
        else if (other.tag == "Checkpoint")
        {
            originalPosition = gameObject.transform.position;

            //gameObject.transform.position = originalPosition;
        }
        else if (other.tag == "Teleporter")
        {
            Debug.Log("TRIGGERED: " + other.tag);
            //gameObject.GetComponent<CharacterController>().Move(winner);
        }
        
    }

    public void OnTriggerExit(Collider other)
    {
        //canvas.SetActive(false);
    }
}
