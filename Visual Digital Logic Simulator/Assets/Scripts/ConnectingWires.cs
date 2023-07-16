using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectingWires : MonoBehaviour
{
    private Camera GameCamera;
    private bool currentlyDrawing = false;
    private bool justCreated = false;

    // Create the line render
    GameObject LineContainer;
    LineRenderer LineRenderComponent;

    // Start is called before the first frame update
    void Start()
    {
        GameCamera = Camera.main;
        LineContainer = GameObject.Find("LineObject");
        LineRenderComponent = LineContainer.GetComponent<LineRenderer>();
        // LineRenderComponent.SetWidth(0.5f,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && justCreated == false)
        {
            currentlyDrawing = false;
        }

        if (currentlyDrawing)
        {
            Vector3 mousePosition = GameCamera.ScreenToWorldPoint(Input.mousePosition);
            LineRenderComponent.SetPosition(1, mousePosition);
            justCreated = false;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Pushed the input/output");
        // Set the line render
        Vector3 mousePosition = GameCamera.ScreenToWorldPoint(Input.mousePosition);
        LineRenderComponent.SetPosition(0, gameObject.transform.position);
        LineRenderComponent.SetPosition(1, mousePosition);
        currentlyDrawing = true;
        justCreated = true;
    }
}
