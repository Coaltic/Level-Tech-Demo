using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float speed;
    public bool elevatorUp = false;
    public bool elevatorDown = false;

    public GameObject lift;
    public Vector3 elevatorTop;
    public Vector3 elevatorBottom;
    public Vector3 elevatorMax;

    void Start()
    {
        elevatorBottom = lift.transform.position;
        elevatorMax = new Vector3(0.0f, 35.0f, 0.0f);

        elevatorTop = (lift.transform.position + elevatorMax);
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (elevatorUp == true)
            {
                lift.transform.Translate(Vector3.up * speed * Time.deltaTime);

                if (lift.transform.position.y > elevatorMax.y)
                {
                    Debug.Log("triggered");
                    elevatorUp = false;
                    lift.transform.position = elevatorTop;
                }


            }
            else if (elevatorDown == true)
            {
                lift.transform.Translate(Vector3.down * speed * Time.deltaTime);

                if (lift.transform.position.y < elevatorBottom.y)
                {
                    elevatorDown = false;
                    lift.transform.position = elevatorBottom;
                }
            }


        }
    }

    private void OnTriggerEnter(Collider other)
    {

        elevatorUp = true;

    }

    private void OnTriggerExit(Collider other)
    {


        elevatorDown = true;



    }
}
