using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PumpkinSpottedTransition : Transition
{
    private List<GameObject> pumpkins;  // List of all pumpkins
    private GameObject owner;    // Reference to the enemy (goose)
    private VisionCone visionCone; // Reference to the vision cone component
    private GameObject player;
    private StateMachine stateMachine;

    public PumpkinSpottedTransition(StateMachine stateMachine, GameObject owner, List<GameObject> pumpkins, GameObject player) : base(owner)
    {
        this.owner = owner;
        this.pumpkins = pumpkins;
        this.visionCone = owner.GetComponent<VisionCone>(); // Get the vision cone component from the enemy
        this.player = player;
        this.stateMachine = stateMachine;
    }

    public override bool ShouldTransition()
    {
        // Check if any pumpkin is detected in the vision cone
        foreach (GameObject pumpkin in pumpkins)
        {
            if (pumpkin != null && visionCone.IsTargetInVision(pumpkin))
            {
                MovementDetector movementDetector = pumpkin.GetComponent<MovementDetector>();
                if (movementDetector != null && movementDetector.isMoving)
                {
                    Debug.Log("Player Spotted Transition.");

                    return true; // Player is in the vision cone and moving, so transition to attack state
                }
            }
        }

        return false; // No pumpkin detected, no transition
    }




    public override State GetNextState()
    {
        foreach (GameObject pumpkin in pumpkins)
        {
            Debug.Log($"{pumpkin.name}");
            if (pumpkin != null && visionCone.IsTargetInVision(pumpkin))
            {
                Debug.Log("Switching to AttackState targeting: " + pumpkin.name);
                return new AttackState(stateMachine, owner, pumpkin, player, pumpkins); // Attack the detected pumpkin
            }
        }

        return null; // This should never happen since we check in ShouldTransition()
    }

}
