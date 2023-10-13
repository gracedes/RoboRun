using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logicScriptScript : MonoBehaviour
{
    public GameObject goScreen;
    public GameObject score1;
    public GameObject score2;
    public GameObject blinkHUD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver()
    {
        goScreen.SetActive(true);

        score1.SetActive(false);
        score2.SetActive(false);
        blinkHUD.SetActive(false);
    }
}
