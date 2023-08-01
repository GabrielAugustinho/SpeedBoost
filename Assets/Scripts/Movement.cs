using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{    
    [SerializeField] private float mainThrust = 1000f;
    [SerializeField] private float rotationThrust = 100f;

    [SerializeField] private AudioClip mainAudio;

    [SerializeField] private ParticleSystem boostParticles;
    [SerializeField] private ParticleSystem leftThrustParticles;
    [SerializeField] private ParticleSystem rightThrustParticles;

    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
       if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
       {            
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainAudio);
            }
            if(!boostParticles.isPlaying)
            {
                boostParticles.Play();
            }
            
       }
       else
       {
            audioSource.Stop();
            boostParticles.Stop();
       }
    }

    private void ProcessRotation()
    {
       if(Input.GetKey(KeyCode.A))
       {
            ApplyRotation(rotationThrust);
            if(!rightThrustParticles.isPlaying)
            {
                rightThrustParticles.Play();
            }  
       }
       else if(Input.GetKey(KeyCode.D))
       {
            ApplyRotation(-rotationThrust); 
            if(!leftThrustParticles.isPlaying)
            {
                leftThrustParticles.Play();
            }     
       }
       else
       {
            rightThrustParticles.Stop();
            leftThrustParticles.Stop(); 
       }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
