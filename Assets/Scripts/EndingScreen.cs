using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EndingScreen : MonoBehaviour
{
    public Image screen;
    public GameManager manager;

    public List<Typing> contents;

    IEnumerator Play() {
        Color original = screen.color;
        for(int i = 0; i < 5; i++) {
            yield return new WaitForSeconds(0.5f);
            original.a += 0.2f;
            screen.color = original;
        }
        foreach(Typing t in contents) {
            while(!t.Next()) {
                yield return new WaitForSeconds(0.15f);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        int exp = manager.GetExp();
        contents[1].SetArg($"{exp}%");
        contents[2].SetArg($"{Portal.starSoFar}");
        TimeSpan diff = manager.playTime;
        contents[3].SetArg($"{Convert.ToInt32(diff.TotalMinutes)} min {Convert.ToInt32(diff.TotalSeconds) % 60} sec");
        StartCoroutine(Play());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
