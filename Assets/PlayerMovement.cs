using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  
    [SerializeField] float thrust = 800f;
    [SerializeField] float rotation = 200f;
    [SerializeField] AudioClip boostingsound;
    [SerializeField] ParticleSystem boostingParticles;
    //[SerializeField] ParticleSystem leftengineParticles;
    //[SerializeField] ParticleSystem rightengineParticles;
    Rigidbody rocketbody;
    AudioSource rocksound;
    

    // Start is called before the first frame update
    void Start()
    {
       rocketbody = GetComponent<Rigidbody>();
       rocksound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Boosting();
        }
        else
        {
            StopBoosting();
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Rotateleft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }

    }

    private void Boosting()
    {
        rocketbody.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        if (!rocksound.isPlaying)
            rocksound.PlayOneShot(boostingsound);

        if (boostingParticles.isStopped)
            boostingParticles.Play();
    }

    private void StopBoosting()
    {
        rocksound.Stop();
        boostingParticles.Stop();
    }

    private void RotateRight()
    {
        Rotate(-rotation);
    }

    private void Rotateleft()
    {
        Rotate(rotation);

    }

    void Rotate(float dircetionrotation)
    {
        rocketbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * dircetionrotation * Time.deltaTime);
        rocketbody.freezeRotation = false;    //let the engine do phy
    }
}
