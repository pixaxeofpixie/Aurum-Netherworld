using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleChunkGen : MonoBehaviour
{
        public GameObject jungleGrass;
        public GameObject jungleStone;
        public GameObject jungleDirt;

        public GameObject pereniall;

        public int width;
        public float heightMultiplier;
        public int heightAddition;
        public float smoothness;
        public float seed;
        public float chancePereniall;

        //function start and seed
        void Start()
        {
            seed = Random.Range(-1000f, 1000f);
            Generate();
        }

        public void Generate()
        {
            for (int i = 0; i < width; i++)
            {
                int h = Mathf.RoundToInt(Mathf.PerlinNoise(seed, (i + transform.position.x) / smoothness) * heightMultiplier) + heightAddition;
                for (int j = 0; j < h; j++) //perlin noise import,chunk parametres
                {
                    GameObject selectedTile; //blocks generation
                    if (j < h - 5)
                    {
                        selectedTile = jungleStone;
                    }
                    else if (j < h - 1)
                    {
                        selectedTile = jungleDirt;
                    }
                    else
                    {
                        selectedTile = jungleGrass;
                    }
                    GameObject newTile = Instantiate(selectedTile, Vector3.zero, Quaternion.identity) as GameObject;
                    newTile.transform.parent = this.gameObject.transform;
                    newTile.transform.localPosition = new Vector3(i, j);
                }
            }
            Populate();
        }
        public void Populate()
        {
            foreach (GameObject t in GameObject.FindGameObjectsWithTag("jungleStone")) //ore geneartion
            {
                if (t.transform.parent == this.gameObject.transform)
                {
                    {
                        float r = Random.Range(0f, 100f);
                        GameObject selectedTile = null; //ore chance

                        if (r < chancePereniall)
                        {
                            selectedTile = pereniall;
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
