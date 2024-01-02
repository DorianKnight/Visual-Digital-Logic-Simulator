using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrBehaviour : MonoBehaviour
{
    private GameObject OrSpawner;
    private List<GameObject> InputList = new List<GameObject>();
    private List<GameObject> OutputList = new List<GameObject>();
    [SerializeField] private GameObject objectToSpawn;
    public bool state;
    // Start is called before the first frame update
    void Start()
    {
        OrSpawner = GameObject.Find("OrSpawner");
    }

    private void Update()
    {
        if (InputList.Count > 0 && OutputList.Count > 0)
        {
            state = InputList[0].GetComponent<InputOutputBehaviour>().state || InputList[1].GetComponent<InputOutputBehaviour>().state;
            OutputList[0].GetComponent<InputOutputBehaviour>().state = state;
            //Debug.Log("The internal logic function is running");
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && OrSpawner.GetComponent<SpawnOr>().pickedUp == false && OrSpawner.GetComponent<SpawnOr>().getChipConnectedToMouse() == null)
        {
            // If there isn't already a chip connected to the mouse
            OrSpawner.GetComponent<SpawnOr>().setChipConnectedToMouse(GetComponent<Transform>());

        }
    }

    public void CreateIO(Transform chip)
    {
        // Instantiate circle sprites based on the inputs and outputs
        // Debug.Log("Input object created");

        // Input 1
        Vector3 coordinateInput = new Vector3(chip.position.x - 0.5f, chip.position.y + 0.25f, -1);
        GameObject input = Instantiate(objectToSpawn, coordinateInput, Quaternion.identity, chip);
        input.GetComponent<InputOutputBehaviour>().input_or_output = false;  // Set as input
        InputList.Add(input);

        // Input 2
        coordinateInput = new Vector3(chip.position.x - 0.5f, chip.position.y - 0.25f, -1);
        input = Instantiate(objectToSpawn, coordinateInput, Quaternion.identity, chip);
        input.GetComponent<InputOutputBehaviour>().input_or_output = false;  // Set as input
        InputList.Add(input);

        // Instantiate output object
        Vector3 coordinateOutput = new Vector3(chip.position.x + 0.5f, chip.position.y, -1);
        GameObject output = Instantiate(objectToSpawn, coordinateOutput, Quaternion.identity, chip);
        output.GetComponent<InputOutputBehaviour>().input_or_output = true;  // Set as output
        OutputList.Add(output);
    }
}
