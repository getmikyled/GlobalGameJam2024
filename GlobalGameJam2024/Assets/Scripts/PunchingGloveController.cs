using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam2024
{
    public class PunchingGloveController : MonoBehaviour
    {
        [SerializeField] float _punchDistance = 2f;
        public float punchDistance => _punchDistance;
        [SerializeField] float _punchStrength = 2f;
        public float punchStrength => _punchStrength;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                Vector2 forceDirection = other.transform.position - transform.position;
                forceDirection.Normalize();

                StartCoroutine(other.transform.GetComponent<PlayerCharacterController>().Knockback(forceDirection, punchStrength));
            }
        }
    }

}