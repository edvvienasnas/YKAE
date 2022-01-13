using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OptionsUI : MonoBehaviour
{
    public GameObject inspector;
    public GameObject catalog;

    Pickup pickup;
    SpawnFurniture spawnFurniture;

    private void Start()
    {
        pickup = GetComponent<Pickup>();
        spawnFurniture = GetComponent<SpawnFurniture>();
    }

    private void Update()
    {
        if (inspector.activeSelf == false && pickup.activeObject != null && !pickup.isSelected) inspector.SetActive(true);
        if (inspector.activeSelf == true && pickup.activeObject == null) inspector.SetActive(false);
    }

    public void ChangeColor() 
    {
        Color color = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;
        pickup.activeObject.GetComponent<Renderer>().material.SetColor("_Color", color);
    }

    public void DeleteSelected() 
    {
        spawnFurniture.furniture.Remove(pickup.activeObject);
        Destroy(pickup.activeObject);
    }
}
