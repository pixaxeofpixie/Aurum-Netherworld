using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public GameObject inventory;
    public GameObject container;
    public GameObject itemPrefab;
    public GameObject marker;
    public int maxContainersCountY = 6;
    public int maxContainersCountX = 8;
    public int maxInContainersCount = 48;
    public void Start()
    {
        for(int y = 0; y < maxContainersCountY; y++)
        {
            for (int x = 0; x < maxContainersCountX; x++)
            {
                Instantiate(container, new Vector3(x * 2.0F, marker.transform.position.y, 0), Quaternion.identity);
                container.transform.parent = marker.transform;
                container.transform.position = new Vector3(x * 2.0F, marker.transform.position.y, 0f);
            }
        }
    }
}
