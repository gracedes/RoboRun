using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundSpawnScript : MonoBehaviour
{
    public GameObject floorTile;
    public GameObject crackTile;
    public GameObject spikeTile;
    public GameObject bullet;
    public float crackTimer = 0;
    public float spikeTimer = 0;
    public float bulletTimer = 0;
    public float bulletDensity = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnCracks();
        spawnBullets();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Instantiate(floorTile, transform.position, transform.rotation);
        spikeTimer++;
        spawnSpikes();
    }

    public void spawnCracks()
    {
        crackTimer += Time.deltaTime;

        if (crackTimer >= 0.5)
        {
            if (Random.Range(0, 2) == 0)
            {
                Instantiate(crackTile, transform.position + Vector3.back, transform.rotation);
            }

            crackTimer = 0;
        }
    }

    public void spawnBullets()
    {
        if (bulletTimer >= bulletDensity)
        {
            if (Random.Range(0, 3) == 0)
            {
                Instantiate(bullet, transform.position + (Vector3.up * Random.Range(3, 8)), transform.rotation);
            }

            bulletTimer = 0;
        }

        bulletTimer += Time.deltaTime;
    }

    public void spawnSpikes()
    {
        if (spikeTimer > 3)
        {
            if (Random.Range(0,2) == 0)
            {
                Instantiate(spikeTile, transform.position + (Vector3.up * 1.92f), transform.rotation);
            }

            if (spikeTimer >=6)
            {
                spikeTimer = 0;
            }
        }
    }
}
