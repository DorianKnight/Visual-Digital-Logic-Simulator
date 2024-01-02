using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotBehaviour : MonoBehaviour
{
    private GameObject NotSpawner;
    private List<GameObject> InputList = new List<GameObject>();
    private List<GameObject> OutputList = new List<GameObject>();
    [SerializeField] private GameObject objectToSpawn;
    public bool state;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 appliedRotation = new Vector3(0, 0, 270);
        this.gameObject.transform.Rotate(appliedRotation);
        NotSpawner = GameObject.Find("NotSpawner");
    }

    private void Update()
    {
        if (InputList.Count > 0 && OutputList.Count > 0)
        {
            state = !(InputList[0].GetComponent<InputOutputBehaviour>().state);
            OutputList[0].GetComponent<InputOutputBehaviour>().state = state;
            //Debug.Log("The internal logic function is running");
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && NotSpawner.GetComponent<SpawnNot>().pickedUp == false && NotSpawner.GetComponent<SpawnNot>().getChipConnectedToMouse() == null)
        {
            // If there isn't already a chip connected to the mouse
            NotSpawner.GetComponent<SpawnNot>().setChipConnectedToMouse(GetComponent<Transform>());

        }
    }

    public void CreateIO(Transform chip)
    {
        // Instantiate circle sprites based on the inputs and outputs
        // Debug.Log("Input object created");

        Vector3 coordinateInput = new Vector3(chip.position.x, chip.position.y-0.25f, -1);
        GameObject input = Instantiate(objectToSpawn, coordinateInput, Quaternion.identity, chip);
        input.GetComponent<InputOutputBehaviour>().input_or_output = false;  // Set as input
        InputList.Add(input);

        // Instantiate output object
        Vector3 coordinateOutput = new Vector3(chip.position.x, chip.position.y+0.65f, -1);
        GameObject output = Instantiate(objectToSpawn, coordinateOutput, Quaternion.identity, chip);
        output.GetComponent<InputOutputBehaviour>().input_or_output = true;  // Set as output
        OutputList.Add(output);
    }
}
