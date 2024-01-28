using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 250;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;

    [SerializeField] Transform brokenGlassCheckCollider;
    [SerializeField] Transform brokenGlass2CheckCollider;
    [SerializeField] LayerMask glassLayer;
    [SerializeField] bool isGrounded = false;
    [SerializeField] float jPower = 200;

    public int points= 50;
    Rigidbody2D r;
    float hvalue;
    bool jump = false;
    bool facingRight = true;
    const float gCheckRadius = 0.1f;
    const float glassRadius = 0.01f;
    Animator animator;

    private SpriteRenderer playerRend;

    bool invinicble = false;
    private void Awake()
    {
        playerRend = GetComponent<SpriteRenderer>();
        r = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hvalue = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }else if (Input.GetButtonUp("Jump"))
        {
            jump = false;
        }
    }

    private void FixedUpdate()
    {
        GroundCheck();
      //  BrokenGlassRightCheck();
       // BrokenGlassLeftCheck();
        Move(hvalue,jump);
    }

    void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, gCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
    }

   /* void BrokenGlassRightCheck()
    {

       Collider2D[] colliders = Physics2D.OverlapCircleAll(brokenGlassCheckCollider.position, glassRadius, glassLayer);

        if (colliders.Length > 0)
        {
            if (colliders[0].CompareTag("BrokenGlass") && !invinicble)
            {

                points -= 10;
                StartCoroutine(sinvincible());
            }
        }
    }

    void BrokenGlassLeftCheck()
    {

       Collider2D[] colliders = Physics2D.OverlapCircleAll(brokenGlass2CheckCollider.position, glassRadius, glassLayer);

        if (colliders.Length > 0 )
        {
            if (colliders[0].CompareTag("BrokenGlass") && !invinicble)
            {
                points -= 10;
                StartCoroutine(sinvincible());
            }
        }
    }
*/
private IEnumerator sinvincible()
    {
        invinicble = true;
        for(int i = 0; i < 4; i++)
        {
            playerRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(0.25f);
            playerRend.color = Color.white;
            yield return new WaitForSeconds(0.25f);
        }
        invinicble = false;
    }



    void Move(float dir, bool jFlag)
    {
        
        float xvelocity = speed * dir * Time.fixedDeltaTime;
        Vector2 targetVelocity = new Vector2(xvelocity, r.velocity.y);
        r.velocity = targetVelocity;

        if (facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-0.75f, 0.75f, 0.75f);
            facingRight = false;
        }

        else if(!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            facingRight = true;
        }
        
        if (isGrounded && jFlag)
        {
            isGrounded = false;
            r.AddForce(new Vector2(0f, jPower));
        }
        animator.SetFloat("xVelocity", Mathf.Abs(r.velocity.x));
    }
}
