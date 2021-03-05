using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject locationObject1;
    public GameObject locationObject2;

    public AudioSource teleportSound;

    Vector3 locateTo1;
    Vector3 locateTo2;


    void Start()
    {
        locateTo1.x = locationObject1.transform.position.x;
        locateTo1.y = locationObject1.transform.position.y;
        locateTo1.z = locationObject1.transform.position.z - 2;

        locateTo2.x = locationObject2.transform.position.x;
        locateTo2.y = locationObject2.transform.position.y;
        locateTo2.z = locationObject2.transform.position.z + 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Teleporter1")
        {
            this.gameObject.transform.position = locateTo2;
            teleportSound.Play();
        }
        else if (other.tag == "Teleporter2")
        {
            this.gameObject.transform.position = locateTo1;
            teleportSound.Play();
        }

    }
}
