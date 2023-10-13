using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorMovement : MonoBehaviour
{
    public Rigidbody2D floorRigidbody;
    public SpriteRenderer floorSpriteRend;
    public float gameSpeed;
    public GameObject thisFloor;

    // Start is called before the first frame update
    void Start()
    {
        floorRigidbody.velocity = Vector2.left * gameSpeed;
        flipCheck();
    }

    // Update is called once per frame
    void Update()
    {
        despawnCheck();
    }

    public void flipCheck()
    {
        floorSpriteRend = GetComponent<SpriteRenderer>(); // Retrieves the sprite renderer component of the object in Unity

        int flip = Random.Range(0, 2);

        if (flip == 0) // 50/50 chance
        {
            floorSpriteRend.flipX = true; // Object's sprite is flipped
        }
    }

    public void despawnCheck()
    {
        if (transform.position.x < -20)
        {
            Destroy(thisFloor);
        }
    }
}
