using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 5;
    bool canMove;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
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
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            Vector2 speedVector = (Vector2.up + Vector2.right).normalized;
            transform.Translate(speed * Time.deltaTime * speedVector);
            //Debug.Log((speed * speedVector).magnitude);
        }

        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            transform.Translate((Vector2.up + Vector2.left).normalized * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            transform.Translate((Vector2.down + Vector2.left).normalized * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.Translate((Vector2.down + Vector2.right).normalized * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            //Debug.Log((speed * Time.deltaTime * Vector2.down).magnitude);
        }
    }
}
