using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using GlobalGameJam2024;

public class GameOverScreen : MonoBehaviour
{
    PlayerCharacterController player;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerCharacterController>(); // intialize basically
    }
    public void Setup()
    {
        
        gameObject.SetActive(true);
        Debug.Log("GameOver");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("MeghanaScene");
    }
    
}
