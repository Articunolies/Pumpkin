using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float pumpkinOffset = 2f;
    [SerializeField] private float interactDistance = 1.5f;
    [SerializeField] private LayerMask layerToCheck;
    [SerializeField] private bool hasPumpkin = false;
    [SerializeField] private float throwSpeed = 10f;
    [SerializeField] private float throwOffset = 1.25f;
    [SerializeField] private float rayCastConeSize = 10f;
    private GameObject grabbedPumpkin;
    RaycastHit2D rayCheck;
    RaycastHit2D rayCheckLeft;
    RaycastHit2D rayCheckRight;
    Vector2 movement;
    Vector2 lastMoveDir;
    
    Vector3 offsetPos;
    PlayerSounds playerSounds;

    void Start() {
        playerSounds = GetComponent<PlayerSounds>();
    }

    private void HandleInteract(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(movement != Vector2.zero){
            // Save last moving direction
            lastMoveDir = movement;
        }
        lastMoveDir = lastMoveDir.normalized;
        Vector2 leftDir = Quaternion.Euler(0, 0, rayCastConeSize) * lastMoveDir;
        Vector2 rightDir = Quaternion.Euler(0, 0, -rayCastConeSize) * lastMoveDir;
        rayCheckLeft = Physics2D.Raycast(transform.position, leftDir, interactDistance, layerToCheck);
        rayCheckRight = Physics2D.Raycast(transform.position, rightDir, interactDistance, layerToCheck);
        rayCheck = Physics2D.Raycast(transform.position, lastMoveDir, interactDistance, layerToCheck);
        
        Debug.DrawRay(transform.position, leftDir*interactDistance, Color.white);
        Debug.DrawRay(transform.position, rightDir*interactDistance, Color.white);
        Debug.DrawRay(transform.position, lastMoveDir*interactDistance, Color.white);

        if(Input.GetKeyDown(KeyCode.E)){
             if (hasPumpkin){
                ThrowPumpkin();
            } else if(rayCheck.collider != null || rayCheckLeft.collider != null || rayCheckRight.collider != null) {
                if (rayCheck.collider != null){
                    grabbedPumpkin = rayCheck.collider.gameObject;
                } else if (rayCheckLeft.collider != null) {
                    grabbedPumpkin = rayCheckLeft.collider.gameObject;
                } else if (rayCheckRight.collider != null) {
                    grabbedPumpkin = rayCheckRight.collider.gameObject;
                }
                if(!hasPumpkin){
                    // Physics update when grabbed
                    grabbedPumpkin.GetComponent<Rigidbody2D>().isKinematic = true;
                    grabbedPumpkin.GetComponent<Rigidbody2D>().freezeRotation = true;
                    grabbedPumpkin.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    grabbedPumpkin.GetComponent<PolygonCollider2D>().enabled = false;

                    // Set onto player

                    //grabbedPumpkin.transform.SetParent(transform, true);
                    //grabbedPumpkin.transform.localPosition = new Vector3(0,5,0);

                    //offset by player size
                    
                    hasPumpkin = true;
                    playerSounds.Reaction();
                }
                else {
                    Debug.DrawRay(transform.position, lastMoveDir*interactDistance, Color.white);
                }
            }
        } 
        if(Input.GetKeyDown(KeyCode.J)){
            if (hasPumpkin){
                ThrowPumpkin();
            } 
        }
        if (grabbedPumpkin != null){
            grabbedPumpkin.transform.position = new Vector3(transform.position.x, transform.position.y + pumpkinOffset, 0);
        }
    }
    private void ThrowPumpkin(){
        if(grabbedPumpkin != null){
            playerSounds.Reaction();
            // Physics update when dropped/thrown
            grabbedPumpkin.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbedPumpkin.GetComponent<Rigidbody2D>().freezeRotation = false;
            grabbedPumpkin.GetComponent<PolygonCollider2D>().enabled = true;
            // Removing parenting
            grabbedPumpkin.transform.SetParent(null);
            // Set up throwing position
            offsetPos = (Vector2)transform.position + lastMoveDir.normalized * throwOffset;
            grabbedPumpkin.transform.position = offsetPos;
            // Apply force to pumpkin
            grabbedPumpkin.GetComponent<Rigidbody2D>().velocity = lastMoveDir.normalized * throwSpeed;
            // Dereference pumpkin
            grabbedPumpkin = null;
            hasPumpkin = false;
        }
    } 
    public bool GetHasPumpkin(){
        return hasPumpkin;
    }
    public void SetHasPumpkin(bool state){
        hasPumpkin = state;
    }
    public GameObject GetPumpkin(){
        return grabbedPumpkin;
    }
    void Update()
    {
        HandleInteract();
    }
}
