using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{
    // PARAMETERS
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem secondaryBooster;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem rightBooster;
    // CHACHING
    Rigidbody rb;
    AudioSource audioSource;
    // STATES
    // bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
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
            if(!audioSource.isPlaying) {
                audioSource.PlayOneShot(mainEngine);
            }
            if(!mainBooster.isPlaying)
            {
                mainBooster.Play();
            }
            
            
        }
        else if(Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddRelativeForce(-Vector3.forward * Time.deltaTime * mainThrust);
            if(!audioSource.isPlaying) {
                audioSource.PlayOneShot(mainEngine);
            }
            if(!secondaryBooster.isPlaying)
            {
                secondaryBooster.Play();
            }
        } 
        else 
        {
                audioSource.Stop();
                mainBooster.Stop();
                secondaryBooster.Stop();
        }
        
    }
    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Pressed A - ROTATING LEFT");
            ApplyRotation(rotationThrust);
            if(!rightBooster.isPlaying)
            {
                rightBooster.Play();
            }
        }
        else if(Input.GetKey(KeyCode.D))
        {
            //Debug.Log("Pressed D - ROTATING RIGHT");
            ApplyRotation(-rotationThrust);
            if(!leftBooster.isPlaying)
            {
                leftBooster.Play();
            }
        }
        else 
        {
            rightBooster.Stop();
            leftBooster.Stop();
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