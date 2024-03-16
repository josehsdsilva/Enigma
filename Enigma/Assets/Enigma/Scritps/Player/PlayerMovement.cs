using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    float speed = 5;
    bool canMove;
    SpriteRenderer spriteRenderer;

    bool moving;


    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState newState)
    {
        canMove = newState == GameState.Play;
    }

    void Update()
    {
        if (!canMove) return;

        Movement();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        animator.SetFloat("MoveX", horizontal);
        animator.SetFloat("MoveY", vertical);

        spriteRenderer.flipX = horizontal < 0;

        moving = vertical > 0.01f || vertical < -0.01f || horizontal > 0.01f || horizontal < -0.01f;
        animator.SetBool("moving", moving);

        Debug.Log(animator.GetFloat("MoveX"));
        Debug.Log(animator.GetFloat("MoveY"));

        Vector3 direction = new Vector3(horizontal, vertical, 0f).normalized;
        transform.Translate(speed * Time.deltaTime * direction);
    }
}
