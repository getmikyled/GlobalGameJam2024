using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D r;
    float hvalue;

    private void Awake()
    {
        r = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        hvalue = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        Move(hvalue);
    }

    void Move(float dir)
    {
        Vector2 targetVelocity = new Vector2(dir, r.velocity.y);
        r.velocity = targetVelocity;
    }
}
