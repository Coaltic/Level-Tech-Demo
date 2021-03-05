using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RespawningCollectable : MonoBehaviour
{
    public AudioSource sound;

    public bool collected = false;
    public bool respawning = false;
    float floatSpeed = 0.2f;
    public Vector3 bounceUp;
    public Vector3 bounceDown;
    float timeStamp = 0.0f;  
    float respawnTime = 8.0f;
    
    void Start()
    {
        bounceDown = this.transform.position;
        bounceUp = new Vector3(0.0f, 1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.Translate(bounceUp * floatSpeed * Time.deltaTime);
        gameObject.transform.Rotate(0.0f, 0.3f, 0.0f);

        if (collected == true)
        {
            if (!respawning)
            {
                //gameObject.SetActive(false);
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<MeshCollider>().enabled = false;
                timeStamp = Time.time;
            }
            respawning = true;
        }

        if (respawning)
        {
            float respawnTimeElapsed = Time.time - timeStamp;
            if (respawnTime <= respawnTimeElapsed)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                gameObject.GetComponent<MeshCollider>().enabled = true;
                collected = false;
                respawning = false;
            }
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            collected = true;
            sound.Play();
        }



        
        

        
    }
}
