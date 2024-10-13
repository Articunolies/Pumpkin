using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFlip : MonoBehaviour
{
    SpriteRenderer basesprite;
    SpriteRenderer hidesprite;
    // Start is called before the first frame update
    void Start()
    {
        basesprite = transform.Find("basesprite").GetComponent<SpriteRenderer>();
        hidesprite = transform.Find("hidesprite").GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        var axis = Input.GetAxisRaw("Horizontal");
        if (axis == -1){
            basesprite.flipX = true;
            hidesprite.flipX = true;
        }
        else
        {
            basesprite.flipX = false;
            hidesprite.flipX = false;
        }
        
    }
}
