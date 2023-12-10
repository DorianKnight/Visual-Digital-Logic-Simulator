using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputOutputBehaviour : MonoBehaviour
{
    private GameObject LineParent;
    public GameObject renderConnectingWire;
    [SerializeField] public GameObject lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        renderConnectingWire = null;
        LineParent = GameObject.Find("LineParent");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked an object");
        GameObject currentRenderer = LineParent.GetComponent<LineMemory>().getCurrentLineRenderer();
        if (currentRenderer == null) 
        {          
            // If a line has not been created, instantiate the line
            renderConnectingWire = Instantiate(lineRenderer);

            // Attach the current line rendering object to the persistent LineParent game object so this renderer can be referred to later
            LineParent.GetComponent<LineMemory>().setCurrentLineRenderer(renderConnectingWire);

            renderConnectingWire.GetComponent<ConnectingWires>().DrawLine(this.transform.position);
        }
        
        else
        {
            // End point for line has been designated, finish drawing line
            currentRenderer.GetComponent<ConnectingWires>().DrawLine(this.transform.position);

            // Remove this instance of linerenderer from the LineParent so you can create a new line
            LineParent.GetComponent<LineMemory>().setCurrentLineRenderer(null);
        }
    }
}
