using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public bool platformForward = false;
    public bool platformBack = false;
    public bool onPlatform = false;

    public AudioSource sound;

    public GameObject player;
    public GameObject platform;
    public Vector3 platformEnd;
    public Vector3 platformBegin;
    public Vector3 platformMax;

    Vector3 platformMovement;

    void Start()
    {
        platformBegin = platform.transform.position;
        platformMax = new Vector3(0.0f, 0.0f, 12.0f);

        platformEnd = (platform.transform.position + platformMax);
    }

    // Update is called once per frame
    void Update()
    {
        {


            if (platformForward == true)
            {
                platform.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                player.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                sound.Play();

                if (platform.transform.position.z >= platformEnd.z)
                {
                    Debug.Log("triggered");
                    platformForward = false;
                    platformBack = true;
                    platform.transform.position = platformEnd;
                }


            }
            else if (platformBack == true)
            {
                sound.Play();
                platform.transform.Translate(Vector3.back * speed * Time.deltaTime);
                player.transform.Translate(Vector3.forward * speed * Time.deltaTime);

                if (platform.transform.position.z <= platformBegin.z)
                {
                    platformBack = false;
                    platformForward = true;
                    platform.transform.position = platformBegin;
                }
            }


        }
    }

    private void OnTriggerEnter(Collider other)
    {

        platformForward = true;

        


    }

    private void OnTriggerExit(Collider other)
    {

        platformForward = false;
        platformBack = false;
        sound.Stop();



    }
}
