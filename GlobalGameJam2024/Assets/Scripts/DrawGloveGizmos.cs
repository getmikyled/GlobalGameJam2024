using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GlobalGameJam2024
{
    [ExecuteInEditMode]
    public class DrawGloveGizmos : MonoBehaviour
    {
        [SerializeField] private float gloveGizmoRadius = 0.5f;

        private void OnDrawGizmos()
        {
            PunchingGloveController gloveController = transform.GetComponentInChildren<PunchingGloveController>();

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + new Vector3(gloveController.punchDistance, 0), gloveGizmoRadius);
        }
    }

}