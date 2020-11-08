using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public int Number;
    public GameObject CrimsonGrass;
    public GameObject Tree1;

    void Start()
    {
        Number = (Random.Range( 0, 10));
        if (Number == 1)
        {
            GameObject CrimsonGrass = Instantiate(Tree1, new Vector3(), Quaternion.identity);
            CrimsonGrass.transform.parent = this.transform;
            CrimsonGrass.transform.localPosition = new Vector3(-0.05f, 0.3f, 0f);
        }
    }
}
