using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoringZone : MonoBehaviour
{
    private List<GameObject> scoredItems = new List<GameObject>();
    [SerializeField] private GameObject Player;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Pumpkin" && !scoredItems.Contains(other.gameObject))
        {
            if(Player.GetComponent<PlayerInteraction>().GetPumpkin()){
                GameObject playerPumpkin = Player.GetComponent<PlayerInteraction>().GetPumpkin();
                if(playerPumpkin == other.gameObject){
                    Player.GetComponent<PlayerInteraction>().SetHasPumpkin(false);
                }
            }
            scoredItems.Add(other.gameObject); 
            Destroy(other.gameObject);
            ScoreController.instance.AddScore(1);
            Debug.Log("Score = " + ScoreController.instance.GetScore());
        }
    }
}
