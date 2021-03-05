using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public GameObject platform;
    Vector3 platformMovement;

    void Start()
    {
        platformMovement = (gameObject.transform.position - platform.transform.position);


    }

    // Update is called once per frame
    void Update()
    {
        platformMovement = (platform.transform.position - gameObject.transform.position);

        gameObject.transform.position = platformMovement;
    }
}
