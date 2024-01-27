using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GlobalGameJam2024;


public class PointCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dist;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int points = player.GetComponent<PlayerCharacterController>().points; // Assuming points is a public variable in the Movement script
        dist.text = points.ToString();
    }
}
