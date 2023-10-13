using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeScript : MonoBehaviour
{
    public Rigidbody2D spikeRigidbody;
    public float gameSpeed;
    public GameObject thisSpike;



    // Start is called before the first frame update
    void Start()
    {
        spikeRigidbody.velocity = Vector2.left * gameSpeed;


    }

    // Update is called once per frame
    void Update()
    {
        despawnCheck();
    }

    public void despawnCheck()
    {
        if (transform.position.x < -20)
        {
            Destroy(thisSpike);
        }
    }

}
