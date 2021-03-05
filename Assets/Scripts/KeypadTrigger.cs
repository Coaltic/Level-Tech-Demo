using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadTrigger : MonoBehaviour
{
    public GameObject canvas;
    public GameObject trigger;

    public AudioSource sound;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            sound.Play();
            trigger.SetActive(true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        canvas.SetActive(true);
    }

    public void OnTriggerExit(Collider other)
    {
        canvas.SetActive(false);
    }
}
