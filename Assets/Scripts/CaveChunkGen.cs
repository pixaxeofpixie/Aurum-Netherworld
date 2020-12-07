using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveChunkGen : MonoBehaviour
{
    public int width;
    public int height;
    public int smoothCycles;

    private int[,] cavePoints;

    [Range(0, 100)]
    public int randFillPercent;
    [Range(0, 8)]
    public int threshold;

    public GameObject BlackGranite;
    public GameObject Aurichalcum;
    public GameObject MythryliumGraniteOre;
    public GameObject CaveChunk;

    public float chanceAurichalcum;
    public float chanceMythrilium;

    private void Awake()
    {
        GenerateCave();
    }

    void Start()
    {
        PlaceGrid();
    }

    private void GenerateCave()
    {
        cavePoints = new int[width, height];

        int seed = Random.Range(0, 1000000);
        System.Random randChoice = new System.Random(seed.GetHashCode());

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                {
                    cavePoints[x, y] = 1;
                }else if (randChoice.Next(0, 100) < randFillPercent)
                {
                    cavePoints[x, y] = 1;
                }else
                {
                    cavePoints[x, y] = 0;
                }
            }
        }

        for (int i = 0; i < smoothCycles; i++)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int neighboringWalls = GetNeighbors(x, y);

                    if (neighboringWalls > threshold)
                    {
                        cavePoints[x, y] = 1;
                    }else if (neighboringWalls < threshold)
                    {
                        cavePoints[x, y] = 0;
                    }
                }
            }
        }
    }

    private int GetNeighbors(int pointX, int pointY)
    {

        int wallNeighbors = 0;

        for (int x = pointX - 1; x <= pointX + 1; x++)
        {
            for (int y = pointY - 1; y <= pointY + 1; y++)
            {
                if (x >= 0 && x < width && y >= 0 && y < height)
                {
                    if (x != pointX || y!= pointY)
                    {
                        if (cavePoints[x,y] == 1)
                        {
                            wallNeighbors++;
                        }
                    }
                }
                else
                {
                    wallNeighbors++;
                }
            }
        }

        return wallNeighbors;
    }

    public void PlaceGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (cavePoints[x,y] == 1)
                {
                    Instantiate(BlackGranite, new Vector3(), Quaternion.identity);
                }
            }
        }
        Populate();
    }
    public void Populate()
    {
        foreach (GameObject t in GameObject.FindGameObjectsWithTag("BlackGranite")) //ore generation
        {
            if (t.transform.parent == this.gameObject.transform)
            {
                {
                    float r = Random.Range(0f, 100f);
                    GameObject selectedTile = null; //ore chance

                    if (r < chanceMythrilium)
                    {
                        selectedTile = MythryliumGraniteOre;
                    }
                    else if (r < chanceAurichalcum)
                    {
                        selectedTile = Aurichalcum;
                    }
                    if (selectedTile != null)
                    {
                        GameObject newResourceTile = Instantiate(selectedTile, t.transform.position, Quaternion.identity) as GameObject;
                        newResourceTile.transform.parent = transform;
                        Destroy(t); //destroy the black granite
                    }
                }
            }
        }
    }
}
