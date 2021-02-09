using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private GameObject player;
    private playerController playerController;

    public float timeRemaining = 90f;
    public Text timeRemainingText;
    public Text heartsText;
    public Text stageText;
    public Sprite subWeaponSprite;
    public Sprite shotSprite;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
