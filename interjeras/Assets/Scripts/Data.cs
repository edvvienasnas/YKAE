using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data 
{
    public List<int> id = new List<int>();

    public List<float> posX = new List<float>();
    public List<float> posZ = new List<float>();

    public List<float> r = new List<float>();
    public List<float> g = new List<float>();
    public List<float> b = new List<float>();

    public Data(SpawnFurniture spawnFurniture) 
    {
        for (int i = 0; i < spawnFurniture.furniture.Count; i++)
        {
            id.Add(spawnFurniture.furniture[i].GetComponent<PrefabID>().id);

            posX.Add(spawnFurniture.furniture[i].transform.position.x);
            posZ.Add(spawnFurniture.furniture[i].transform.position.z);

            r.Add(spawnFurniture.furniture[i].GetComponent<Renderer>().material.GetColor("_Color").r);
            g.Add(spawnFurniture.furniture[i].GetComponent<Renderer>().material.GetColor("_Color").g);
            b.Add(spawnFurniture.furniture[i].GetComponent<Renderer>().material.GetColor("_Color").b);
        }
    }
}
