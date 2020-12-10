using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleChunkGen : MonoBehaviour
{

    public GameObject Сhunk;
    public GameObject jungleСhunk;
    public GameObject distortedChunk;
    public int chunkWidth;
    public int jungleChunkWidth;
    public int distortedChunkWidth;
    public int numChunks;
    public int jungleNumChunks;
    public int distortedChunkNum;
    float seed;

    //start the generation function,create seed and get width of chunk

    void Start()
    {
        chunkWidth = Сhunk.GetComponent<CrimsonChunkGen>().width;
        jungleChunkWidth = jungleСhunk.GetComponent<JungleChunkGen>().width;
        distortedChunkWidth = distortedChunk.GetComponent<DistortedChunk>().width;
        seed = Random.Range(-10000f, 10000f);
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
        for (int i = 0; i < distortedChunkNum; i++)
        {
            GameObject newDistortedChunk = Instantiate(distortedChunk, new Vector3(lastX + distortedChunkWidth, 0f), Quaternion.identity) as GameObject;
            newDistortedChunk.GetComponent<DistortedChunk>().seed = seed; //import jungle chunk parametres from script
            lastX += distortedChunkWidth;
        }
    }
}