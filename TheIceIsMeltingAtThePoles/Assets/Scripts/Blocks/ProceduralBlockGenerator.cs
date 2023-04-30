using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralBlockGenerator : MonoBehaviour
{
    public GameObject MainCharacter;
    public GameObject blockPrefab;
    public int numBlocks;
    public float startDistance = 5f;
    public float minDistance = 10f;
    public float distanceDecay = 0.01f;
    public Vector3 pos;
    public float MinimumDistanceX, MinimumDistanceY, MaximumDistanceX, MaximumDistanceY, OffSetY;

    private void Start()
    {
        MainCharacter = GameObject.FindGameObjectWithTag("MainCharacter");
        GenerateBlocks();
        pos = new Vector3(MainCharacter.transform.position.x, MainCharacter.transform.position.y, MainCharacter.transform.position.z);
    }

    private void GenerateBlocks()
    {
        pos = new Vector3(MainCharacter.transform.position.x , MainCharacter.transform.position.y + OffSetY, MainCharacter.transform.position.z);
        float dist = startDistance;

        for (int i = 0; i < numBlocks; i++)
        {
            Instantiate(blockPrefab, pos, Quaternion.identity);
            // pos.y += Random.Range(MinimumDistanceY, MaximumDistanceY) ; // Add some randomness to the position
            pos.x = Random.Range(-MaximumDistanceX, MaximumDistanceX) * dist;
            pos.x = Mathf.Clamp(pos.x, -30, 30);
            pos.y += Mathf.Clamp(pos.y, Random.Range(MinimumDistanceY, MinimumDistanceY), Random.Range(MinimumDistanceY + dist, MaximumDistanceY - dist));
            dist -= distanceDecay; // Decrease the distance between blocks
            dist = Mathf.Max(dist, minDistance); // Clamp the distance to a minimum value
        }
    }
}