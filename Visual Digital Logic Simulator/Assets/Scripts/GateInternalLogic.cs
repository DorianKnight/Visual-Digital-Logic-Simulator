using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateInternalLogic : MonoBehaviour
{
    private List<GameObject> InputList = new List<GameObject>();
    private List<GameObject> OutputList = new List<GameObject>();
    [SerializeField] private GameObject objectToSpawn;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateIO(Transform chip)
    {
        // Instantiate circle sprites based on the inputs and outputs
        Debug.Log("Input object created");
        
        Vector3 coordinateInput = new Vector3(chip.position.x - 0.5f, chip.position.y, -1);
        GameObject input = Instantiate(objectToSpawn, coordinateInput, Quaternion.identity, chip);
        InputList.Add(input);

        // Instantiate output object
        Vector3 coordinateOutput = new Vector3(chip.position.x + 0.5f, chip.position.y, -1);
        GameObject output = Instantiate(objectToSpawn, coordinateOutput, Quaternion.identity, chip);
        OutputList.Add(output);
    }
}
