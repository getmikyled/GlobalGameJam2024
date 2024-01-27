using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam2024
{
    public class PunchingGloveTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            transform.parent.GetComponentInChildren<PunchingGloveController>().ActivatePunch();
        }
    }
}