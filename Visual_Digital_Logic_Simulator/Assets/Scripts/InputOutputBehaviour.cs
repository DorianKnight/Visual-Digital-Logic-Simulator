using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputOutputBehaviour : MonoBehaviour
{
    private GameObject LineParent;
    public GameObject renderConnectingWire;
    [SerializeField] public GameObject lineRenderer;
    public List<GameObject> linePoints = new List<GameObject>();

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
        wire currentRenderer = LineParent.GetComponent<LineMemory>().getCurrentLineRenderer();
        if (currentRenderer == null) 
        {
            // Debug.Log("Instantiate new line");
            // If a line has not been created, instantiate the line
            renderConnectingWire = Instantiate(lineRenderer);
            wire connectingWire = new wire(renderConnectingWire);
            // Attach the current line rendering object to the persistent LineParent game object so this renderer can be referred to later
            LineParent.GetComponent<LineMemory>().setCurrentLineRenderer(connectingWire);

            connectingWire.lr.GetComponent<ConnectingWires>().DrawLine(this.gameObject);

            // Add starting node to list so that the Line parent object can link the ioNode with the line render
            connectingWire.setInputIo(this.gameObject);
        }

        else
        {
            // End point for line has been designated, finish drawing line
            currentRenderer.lr.GetComponent<ConnectingWires>().DrawLine(this.gameObject);

            // Add end node to list so that the line parent object can link the ioNode with the line render
            currentRenderer.setOutputIo(this.gameObject);

            // Adds the Line to memory such that upon subsequent updates, the line's position will update to the ioNode's position
            LineParent.GetComponent<LineMemory>().addLineToMemory(currentRenderer);

            // Remove this instance of linerenderer from the LineParent so you can create a new line
            LineParent.GetComponent<LineMemory>().setCurrentLineRenderer(null);
        }
    }
}
