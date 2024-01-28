using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam2024
{
    public class PlayerCharacterController: MonoBehaviour
    {
        [SerializeField] float speed = 250;
        [SerializeField] float jPower = 200;

        [SerializeField] Transform groundCheckCollider;
        [SerializeField] LayerMask groundLayer;
        [SerializeField] bool isGrounded = false;
        [SerializeField] bool isKnockbacked = false;
        Rigidbody2D rb;
        float hvalue;
        bool jump = false;
        bool facingRight = true;
        const float gCheckRadius = 0.01f;
        Animator animator;

        public int points = 50;


        [SerializeField] Transform brokenGlassCheckCollider;
        [SerializeField] Transform brokenGlass2CheckCollider;
        [SerializeField] LayerMask glassLayer;

        private SpriteRenderer playerRend;

        bool invinicble = false;


        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            playerRend = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            hvalue = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
            else if (Input.GetButtonUp("Jump"))
            {
                jump = false;
            }
        }

        private void FixedUpdate()
        {
            BrokenGlassRightCheck();
            BrokenGlassLeftCheck();
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

        void BrokenGlassRightCheck()
        {

            Collider2D[] colliders = Physics2D.OverlapCircleAll(brokenGlassCheckCollider.position, gCheckRadius, glassLayer);

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

            Collider2D[] colliders = Physics2D.OverlapCircleAll(brokenGlass2CheckCollider.position, gCheckRadius, glassLayer);

            if (colliders.Length > 0 )
            {
                if (colliders[0].CompareTag("BrokenGlass") && !invinicble)
                {
                    points -= 10;
                    StartCoroutine(sinvincible());
                }
            }
        }

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

            if (isKnockbacked == false)
            {
                float xvelocity = speed * dir * Time.fixedDeltaTime;
                Vector2 targetVelocity = new Vector2(xvelocity, rb.velocity.y);
                rb.velocity = targetVelocity;
            }

            if (facingRight && dir < 0)
            {
                transform.localScale = new Vector3(-0.75f, 0.75f, 0.75f);
                facingRight = false;
            }
            else if (!facingRight && dir > 0)
            {
                transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                facingRight = true;
            }

            GroundCheck();
            if (isGrounded && jFlag)
            {
                isGrounded = false;
                rb.AddForce(new Vector2(0f, jPower));
                Debug.Log("Jump");
            }
            animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        }

        public IEnumerator Knockback(Vector3 forceDirection, float punchStrength)
        {
            isKnockbacked = true;
            rb.AddForce(forceDirection * punchStrength, ForceMode2D.Impulse);
            yield return new WaitUntil(() => Mathf.Abs(rb.velocity.x) == 0);
            isKnockbacked = false;
            points += 10;
        }
    }
}