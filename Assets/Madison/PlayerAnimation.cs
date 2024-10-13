using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] GameObject pumpkinPrefab;
    [SerializeField] GameObject playerPrefab;
    private Animator animator;
    private PlayerInteraction playerInteraction; 
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        playerInteraction = pumpkinPrefab.GetComponent<PlayerInteraction>();
        playerMovement = playerPrefab.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (playerInteraction.hasPumpkin == true) {
        //     animator.SetBool("pumpkinAnim", true);
        // }

        // if (playerMovement.issprinting == true) {
        //     animator.SetBool("sprintAnim", true);
        // }
        // if (playerMovement.issprinting == false) {
        //     animator.SetBool("sprintAnim", false);
        // }
    }
}
