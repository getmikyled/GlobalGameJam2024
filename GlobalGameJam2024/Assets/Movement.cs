using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1;

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
        float xvelocity = speed * dir * Time.deltaTime;
        Vector2 targetVelocity = new Vector2(xvelocity, r.velocity.y);
        r.velocity = targetVelocity;
    }
}
