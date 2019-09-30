using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class linqTest : MonoBehaviour
{
    public List<GameObject> cubes = new List<GameObject>();
    public List<Material> materials = new List<Material>();
    IEnumerable<GameObject> numberQuery;

    // Start is called before the first frame update
    void Start()
    {

        numberQuery = from index in cubes where index.GetComponent<cubeBehaviour>().cubeInfo < 3 select index;

        //numberQuery = cubes.Where(x => x.GetComponent<cubeBehaviour>().cubeInfo < 3);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            ChangeColor();
    }

    private void ChangeColor()
    {

        foreach (GameObject index in numberQuery)
            index.GetComponent<MeshRenderer>().material = materials[1];
    }

}
