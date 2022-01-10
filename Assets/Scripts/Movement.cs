using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
            StartThrustingUp();

        }
        else if(Input.GetKey(KeyCode.LeftShift))
        {
            StartThrustingDown();
        }
        else
        {
            StopSFXVFX();
        }

    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            StartThrustingRight();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            StartThrustingLeft();
        }
        else 
        {
            rightBooster.Stop();
            leftBooster.Stop();
        }

    }

    void StopSFXVFX()
    {
        audioSource.Stop();
        mainBooster.Stop();
        secondaryBooster.Stop();
    }

    void StartThrustingDown()
    {
        rb.AddRelativeForce(-Vector3.forward * Time.deltaTime * mainThrust);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!secondaryBooster.isPlaying)
        {
            secondaryBooster.Play();
        }
    }

    void StartThrustingUp()
    {
        rb.AddRelativeForce(Vector3.forward * Time.deltaTime * mainThrust);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainBooster.isPlaying)
        {
            mainBooster.Play();
        }
    }


    private void StartThrustingLeft()
    {
        //Debug.Log("Pressed D - ROTATING RIGHT");
        ApplyRotation(-rotationThrust);
        if (!leftBooster.isPlaying)
        {
            leftBooster.Play();
        }
    }

    void StartThrustingRight()
    {
        //Debug.Log("Pressed A - ROTATING LEFT");
        ApplyRotation(rotationThrust);
        if (!rightBooster.isPlaying)
        {
            rightBooster.Play();
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.down * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false;
    }

}