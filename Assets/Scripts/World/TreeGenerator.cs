using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public int Number;
    //crimson region
    public GameObject CrimsonGrass;
    public GameObject HighGrass;
    public GameObject CrimsonTree;
    public GameObject Boulder;
    //crimson region end
    //jungle region
    public GameObject jungleGrass;
    public GameObject jungleTree;
    public GameObject jungleHighGrass;
    //end jungle region
    //distortion region start
    public GameObject distortedTree;
    public GameObject distortedGrass;
    public GameObject distortedHighGrass;
    public GameObject distortedBoulder;
    //distortion region end
    public void Start()
    {
        //crimson region start
        Number = (Random.Range( 0, 10));
        if (Number == 1)
        {
            GameObject CrimsonGrass = Instantiate(CrimsonTree, new Vector3(), Quaternion.identity);
            CrimsonGrass.transform.parent = this.transform;
            CrimsonGrass.transform.localPosition = new Vector3(0f,0f, 0f);
        }
        Number = (Random.Range(0, 4));
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
        //crimson region end
        //jungle region start
        Number = (Random.Range(0, 11));
        if (Number == 1)
        {
            GameObject jungleGrass = Instantiate(jungleTree, new Vector3(), Quaternion.identity);
            jungleGrass.transform.parent = this.transform;
            jungleGrass.transform.localPosition = new Vector3(0f, 0f, 0f);
        }
        Number = (Random.Range(0, 4));
        if (Number == 1)
        {
            GameObject jungleGrass = Instantiate(jungleHighGrass, new Vector3(), Quaternion.identity);
            jungleGrass.transform.parent = this.transform;
            jungleGrass.transform.localPosition = new Vector3(0f, 1f, 0f);
        }
        //jungle region end
        //distortion region start
        Number = (Random.Range(0, 11));
        if (Number == 1)
        {
            GameObject distortedGrass = Instantiate(distortedTree, new Vector3(), Quaternion.identity);
            distortedGrass.transform.parent = this.transform;
            distortedGrass.transform.localPosition = new Vector3(0f, 0f, 0f);
        }
        Number = (Random.Range(0, 4));
        if (Number == 1)
        {
            GameObject distortedGrass = Instantiate(distortedHighGrass, new Vector3(), Quaternion.identity);
            distortedGrass.transform.parent = this.transform;
            distortedGrass.transform.localPosition = new Vector3(0f, 1f, 0f);
        //distortion region end
        }
    }
}
