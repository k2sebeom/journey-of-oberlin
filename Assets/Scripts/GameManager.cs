using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static bool gameOn = true;

    public EndingScreen screen;

    private DateTime startTime;
    private DateTime endTime;
    public TimeSpan playTime;

    public Transform startPivot;
    public Transform endPivot;

    public Transform player;

    private Vector2 range = new Vector2();

    private int[,] matrix = new int[10, 10];

    public void LogPosition(Vector3 pos) {
        Vector3 rel = pos - startPivot.position;
        Vector3 normalized = new Vector2(rel.x / range.x, rel.y / range.y);
        normalized *= 10;
        int i = Mathf.FloorToInt(normalized.x);
        int j = Mathf.FloorToInt(normalized.y);
        if (i < 10 && j < 10) {
            matrix[i, j] = 1;
        }
    }

    public int GetExp() {
        int perc = 0;
        for(int i = 0; i < 10; i++) {
            for(int j = 0; j < 10; j++) {
                perc += matrix[i, j];
            }
        }
        return perc;
    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = DateTime.Now;
        Vector2 diag = endPivot.position - startPivot.position;
        range.x = Mathf.Abs(diag.x);
        range.y = Mathf.Abs(diag.y);
    }

    public void EndGame() {
        gameOn = false;
        endTime = DateTime.Now;
        playTime = endTime - startTime;
        screen.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        LogPosition(player.position);
    }
}
