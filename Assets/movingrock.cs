using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingrock : MonoBehaviour
{
    Vector3 startingPoint;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;
    void Start()
    {
        startingPoint = transform.position; 
    }


    void Update()
    {   
        if (period <= Mathf.Epsilon)
            return;
        float cycles = Time.time / period;     //continually growing over time
        const float tau = Mathf.PI * 2;        
        float sinWave = Mathf.Sin(tau * cycles);     //fixed the value from -1 to 1

        movementFactor = (sinWave + 1f) / 2f;      //cleaner

        Vector3 offset = movementVector * sinWave;
        transform.position = startingPoint + offset;
    }
}
