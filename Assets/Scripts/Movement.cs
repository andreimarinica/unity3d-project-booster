using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThurst();
        ProcessRotation();
    }

    void ProcessThurst()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("Pressed SPACE - THURSTING");
            //rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
            rb.AddRelativeForce(Vector3.forward * Time.deltaTime * mainThrust);
        }
        else if(Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddRelativeForce(-Vector3.forward * Time.deltaTime * mainThrust);
        }
        
    }
    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Pressed A - ROTATING LEFT");
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            //Debug.Log("Pressed D - ROTATING RIGHT");
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        //transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        transform.Rotate(Vector3.down * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false;
    }
}
// git hub test
// test 2