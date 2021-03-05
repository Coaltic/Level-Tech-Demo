using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public float speed = 3.0f;
    public bool doorOpening = false;
    public bool doorClosing = false;

    public AudioSource sound;

    public GameObject door;
    public Vector3 doorOpen;
    public Vector3 doorClose;
    //public Vector3 doorOpenPosition;
    public Vector3 doorOpeningPosition;
    public Vector3 openPosition;
    public Vector3 closedPosition;

    public AudioSource doorSound;



    void Start()
    {
        closedPosition = door.transform.position;
        doorOpeningPosition = new Vector3(0.0f, 4.0f, 0.0f);

        openPosition = (door.transform.position - doorOpeningPosition);


        //openPosition = new Vector3(1.0f, -2.0f, 1.0f);
        
        
    }

   
    void Update()
    {
        if (doorOpening == true)
        {
            door.transform.Translate(Vector3.down * speed * Time.deltaTime);

            if (door.transform.position.y < openPosition.y)
            {
                Debug.Log("triggered");
                doorOpening = false;
                door.transform.position = openPosition;
            }

            
        }
        else if (doorClosing == true)
        {
            door.transform.Translate(Vector3.up * speed * Time.deltaTime);

            if (door.transform.position.y > closedPosition.y)
            {
                doorClosing = false;
                door.transform.position = closedPosition;
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        
        doorOpening = true;
        sound.Play();

    }

    private void OnTriggerExit(Collider other)
    {
        

        doorClosing = true;
        sound.Play();



    }
}
