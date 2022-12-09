using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject star;
    public float interval;
    public int limit;

    private Portal portal;

    private List<Transform> targets = new List<Transform>();
    private List<int> filled = new List<int>();
    private int curr = 0;

    public void ConsumeAt(int idx) {
        filled[idx] -= 1;
        curr--;
        portal.UpdateLabel();
    }

    void SpawnStar() {
        if (curr >= limit) {
            return;
        }
        int idx = Random.Range(0, targets.Count - 1);
        while(filled[idx] > 0) {
            idx = Random.Range(0, targets.Count - 1);
        }
        GameObject starObj = GameObject.Instantiate(star, targets[idx].position, Quaternion.identity, transform);
        Star starComp = starObj.GetComponent<Star>();
        starComp.spawner = this;
        starComp.index = idx;
        filled[idx]++;
        curr++;
    }

    IEnumerator SpawnCheck() {
        while(GameManager.gameOn) {
            SpawnStar();
            yield return new WaitForSeconds(interval);
        }
    }

    void Awake() {
        portal = GameObject.Find("portal").GetComponent<Portal>();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform t in transform) {
            targets.Add(t);
        }
        for(int i = 0; i < targets.Count; i++) {
            filled.Add(0);
        }
        StartCoroutine(SpawnCheck());
    }
}
