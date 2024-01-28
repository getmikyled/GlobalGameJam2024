using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GlobalGameJam2024;


public class PointCounter : MonoBehaviour
{
    [SerializeField] RectTransform pointMarker;
    PlayerCharacterController player;

    private const float markerStartPos = -145f;
    private const float markerEndPos = 25f;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacterController>(); // intialize basically
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePoints();
    }

    private void UpdatePoints()
    {
        int points = player.points; // Assuming points is a public variable in the Movement script
        
        pointMarker.anchoredPosition = new Vector3(markerStartPos + (((float)points/100.0f) * 170.0f), 190, pointMarker.position.z);
        Debug.Log(((float)points / 100.0f) * 170.0f);
        Debug.Log(((float)points / 100.0f));
    }
}
