using UnityEngine;
using System.Collections.Generic;

public class AIController : MonoBehaviour
{
    private StateMachine stateMachine;
    public GameObject player;   // Assign this in the Inspector or dynamically
    public List<GameObject> pumpkins = new List<GameObject>();  // List to store all spawned pumpkins
    public GameObject enemy;    // Reference to the enemy
    private bool pumpkinsSet = false; // Flag to check if pumpkins have been set

    void Start()
    {
        // Initialize the state machine
        stateMachine = new StateMachine();
    }

    void Update()
    {
        // Check if the pumpkins have been set before initializing the patrol state
        if (pumpkinsSet && stateMachine.currentState == null)
        {
            // Set the initial state (PatrolState), passing the player and pumpkins
            PatrolState patrolState = new PatrolState(stateMachine, enemy, player, pumpkins);
            stateMachine.SetState(patrolState);

            Debug.Log("PatrolState initialized with pumpkins.");
        }

        stateMachine.Update();  // Make sure to update the state machine each frame
    }

    // Method to set all pumpkin targets
    public void SetPumpkinTargets(List<GameObject> newPumpkins)
    {
        pumpkins = newPumpkins;  // Store all the pumpkins
        pumpkinsSet = true;  // Set the flag to true once pumpkins are set
        Debug.Log("Pumpkin targets set for the AI. Total Pumpkins: " + pumpkins.Count);
    }
}
