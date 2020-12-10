using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Text inventoryText, inventoryText2, inventoryText3, selectionText;

    int selectedTile;

    int[] counts = new int[19];

    string[] names = new string[] { "Dirt", "Grass", "Granite", "Aurichalcum", "Mythrylium", "Wood", "Leaf", "JungleLeaf", "JungleLowGrass", "JungleDirt", "JungleTree", "Pereniall", "JungleStone", "DistortedLowGrass", "DistortedTree", "DistortedLeaf", "DistortedDirt", "Basalt", "DistortedOre" };

    public GameObject[] tiles = new GameObject[19];

    void Update()
    {
        inventoryText.text = " " + counts[0] + "\n " + counts[1] + "\n " + counts[2] + "\n " + counts[3] + "\n " + counts[4] + "\n " + counts[5] + "\n " + counts[6];
        inventoryText2.text = " " + counts[7] + "\n " + counts[8] + "\n " + counts[9] + "\n " + counts[10] + "\n " + counts[11] + "\n " + counts[12] + "\n " + counts[13];
        inventoryText3.text = " " + counts[14] + "\n " + counts[15] + "\n " + counts[16] + "\n " + counts[17] + "\n " + counts[18];

        if (selectedTile < 0)
        {
            selectedTile = counts.Length - 1;
        }
        if (selectedTile > counts.Length - 1)
        {
            selectedTile = 0;
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            selectedTile++;
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            selectedTile--;
        }

        selectionText.text = "Selected Tile Is " + names[selectedTile];

        if (Input.GetMouseButton(1))
        {
            if (counts[selectedTile] > 0)
            {

                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Vector3 placePos = new Vector3(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y), 0f);

                if (Physics2D.OverlapCircleAll(placePos, 0.25f).Length == 0)
                {
                    GameObject newTile = Instantiate(tiles[selectedTile], placePos, Quaternion.identity) as GameObject;
                    counts[selectedTile]--;
                }
            }
        }
    }
    public void Add(int tileType, int count)
    {
        counts[tileType] += count;
    }
}
