using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleChunkGen : MonoBehaviour
{

    public GameObject Сhunk;
    public GameObject jungleСhunk;
    int chunkWidth;
    int jungleChunkWidth;
    public int numChunks;
    public int jungleNumChunks;
    float seed;

    //start the generation function,create seed and get width of chunk

    void Start()
    {
        chunkWidth = Сhunk.GetComponent<CrimsonChunkGen>().width;
        jungleChunkWidth = jungleСhunk.GetComponent<JungleChunkGen>().width;
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
            newChunk.GetComponent<CrimsonChunkGen>().seed = seed; //import chunk parametres from script
            lastX += chunkWidth;
        }
        for (int i = 0; i < jungleNumChunks; i++)
        {
            GameObject newJungleChunk = Instantiate(jungleСhunk, new Vector3(lastX + jungleChunkWidth, 0f), Quaternion.identity) as GameObject;
            newJungleChunk.GetComponent<JungleChunkGen>().seed = seed; //import jungle chunk parametres from script
            lastX += jungleChunkWidth;
        }
    }
}