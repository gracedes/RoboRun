using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public Rigidbody2D bulletRigidbody;
    public float bulletSpeed;
    public GameObject thisBullet;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = Random.Range(11, 17);

        bulletRigidbody.velocity = Vector2.left * bulletSpeed;
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
            Destroy(thisBullet);
        }
    }
}
