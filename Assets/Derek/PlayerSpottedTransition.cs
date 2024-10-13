using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerSpottedTransition : Transition
{
    private GameObject player;  // Reference to the player
    private GameObject owner;   // Reference to the enemy (goose)
    private VisionCone visionCone; // Reference to the vision cone component
    private List<GameObject> pumpkins;
    private StateMachine stateMachine;


    public PlayerSpottedTransition(StateMachine stateMachine, GameObject owner, GameObject player, List<GameObject> pumpkins) : base(owner)
    {
        this.owner = owner;
        this.player = player;
        this.pumpkins = pumpkins;
        this.visionCone = owner.GetComponent<VisionCone>(); // Get the vision cone component from the enemy
        this.stateMachine = stateMachine;
    }

    public override bool ShouldTransition()
    {
        // Check if the player is inside the vision cone and moving
        if (player != null && visionCone.IsTargetInVision(player))
        {
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            // Check if the player is moving
            if (playerMovement != null && playerMovement.ishiding != true)
            {
                Debug.Log("Player Spotted Transition.");

                return true; // Player is in the vision cone and moving, so transition to attack state
            }
        }

        return false; // No transition if player isn't in the cone or isn't moving
    }

    public override State GetNextState()
    {
        // Transition to the AttackState and pass both owner and player
        return new AttackState(stateMachine, owner, player, player, pumpkins);
    }
}
