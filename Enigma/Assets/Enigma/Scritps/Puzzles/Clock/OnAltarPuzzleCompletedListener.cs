using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAltarPuzzleCompletedListener : MonoBehaviour
{
    [SerializeField] GameEvent onAltarPuzzleCompleted;
    [SerializeField] BoxCollider2D stairsBoxCollider;
    [SerializeField] Transform target;
    GameObject wrongPlacedCandles;
    GameObject correctPlacedCandles;
    BoxCollider2D boxCollider;
    bool move;
    Vector3 direction;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        onAltarPuzzleCompleted.Event.AddListener(OnPuzzleComplete);
        wrongPlacedCandles = transform.GetChild(0).gameObject;
        correctPlacedCandles = transform.GetChild(1).gameObject;
        correctPlacedCandles.SetActive(false);
        wrongPlacedCandles.SetActive(true);
        direction = target.position - transform.position;
        stairsBoxCollider.enabled = false;
    }

    private void Update()
    {
        if (!move) return;

        transform.position += direction * Time.deltaTime;

        if(Vector3.Distance(transform.position, target.position) < 0.1)
        {
            transform.position = target.position;
            move = false;
            stairsBoxCollider.enabled = true;
        }
    }

    private void OnPuzzleComplete()
    {
        boxCollider.enabled = false;
        correctPlacedCandles.SetActive(true);
        wrongPlacedCandles.SetActive(false);
        move = true;
    }






}
