using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProject : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();

    public GameObject effectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnVFX();
        }



    }

    void SpawnVFX()
    {
        GameObject vfx;
        if (firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, firePoint.transform.rotation);
        }
        else
        {
            Debug.Log("Não pode Atirar");
        }
    }


}
