using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class ConnectingWires : MonoBehaviour
{
    private Camera GameCamera;
    public bool currentlyDrawing = false;
    public bool redrawOutput = false;
    //public List<GameObject> linePoints = new List<GameObject>();

    // Create the line render
    private LineRenderer wireDrawingComponent;

    // Start is called before the first frame update
    public void Awake()
    {
        GameCamera = Camera.main;
        wireDrawingComponent = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = GameCamera.ScreenToWorldPoint(Input.mousePosition);
        if (currentlyDrawing == true && redrawOutput == false)
        {
            wireDrawingComponent.SetPosition(1, mousePosition);
        }

        else if (currentlyDrawing == true && redrawOutput == true)
        {
            wireDrawingComponent.SetPosition(0, mousePosition);
        }
    }

    public void DrawLine(GameObject ioNode)
    {
        Vector3 ioNodePosition = ioNode.transform.position;
        if (currentlyDrawing == false)
        {
            // Debug.Log("Start drawing line");
            currentlyDrawing = true;

            Vector3 mousePosition = GameCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Zeroing the z coordinate as the 2D game doesn't have a need for the z axis

            // Set the line render
            wireDrawingComponent.SetPosition(0, ioNodePosition);
            wireDrawingComponent.SetPosition(1, mousePosition);

            // Add starting node to list so that the Line parent object can link the ioNode with the line render
            //linePoints.Add(ioNode);
        }

        else if (redrawOutput == true)
        {
            // Stop updating the line and attach it to ioNode position
            currentlyDrawing = false;
            redrawOutput = false;
            wireDrawingComponent.SetPosition(0, ioNodePosition);
        }
        
        else
        {
            // Stop updating the line
            currentlyDrawing = false;
            wireDrawingComponent.SetPosition(1, ioNodePosition);

            // Add end node to list so that the line parent object can link the ioNode with the line render
            //linePoints.Add(ioNode);
        }
    }

    public void RewireLine(wire connectingWire, GameObject ioNode)
    {
        // Allow for the wire to move with the mouse

        // figure out if you have to redraw the input or output
        Vector3 ioNodePosition = ioNode.transform.position;
        if (connectingWire.input.transform.position == ioNodePosition)
        {
            // Redraw the input section of wire which is also the output node of the chip
            redrawOutput = true;
        }

        currentlyDrawing = true;
    }
}
