using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringZone : MonoBehaviour
{
    static int score = 0;
    private List<GameObject> scoredItems = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Pumpkin" && !scoredItems.Contains(other.gameObject))
        {
            scoredItems.Add(other.gameObject); 
            Destroy(other.gameObject);
            score += 1;
            Debug.Log("Score = " + score);
        }
    }
}
