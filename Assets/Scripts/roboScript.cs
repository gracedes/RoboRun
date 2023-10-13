using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class roboScript : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public float jumpCoefficient; // coefficient for jump height
    public float floatCoefficient;
    public float airTime = 0;
    public float spriteTimer;
    public bool blink = false;
    public bool blinkReady = true;
    public float blinkTimer = 0;
    public float blinkCooldown = 6;

    public Sprite roll1, roll2, jump, roll1B, roll2B, jumpB;
    public SpriteRenderer roboSpriteRend;

    public int score = 0;
    public float scoreTimer = 0;
    public Text scoreText;
    public Text blinkUI;

    public ParticleSystem particlesD, particlesB;

    public bool gOver = false;

    public GameObject goScreen, goPrompt;
    public GameObject score1;
    public GameObject score2;
    public GameObject blinkHUD, controls;


    // Start is called before the first frame update
    void Start()
    {
        gOver = false;

        goScreen.SetActive(false);
        goPrompt.SetActive(false);
        blinkHUD.SetActive(true);
        controls.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        jumpCheck();
        blinkCheck();

        drawParticles();

        if (playerRigidbody.IsTouching(GameObject.FindGameObjectWithTag("Floor Collision").GetComponent<BoxCollider2D>())) // checks to see if you're on the ground
        {
            spriteCycle();
            airTime = 0;
            spriteTimer += Time.deltaTime * 8;
        }
        else if (airTime < floatCoefficient)
        {
            if (blink == true)
            {
                roboSpriteRend.sprite = jumpB;
            }
            else
            {
                roboSpriteRend.sprite = jump;
            }
        }
        else
        {
            if (blink == true)
            {
                roboSpriteRend.sprite = roll1B;
            }
            else
            {
                roboSpriteRend.sprite = roll1;
            }
        }

        if (gOver == false)
        {
            if (blink == false)
            {
                scoreTimer += Time.deltaTime;

                if (scoreTimer >= 0.1)
                {
                    score++;
                    scoreTimer = 0;

                    scoreText.text = score.ToString();
                }
            }
        }

        if (blink == true)
        {
            blinkUI.color = new Color(1f, 1f, 0.5f, 1f);
        }
        else if (blinkReady == true)
        {
            blinkUI.color = new Color(0.5f, 0.75f, 0.5f, 1f);
        }
        else
        {
            blinkUI.color = new Color(1f, 0.5f, 0.5f, 1f);
        }

        airTime += Time.deltaTime;
    }

    public void jumpCheck()
    {
        if (Input.GetKey(KeyCode.Space) && airTime < floatCoefficient && gOver == false)
        {
            playerRigidbody.velocity += Vector2.up * jumpCoefficient * Time.deltaTime; // adds vertical velocity while maintaining horizontal velocity
        }
    }

    public void spriteCycle()
    {
        if (blink == false)
        {
            if (spriteTimer <= 1)
            {
                roboSpriteRend.sprite = roll1;
            }
            else if (spriteTimer <= 2)
            {
                roboSpriteRend.sprite = roll2;
            }
            else if (spriteTimer > 2)
            {
                spriteTimer = 0;
            }
        }
        else if (blink == true)
        {
            if (spriteTimer <= 1)
            {
                roboSpriteRend.sprite = roll1B;
            }
            else if (spriteTimer <= 2)
            {
                roboSpriteRend.sprite = roll2B;
            }
            else if (spriteTimer > 2)
            {
                spriteTimer = 0;
            }
        }
        
    }

    public void blinkCheck()
    {
        if (blinkCooldown >= 5)
        {
            blinkReady = true;
        }

        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && blinkReady == true && blinkTimer <= 1 && gOver == false)
        {
            blink = true;
            blinkTimer += Time.deltaTime;
            blinkCooldown = 0;
        }
        else if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && blinkTimer > 1)
        {
            blink = false;
            blinkReady = false;
            blinkCooldown += Time.deltaTime;
        }
        else
        {
            blinkCooldown += Time.deltaTime;
        }

        if ((Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)) && blinkCooldown > 5)
        {
            blinkReady = false;
            blink = false;
            blinkCooldown = 0;
            blinkTimer = 0;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            blinkReady = false;
            blink = false;
            blinkTimer = 0;
        }
    }

    public void drawParticles()
    {
        var emissionD = particlesD.emission;
        var emissionB = particlesB.emission;

        if (blink == true)
        {
            emissionD.enabled = false;
            particlesD.Clear();
            emissionB.enabled = true;
        }
        else if (playerRigidbody.IsTouching(GameObject.FindGameObjectWithTag("Floor Collision").GetComponent<BoxCollider2D>()))
        {
            emissionD.enabled = true;
        }
        else
        {
            emissionD.enabled = false;
            particlesD.Clear();
        }

        if (blink == false)
        {
            emissionB.enabled = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (blink ==false)
        {
            gOver = true;

            goScreen.SetActive(true);
            goPrompt.SetActive(true);
            blinkHUD.SetActive(false);
            controls.SetActive(false);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
