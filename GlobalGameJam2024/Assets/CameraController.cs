using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Camera Boundaries
    [SerializeField] private float bottomBoundary = 0f;
    [SerializeField] private float topBoundary = 20f;
    [SerializeField] private float leftBoundary = -10f;
    [SerializeField] private float rightBoundary = 10f;

    public GameObject player;  // pull the player game object from the game 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, leftBoundary, rightBoundary), Mathf.Clamp(player.transform.position.y, bottomBoundary, topBoundary), transform.position.z); //set the position of the camera to where the player moves
    }
}
