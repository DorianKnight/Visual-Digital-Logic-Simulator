using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehaviour : MonoBehaviour
{
    private GameObject GateSpawner;
    // Start is called before the first frame update
    void Start()
    { 
        GateSpawner = GameObject.Find("GateSpawner");
    }


    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && GateSpawner.GetComponent<SpawnGate>().pickedUp == false && GateSpawner.GetComponent<SpawnGate>().getChipConnectedToMouse() == null)
        {
            // If there isn't already a chip connected to the mouse
            GateSpawner.GetComponent<SpawnGate>().setChipConnectedToMouse(GetComponent<Transform>());

        }
    }
}
