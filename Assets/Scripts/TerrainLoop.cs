using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainLoop : MonoBehaviour
{
    public GameObject firstTerrain;

    public float width;

    private float x1;
    private float x2;

    void Start()
    {
        width = firstTerrain.GetComponent<SpriteRenderer>().bounds.size.x;

        x1 = firstTerrain.transform.position.x;
        x2 = x1 + width;
    }

    void Update()
    {
        if (transform.position.x > (x2 - 11))
        {
            generateNext();
            x2 = x2 + width;
        }
    }

    void generateNext()
    {
        GameObject clone = Instantiate(firstTerrain) as GameObject;

        clone.transform.SetParent(firstTerrain.transform.transform.parent);
        clone.transform.position = new Vector3(
            x2, firstTerrain.transform.position.y, firstTerrain.transform.position.z);
        clone.name = firstTerrain.name + x2;
    }
}
