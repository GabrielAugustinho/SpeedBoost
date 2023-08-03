using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if(period <= Mathf.Epsilon) { return; } // Melhor do que colocar == 0 para valores float

        float cycles = Time.time / period;  // Continua crescendo com o tempo

        const float tau = Mathf.PI * 2; // Valor constante de Tau é quase 6.283...
        float rawSinWave = Mathf.Sin(cycles * tau); // Percorre de -1 ate 1

        movementFactor = (rawSinWave + 1f) / 2; // Recallcula para ir de 0 ate 1 deixando cleaner

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
