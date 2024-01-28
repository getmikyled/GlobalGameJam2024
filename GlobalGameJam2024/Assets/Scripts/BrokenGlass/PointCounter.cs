using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GlobalGameJam2024;


public class PointCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dist;
    PlayerCharacterController player;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerCharacterController>(); // intialize basically
    }

    // Update is called once per frame
    void Update()
    {
        int points = player.points; // Assuming points is a public variable in the Movement script
        dist.text = points.ToString();
    }
}
