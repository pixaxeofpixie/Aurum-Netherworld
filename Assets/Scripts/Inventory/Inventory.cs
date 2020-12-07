using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Text inventoryText, selectionText;

    int selectedTile;

    int[] counts = new int[7];

    string[] names = new string[] { "Dirt", "Grass", "Granite", "Aurichalcum", "Mythrylium", "Wood", "Leaf" };

    public GameObject[] tiles = new GameObject[7];
 
    void Update()
    {
        inventoryText.text = "Crimson Dirt: " + counts [0] + "\nCrimson Grass: " + counts [1] + "\nGranite: " + counts [2] + "\nAurichalcum: " + counts [3] + "\nMythrylium Ore: " + counts [4] + "\nWood: " + counts[5] + "\nLeaf: " + counts[6];

        if(selectedTile < 0)
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

        selectionText.text = "Selected Tile is " + names[selectedTile];

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
