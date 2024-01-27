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
        const float gCheckRadius = 0.05f;
        Animator animator;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
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
            GroundCheck();
            Move(hvalue, jump);
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
            if (isGrounded && jFlag)
            {
                isGrounded = false;
                rb.AddForce(new Vector2(0f, jPower));
            }
            animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        }

        public IEnumerator Knockback(Vector3 forceDirection, float punchStrength)
        {
            isKnockbacked = true;
            rb.AddForce(forceDirection * punchStrength, ForceMode2D.Impulse);
            yield return new WaitUntil(() => Mathf.Abs(rb.velocity.x) == 0);
            isKnockbacked = false;
        }
    }
}