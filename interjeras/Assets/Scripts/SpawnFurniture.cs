using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnFurniture : MonoBehaviour
{
    public List<GameObject> catalog = new List<GameObject>();

    public List<GameObject> furniture = new List<GameObject>();

    public void Spawn() 
    {
        GameObject furnitureInstance = Instantiate(EventSystem.current.currentSelectedGameObject.GetComponent<Furniture>().furniture);
        furnitureInstance.transform.position = new Vector3(0, 0.5f, 0);

        furniture.Add(furnitureInstance);
    }

    public void Save() 
    {
        Saving.Save(this);
    }

    public void Load() 
    {
        foreach (GameObject obj in furniture) 
        {
            Destroy(obj);
        }

        furniture = new List<GameObject>();

        Data data = Saving.Load();

        for (int i = 0; i < data.id.Count; i++)
        {
            GameObject instance = Instantiate(catalog[data.id[i]], new Vector3(data.posX[i], catalog[data.id[i]].transform.position.y, data.posZ[i]), Quaternion.identity);
            instance.GetComponent<Renderer>().material.SetColor("_Color", new Color(data.r[i], data.g[i], data.b[i], 1));
            furniture.Add(instance);
        }
    }
}
