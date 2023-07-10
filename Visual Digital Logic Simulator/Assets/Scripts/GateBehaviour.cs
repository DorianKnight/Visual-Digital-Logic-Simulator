using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehaviour : MonoBehaviour
{
    private string LogicGate;
    private GameObject GateSpawner;
    // Start is called before the first frame update
    void Start()
    {
        LogicGate = this.name;
        GateSpawner = GameObject.Find("GateSpawner");

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, hit))
            {
                if (hit.transform.name == this.name)
                {
                    Debug.Log("Gate clicked");
                }
            }
        }*/


        
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && GateSpawner.GetComponent<SpawnGate>().pickedUp == false)
        {
            if (GateSpawner.GetComponent<SpawnGate>().getChipConnectedToMouse() == null)
            {
                // If there isn't already a chip connected to the mouse
                Debug.Log("Gate clicked");
                GateSpawner.GetComponent<SpawnGate>().setChipConnectedToMouse(LogicGate);
            }
        }
    }
}
