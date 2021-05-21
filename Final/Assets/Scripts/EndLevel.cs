using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndLevel : MonoBehaviour
{
    public GameObject nextLevelStart;
    public GameObject gameCamera;
    public GameObject nextLevelCamera;
    public GameObject gameOver;

    void Start()
    {
        gameOver.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 9)
        {
            if(nextLevelStart == null)
            {
                gameOver.SetActive(true);
            }
            else
            {
                col.transform.position = nextLevelStart.transform.position;
                gameCamera.transform.position = nextLevelCamera.transform.position;
            }
        }
    }
}
