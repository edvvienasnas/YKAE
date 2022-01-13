using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Camera cam;
    public LayerMask furnitureLayer;
    public LayerMask floorLayer;
    public float height = 1.0f;

    [HideInInspector] public bool isSelected;
    [SerializeField] float initialPos = 0.5f;

    [HideInInspector] public GameObject activeObject;

    OptionsUI optionsUI;
    SpawnFurniture spawnFurniture;

    private void Start()
    {
        optionsUI = GetComponent<OptionsUI>();
        spawnFurniture = GetComponent<SpawnFurniture>();
    }

    private void Update()
    {
        //pick up
        if (Input.GetKey(KeyCode.Mouse0)) 
        {
            Ray lmbRay = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(lmbRay, out RaycastHit lmbHit, 100, furnitureLayer) && isSelected == false) 
            {
                isSelected = true;
                optionsUI.inspector.SetActive(false);
                optionsUI.catalog.SetActive(false);
                activeObject = lmbHit.transform.gameObject;
            }   
        }

        //put down
        if (Input.GetKeyUp(KeyCode.Mouse0)) 
        {
            if(activeObject != null) activeObject.transform.position = new Vector3(activeObject.transform.position.x, initialPos, activeObject.transform.position.z);
            optionsUI.catalog.SetActive(true);
            //spawnFurniture.pos
            isSelected = false;
        }

        //move selected
        if (activeObject != null && isSelected != false) 
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100, floorLayer))
                activeObject.transform.position = new Vector3(hit.point.x, height, hit.point.z);
        }
    }
}
