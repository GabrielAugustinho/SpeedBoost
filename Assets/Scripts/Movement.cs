using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float mainThrust = 1000f;
    [SerializeField] private float rotationThrust = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
       if(Input.GetKey(KeyCode.Space))
       {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
       }
    }

    private void ProcessRotation()
    {
       if(Input.GetKey(KeyCode.A))
       {
            ApplyRotation(rotationThrust);
       }
       else if(Input.GetKey(KeyCode.D))
       {
            ApplyRotation(-rotationThrust);     
       }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    }
}
