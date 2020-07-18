using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    Animator animator;
    PlayerMove playerMove;
    ForceFieldActivator activator;

    void Awake()
    {
        activator = GetComponent<ForceFieldActivator>();
        playerMove = GetComponent<PlayerMove>();
        animator = GetComponentInChildren<Animator>();

        playerMove.OnMove += () =>
        {
            animator.SetBool("running", true);
        };

        playerMove.OnStop += () =>
        {
            animator.SetBool("running", false);
        };
        activator.OnCast += () =>
        {
            animator.SetBool("casting", true);
        };
        activator.OnStopCast += () =>
        {
            animator.SetBool("casting", false);
        };
    }


}
