using System.Collections.Generic;
using UnityEngine;

public class PumpkinSpawner : MonoBehaviour
{
    public int startCount = 20;
    public GameObject background;
    public GameObject pumpkin;
    public GameObject vine;
    public Sprite[] pumpkinSprites;
    public Sprite[] vineSprites; // 1a, 1b, 2a, 2b, 3a, 3b, 4a, 4b, 5a, 5b, 6a, 6b, 7a, 7b
    // A list to hold the spawned pumpkins
    public List<GameObject> spawnedPumpkins = new List<GameObject>();

    Renderer bgRenderer;
    Bounds bgBounds;
    Vector3 bgSize;

    void Start()
    {
        bgRenderer = background.GetComponent<Renderer>();
        bgBounds = bgRenderer.bounds;
        bgSize = bgBounds.extents;

        for (int i = 0; i < startCount; i++)
        {
            Vector3 position = new Vector3(Random.Range(-bgSize.x, bgSize.x), Random.Range(-bgSize.y, bgSize.y), 0);

            // Instantiate the pumpkin and add it to the list
            GameObject spawnedPumpkin = Instantiate(pumpkin, position, Quaternion.identity);
            spawnedPumpkin.GetComponent<SpriteRenderer>().sprite = pumpkinSprites[Random.Range(0, pumpkinSprites.Length)];
            spawnedPumpkins.Add(spawnedPumpkin); // Add to the list

            // Pick a random pair of vine sprites and instantiate them
            GameObject spawnedVine  = Instantiate(vine, position, Quaternion.identity);
            GameObject spawnedVine2 = Instantiate(vine, position, Quaternion.identity);

            // THE WORST CODE IVE EVER WRITTEN
            int vineIndex = Random.Range(0, 7);
            switch(vineIndex){
                case 0:
                    spawnedVine.GetComponent<SpriteRenderer>().sprite = vineSprites[0];
                    spawnedVine2.GetComponent<SpriteRenderer>().sprite = vineSprites[1];
                    break;
                case 1:
                    spawnedVine.GetComponent<SpriteRenderer>().sprite = vineSprites[2];
                    spawnedVine2.GetComponent<SpriteRenderer>().sprite = vineSprites[3];
                    break;
                case 2:
                    spawnedVine.GetComponent<SpriteRenderer>().sprite = vineSprites[4];
                    spawnedVine2.GetComponent<SpriteRenderer>().sprite = vineSprites[5];
                    break;
                case 3:
                    spawnedVine.GetComponent<SpriteRenderer>().sprite = vineSprites[6];
                    spawnedVine2.GetComponent<SpriteRenderer>().sprite = vineSprites[7];
                    break;
                case 4:
                    spawnedVine.GetComponent<SpriteRenderer>().sprite = vineSprites[8];
                    spawnedVine2.GetComponent<SpriteRenderer>().sprite = vineSprites[9];
                    break;
                case 5:
                    spawnedVine.GetComponent<SpriteRenderer>().sprite = vineSprites[10];
                    spawnedVine2.GetComponent<SpriteRenderer>().sprite = vineSprites[11];
                    break;
                case 6:
                    spawnedVine.GetComponent<SpriteRenderer>().sprite = vineSprites[12];
                    spawnedVine2.GetComponent<SpriteRenderer>().sprite = vineSprites[13];
                    break;
                case 7:
                    spawnedVine.GetComponent<SpriteRenderer>().sprite = vineSprites[14];
                    spawnedVine2.GetComponent<SpriteRenderer>().sprite = vineSprites[15];
                    break;
            }
        }

        // Find the AIController in the scene and pass the entire list of pumpkins
        AIController aiController = FindObjectOfType<AIController>();  // Find the AIController in the scene
        Debug.Log("Testing this bull");
        Debug.Log(aiController);
        if (aiController != null && spawnedPumpkins.Count > 0)
        {
            Debug.Log("Added Pumpkin");
            aiController.SetPumpkinTargets(spawnedPumpkins); // Pass the full list of pumpkins
        }

    }
}
