using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Animator animator;
    private PlayerInteraction playerInteraction; 
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        playerMovement = player.GetComponent<PlayerMovement>();
        playerInteraction = player.GetComponent<PlayerInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
            animator.SetBool("moveAnim", true);
        } else {
            animator.SetBool("moveAnim", false);
        }
        
        if (playerInteraction.GetPumpkin() == true) {
            animator.SetBool("pumpkinAnim", true);
        }
        if (playerInteraction.GetPumpkin() == false) {
            animator.SetBool("pumpkinAnim", false);
        }

        if (playerMovement.issprinting == true) {
            animator.speed = 2;
        }
        if (playerMovement.issprinting == false) {
            animator.speed = 1;
        }
    }
}
