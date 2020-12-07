using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public int Number;
    //crimson region
    public GameObject CrimsonGrass;
    public GameObject HighGrass;
    public GameObject Tree1;
    public GameObject Boulder;
    //crimson region end
    //jungle region
    public GameObject jungleGrass;
    public GameObject jungleTree;
    public GameObject jungleHighGrass;
    //end jungle region

    public void Start()
    {
        Number = (Random.Range( 0, 10));
        if (Number == 1)
        {
            GameObject CrimsonGrass = Instantiate(Tree1, new Vector3(), Quaternion.identity);
            CrimsonGrass.transform.parent = this.transform;
            CrimsonGrass.transform.localPosition = new Vector3(0f,0f, 0f);
        }
        Number = (Random.Range(0, 3));
        if (Number == 1)
        {
            GameObject CrimsonGrass = Instantiate(HighGrass, new Vector3(), Quaternion.identity);
            CrimsonGrass.transform.parent = this.transform;
            CrimsonGrass.transform.localPosition = new Vector3(0f, 1f, 0f);
        }
        Number = (Random.Range(0, 5));
        if (Number == 1)
        {
            GameObject CrimsonGrass = Instantiate(Boulder, new Vector3(), Quaternion.identity);
            CrimsonGrass.transform.parent = this.transform;
            CrimsonGrass.transform.localPosition = new Vector3(0f, 1f, 0f);
        }
        Number = (Random.Range(0, 15));
        if (Number == 1)
        {
            GameObject jungleGrass = Instantiate(jungleTree, new Vector3(), Quaternion.identity);
            jungleGrass.transform.parent = this.transform;
            jungleGrass.transform.localPosition = new Vector3(0f, 0f, 0f);
        }
        Number = (Random.Range(0, 3));
        if (Number == 1)
        {
            GameObject jungleGrass = Instantiate(jungleHighGrass, new Vector3(), Quaternion.identity);
            jungleGrass.transform.parent = this.transform;
            jungleGrass.transform.localPosition = new Vector3(0f, 0f, 0f);
        }
    }
}
