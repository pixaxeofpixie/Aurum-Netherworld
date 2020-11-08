using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleChunkGen : MonoBehaviour
{

    public GameObject Сhunk;
    int chunkWidth;
    public int numChunks;
    float seed;

    //start the generation function,create seed and get width of chunk

    void Start()
    {
        chunkWidth = Сhunk.GetComponent<ChunkGen>().width;
        seed = Random.Range(-100000f, 100000f);
        Generate();
    }

    //generate function

    public void Generate()
    {
        int lastX = -chunkWidth;
        for (int i = 0; i < numChunks; i++)
        {
            GameObject newChunk = Instantiate(Сhunk, new Vector3(lastX + chunkWidth, 0f), Quaternion.identity) as GameObject;
            newChunk.GetComponent<ChunkGen>().seed = seed; //import chunk parametres from script
            lastX += chunkWidth;
        }
    }
}