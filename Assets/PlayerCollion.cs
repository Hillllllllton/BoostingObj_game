using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollion : MonoBehaviour
{
 [SerializeField] float delay = 1.5f;
    AudioSource audiosoure;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip finish;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem finishParticle;
    Rigidbody rb;

    bool soundtransitioning = false;
    bool collisonEnable = false;
    void Start() 
    {
        audiosoure = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

    }
   
    void Update()
    {
        Cheating();
    }

    void Cheating()
    {
        if(Input.GetKey(KeyCode.N))
            NextScene();
        if(Input.GetKey(KeyCode.C))
        {   
            if(collisonEnable)
                Debug.Log("collisonEnabled");
            else if(!collisonEnable) 
                Debug.Log("collsonDisaled");
            collisonEnable = !collisonEnable; //toggle  false > true > false > true
        }
               
    }



    private void OnCollisionEnter(Collision other)
    {  
        if(soundtransitioning || collisonEnable)
            return;

        switch (other.gameObject.tag) {

            case "Start":
                Debug.Log("In the start point");
                break;
            case "Finish":
                Debug.Log("you are finish");
                LandSeccess();
                break;
            case "Fuel":
                Debug.Log("HP+1");
                break;
            default:
                Crash();       
                break;        
        }
    }

    private void LandSeccess()
    {           
        rb.Sleep();
        finishParticle.Play();
        soundtransitioning = true;
        audiosoure.Stop();
        GetComponent<PlayerMovement>().enabled = false; 
        audiosoure.PlayOneShot(finish);
        Invoke("NextScene", delay);
    }

    void Crash()
    {
        crashParticle.Play();
        soundtransitioning = true;
        audiosoure.Stop();  
        GetComponent<PlayerMovement>().enabled = false;   
        audiosoure.PlayOneShot(crash);
        Invoke("GoScene", delay);
 
    }


    void NextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        Debug.Log("Present scene:" +currentScene);
        if(nextScene == SceneManager.sceneCountInBuildSettings)
            nextScene = 0;
        SceneManager.LoadScene(nextScene);
    }

    void GoScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Present scene:" +currentScene);
        SceneManager.LoadScene(currentScene);
    }
}
