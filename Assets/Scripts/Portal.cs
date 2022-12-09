using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Portal : MonoBehaviour
{
    public static int starSoFar = 0;
    public TMP_Text label;
    public GameManager manager;

    public int required;

    public void UpdateLabel() {
        label.text = $"{starSoFar}";
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(starSoFar >= required) {
            manager.EndGame();
            col.GetComponent<PlayerMovement>().moveSpeed = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
