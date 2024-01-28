using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience : MonoBehaviour
{
    public static Audience instance;

    [SerializeField] private Animator animator;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    public void PlayAudienceAnimation()
    {
        animator.Play("Audience");
    }
}
