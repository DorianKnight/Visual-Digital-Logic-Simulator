using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    private Camera GameCamera;
    private Transform chipConnectedToMouse = null;
    public bool pickedUp = false;
    private bool justPickedUp;

    // Start is called before the first frame update
    void Start()
    {
        GameCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // If you click, release the logic gate
        if (chipConnectedToMouse != null && Input.GetMouseButtonDown(0) && justPickedUp == false)
        {
            // Debug.Log("Place logic gate");
            chipConnectedToMouse = null;
            pickedUp = false;
        }
        
        
        if (chipConnectedToMouse != null && pickedUp == true)
        {
            // Move the gate sprite along with the mouse
            Vector3 convertedPosition = GameCamera.ScreenToWorldPoint(Input.mousePosition);
            convertedPosition.z = 0;  // Remove z component
            chipConnectedToMouse.position = convertedPosition;

            // Set to false because the get mouse button down event will automatically release the chip when you pick it up
            justPickedUp = false;  
        }
    }

    public void AddGate()
    {
        // Debug.Log("Create chip function has been pressed");

        // Create a game object at the same spot as the mouse
        Vector3 convertedMousePosition = GameCamera.ScreenToWorldPoint(Input.mousePosition);
        convertedMousePosition.z = 0; // Zeroing the z coordinate as the 2D game doesn't have a need for the z axis
        GameObject currentGate = Instantiate(objectToSpawn, convertedMousePosition, Quaternion.identity); //GameObject.CreatePrimitive(PrimitiveType.Cube); 
        chipConnectedToMouse = currentGate.transform;
        pickedUp = true;

        // Generates the inputs and outputs
        currentGate.GetComponent<GateBehaviour>().CreateIO(currentGate.transform);
    }

    public void setChipConnectedToMouse(Transform chip)
    {
        //Debug.Log("Pick up logic gate");
        chipConnectedToMouse = chip;
        justPickedUp = true;
        pickedUp = true;
    }

    public Transform getChipConnectedToMouse()
    {
        return chipConnectedToMouse;
    }
}
