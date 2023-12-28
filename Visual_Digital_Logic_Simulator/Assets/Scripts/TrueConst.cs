using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueConst : MonoBehaviour
{
    private List<GameObject> OutputList = new List<GameObject>();
    [SerializeField] private GameObject objectToSpawn;
    private GameObject TrueConstSpawner;
    public bool state;
    void Start()
    {
        state = true;
        TrueConstSpawner = GameObject.Find("TrueConstSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        if (OutputList.Count > 0)
        {
            OutputList[0].GetComponent<InputOutputBehaviour>().state = state;
        }
    }

    public void CreateIO(Transform chip)
    {
        // Instantiate circle sprites based on the inputs and outputs
        Debug.Log("Input object created");

        // Instantiate output object
        Vector3 coordinateOutput = new Vector3(chip.position.x + 0.5f, chip.position.y, -1);
        GameObject output = Instantiate(objectToSpawn, coordinateOutput, Quaternion.identity, chip);
        output.GetComponent<InputOutputBehaviour>().input_or_output = true;  // Set as output
        OutputList.Add(output);
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && TrueConstSpawner.GetComponent<TrueConstSpawner>().pickedUp == false && TrueConstSpawner.GetComponent<TrueConstSpawner>().getChipConnectedToMouse() == null)
        {
            // If there isn't already a chip connected to the mouse
            TrueConstSpawner.GetComponent<TrueConstSpawner>().setChipConnectedToMouse(GetComponent<Transform>());

        }
    }
}