using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam2024
{
    public class PunchingGloveManager : MonoBehaviour
    {
        [SerializeField] GameObject punchingGlovesContainer;
        DrawGloveGizmos[] punchingGloves;

        private void Start()
        {
            punchingGloves = punchingGlovesContainer.GetComponentsInChildren<DrawGloveGizmos>(true);

            Debug.Log(punchingGloves.Length);

            ActivateRandomPunchingGlove();
        }

        private void ActivateRandomPunchingGlove()
        {
            int index = Random.Range(0, punchingGloves.Length);

            DrawGloveGizmos punchingGlove = punchingGloves[index];
            punchingGlove.gameObject.SetActive(true);
            punchingGlove.transform.GetComponentInChildren<PunchingGloveController>().onPunch += ActivateRandomPunchingGlove;
        }
    }
}
