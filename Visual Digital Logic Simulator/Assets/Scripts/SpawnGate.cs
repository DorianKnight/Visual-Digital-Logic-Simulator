using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    private List<GameObject> GateList = new List<GameObject>();
    private Camera GameCamera;
    private GameObject chipConnectedToMouse = null;
    public bool placed = false;
    public bool pickedUp = false;
    // Start is called before the first frame update
    void Start()
    {
        GameCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // If you have a logic gate affixed to your mouse
        if (Input.GetMouseButtonDown(0))
        {
            holdSemiphore();
        }
        
        if (chipConnectedToMouse != null && pickedUp == true)
        {
            // Move the gate sprite along with the mouse
            Vector3 convertedPosition = GameCamera.ScreenToWorldPoint(Input.mousePosition);
            convertedPosition.z = 0;  // Remove z component
            chipConnectedToMouse.transform.position = convertedPosition;
            

        }

        // If you click, release the logic gate
        if (chipConnectedToMouse != null && pickedUp == false)
        {
            Debug.Log("Place logic gate");
            chipConnectedToMouse = null;
        }
    }

    public void AddGate()
    {
        Debug.Log("Create chip function has been pressed");

        // Create a game object at the same spot as the mouse
        Vector3 convertedMousePosition = GameCamera.ScreenToWorldPoint(Input.mousePosition);
        convertedMousePosition.z = 0; // Zeroing the z coordinate as the 2D game doesn't have a need for the z axis
        GameObject currentGate = Instantiate(objectToSpawn, convertedMousePosition, Quaternion.identity); //GameObject.CreatePrimitive(PrimitiveType.Cube); 
        
        // Add the new gate to a list of game objects
        GateList.Add(currentGate);
        chipConnectedToMouse = currentGate;
    }

    public void AttachGateToMouse(GameObject logicGate)
    {
        chipConnectedToMouse = logicGate;
    }

    public void setChipConnectedToMouse(string chip)
    {
      
        chipConnectedToMouse = GameObject.Find(chip);
        
    }

    public GameObject getChipConnectedToMouse()
    {
        return chipConnectedToMouse;
    }

    private void holdSemiphore()
    {
        if (pickedUp == true)
        {
            pickedUp = false;
        }
        else
        {
            pickedUp = true;
        }
    }
}
