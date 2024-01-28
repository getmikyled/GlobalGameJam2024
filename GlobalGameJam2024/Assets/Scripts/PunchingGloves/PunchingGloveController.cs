using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace GlobalGameJam2024
{
    public class PunchingGloveController : MonoBehaviour
    {
        // Punching Glove Properties
        [SerializeField] float deactivateWaitTime = 2f;

        [SerializeField] float _punchDistance = 2f;
        public float punchDistance => _punchDistance;
        [SerializeField] float _punchStrength = 2f;
        public float punchStrength => _punchStrength;

        [Space] // Punching Glove FX
        [SerializeField] GameObject AppearFX;
        [SerializeField] GameObject DisappearFX;
        [SerializeField] GameObject TextChangeFX;

        [Space]
        [SerializeField] string joke;
        [SerializeField] string punchLine;
        [SerializeField] TextMeshPro textMesh;


        [SerializeField] Animator animator;

        private bool hasPunched = false;
        private bool hitPlayer = false;

        public UnityAction onPunch;

        public void ActivatePunch()
        {
            hasPunched = true;
            animator.Play("GlovePunching");
        }

        private void Start()
        {
            textMesh.text = joke;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (hasPunched == true && hitPlayer == false && other.transform.CompareTag("Player"))
            {
                hitPlayer = true;
                Vector2 forceDirection = other.transform.position - transform.position;
                forceDirection.Normalize();

                DisplayPunchline();

                StartCoroutine(OnPunchCallBack());
                StartCoroutine(other.transform.GetComponent<PlayerCharacterController>().Knockback(forceDirection, punchStrength));
            }
        }

        private void DisplayPunchline()
        {
            TextChangeFX.SetActive(true);
            textMesh.text = punchLine;
        }

        private IEnumerator OnPunchCallBack()
        {
            yield return new WaitForSeconds(deactivateWaitTime);

            DisappearFX.SetActive(true);

            yield return new WaitForSeconds(0.2f);

            ResetObject();
            transform.parent.gameObject.SetActive(false);
            onPunch?.Invoke();
        }

        private void ResetObject()
        {
            DisappearFX?.SetActive(false);
            TextChangeFX?.SetActive(false);
            hasPunched = false;
            hitPlayer = false;
        }
    }

}