using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMaskLock : MonoBehaviour
{
    public GameObject background;
    public GameObject player;
    public float modBotY;

    Renderer bgRenderer;
    Bounds bgBounds;
    Vector3 bgMax;
    Vector3 bgMin;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        bgRenderer = background.GetComponent<Renderer>();
        bgBounds = bgRenderer.bounds;
        bgMax = bgBounds.max;
        bgMin = bgBounds.min;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < bgMin.y + modBotY) {
            transform.SetParent(null);
        } else {
            transform.SetParent(player.transform);
            transform.position = startPos;
        }
    }
}
