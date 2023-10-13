using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crackScript : MonoBehaviour
{
    public Rigidbody2D crackRigidbody;
    public SpriteRenderer crackSpriteRend;
    public float gameSpeed;
    public GameObject thisCrack;

    public Sprite crack1, crack2, crack3, crack4, crack5, crack6;

    // Start is called before the first frame update
    void Start()
    {
        crackRigidbody.velocity = Vector2.left * gameSpeed;
        flipCheck();
        spritePick();
    }

    // Update is called once per frame
    void Update()
    {
        despawnCheck();
    }

    public void flipCheck()
    {
        crackSpriteRend = GetComponent<SpriteRenderer>(); // Retrieves the sprite renderer component of the object in Unity

        int flip = Random.Range(0, 2);

        if (flip == 0) // 50/50 chance
        {
            crackSpriteRend.flipX = true; // Object's sprite is flipped
        }
    }

    public void spritePick()
    {
        int spriteNum = Random.Range(0, 6);

        if(spriteNum == 0)
        {
            crackSpriteRend.sprite = crack1;
        }
        else if (spriteNum == 1)
        {
            crackSpriteRend.sprite = crack2;
        }
        else if (spriteNum == 2)
        {
            crackSpriteRend.sprite = crack3;
        }
        else if (spriteNum == 3)
        {
            crackSpriteRend.sprite = crack4;
        }
        else if (spriteNum == 4)
        {
            crackSpriteRend.sprite = crack5;
        }
        else if (spriteNum == 5)
        {
            crackSpriteRend.sprite = crack6;
        }
    }

    public void despawnCheck()
    {
        if (transform.position.x < -20)
        {
            Destroy(thisCrack);
        }
    }
}
