using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public Spawner spawner;
    public int index;

    void Get() {
        Portal.starSoFar += 1;
        spawner.ConsumeAt(index);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col) {
        Get();
    }
}
