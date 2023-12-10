using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectingWires : MonoBehaviour
{
    private Camera GameCamera;
    public bool currentlyDrawing = false;
    public int pointsCount;

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
        if (currentlyDrawing == true)
        {
            Vector3 mousePosition = GameCamera.ScreenToWorldPoint(Input.mousePosition);
            wireDrawingComponent.SetPosition(1, mousePosition);
        }
    }

    public void DrawLine(Vector3 ioNodePosition)
    {
        if (currentlyDrawing == false)
        {
            Debug.Log("Start drawing line");
            currentlyDrawing = true;

            Vector3 mousePosition = GameCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Zeroing the z coordinate as the 2D game doesn't have a need for the z axis

            // Set the line render
            wireDrawingComponent.SetPosition(0, ioNodePosition);
            wireDrawingComponent.SetPosition(1, mousePosition);
        }

        else
        {
            // Stop updating the line
            currentlyDrawing = false;
            wireDrawingComponent.SetPosition(1, ioNodePosition);
        }
    }
}
