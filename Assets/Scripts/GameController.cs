using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private GameObject player;
    private playerController playerController;

    public float timeRemaining = 90f;
    public bool gameActive;
    public Text timeRemainingText;
    public Text heartsText;
    public Text stageText;
    public Image subWeaponSprite;
    public Image shotSprite;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<playerController>();
        StartCoroutine(Timer());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }

    IEnumerator Timer()
    {
        while (timeRemaining >= 0)
        {
            //timeRemainingText.text = timeRemaining.ToString();
            yield return new WaitForSeconds(1f);
            timeRemaining--;
        }
        gameActive = false;
    }
}
