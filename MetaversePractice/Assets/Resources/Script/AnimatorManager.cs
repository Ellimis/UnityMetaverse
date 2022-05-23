using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class AnimatorManager : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody2D;
    private Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (rigidBody2D.velocity.sqrMagnitude > 0.01) animator.SetBool("isWalk", true);
        else animator.SetBool("isWalk", false);

        if (rigidBody2D.velocity.x > 0) spriteRenderer.flipX = false;
        else spriteRenderer.flipX = true;
    }
}
