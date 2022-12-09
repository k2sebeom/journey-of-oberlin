using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Typing : MonoBehaviour
{
    private TMP_Text label;
    string content;

    int idx = 0;

    void Awake() {
        label = GetComponent<TMP_Text>();
        content = label.text;
        label.text = "";
    }

    public void SetArg(string arg) {
        content = String.Format(content, arg);
    }

    public bool Next() {
        idx++;
        label.text = content.Substring(0, idx);
        return idx == content.Length;
    }

}
