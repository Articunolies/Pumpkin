using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBounds : MonoBehaviour
{
    public GameObject background;
    public float modX;
    public float modY;

    Renderer bgRenderer;
    Bounds bgBounds;
    Vector3 bgMax;
    Vector3 bgMin;

    // Start is called before the first frame update
    void Start()
    {
        bgRenderer = background.GetComponent<Renderer>();
        bgBounds = bgRenderer.bounds;
        bgMax = bgBounds.max;
        bgMin = bgBounds.min;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > bgMax.x - modX) {
            transform.position = new Vector3(bgMax.x - modX, transform.position.y, transform.position.z);
        }
        if (transform.position.x < bgMin.x + modX) {
            transform.position = new Vector3(bgMin.x + modX, transform.position.y, transform.position.z);
        }
        if (transform.position.y > bgMax.y - modY) {
            transform.position = new Vector3(transform.position.x, bgMax.y - modY, transform.position.z);
        }
        if (transform.position.y < bgMin.y + modY) {
            transform.position = new Vector3(transform.position.x, bgMin.y + modY, transform.position.z);
        }
    }
}
