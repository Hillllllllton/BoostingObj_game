using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] float waitingtime = 3f;
    MeshRenderer renderer;
    Rigidbody rigidbody;
    void Start()
    {
       // renderer = GetComponent<MeshRenderer>();
       // renderer.enabled = false;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > waitingtime) {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
