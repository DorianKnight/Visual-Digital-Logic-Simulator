using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputOutputBehaviour : MonoBehaviour
{
    private GameObject LineParent;
    public GameObject renderConnectingWire;
    [SerializeField] public GameObject lineRenderer;
    public List<GameObject> linePoints = new List<GameObject>();
    wire currentRenderer;
    private bool connected;
    [SerializeField] public bool state;
    public bool input_or_output;  // false for input, true for output

    // Start is called before the first frame update
    void Start()
    {
        renderConnectingWire = null;
        LineParent = GameObject.Find("LineParent");
        connected = false;
        //state = false;
        currentRenderer = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (connected == false)
        {
            
            //Debug.Log("Clicked an object");
            currentRenderer = LineParent.GetComponent<LineMemory>().getCurrentLineRenderer();
            if (currentRenderer == null)
            {
                connected = true;
                // Debug.Log("Instantiate new line");
                // If a line has not been created, instantiate the line
                renderConnectingWire = Instantiate(lineRenderer);
                currentRenderer = new wire(renderConnectingWire);
                // Attach the current line rendering object to the persistent LineParent game object so this renderer can be referred to later
                LineParent.GetComponent<LineMemory>().setCurrentLineRenderer(currentRenderer);

                currentRenderer.lr.GetComponent<ConnectingWires>().DrawLine(this.gameObject);

                // Add starting node to list so that the Line parent object can link the ioNode with the line render
                if (input_or_output == false)
                {
                    // Input of chip but output of wire
                    currentRenderer.setOutputIo(this.gameObject);
                }
                
                else if (input_or_output == true)
                {
                    // Output of chip but input of wire
                    currentRenderer.setInputIo(this.gameObject);
                }
            }

            else if ((input_or_output == false && currentRenderer.getOutputIo() == null) || (input_or_output == true && currentRenderer.getInputIo() == null))
            {
                connected = true;
                // Only end the line if 
                // 1. You are an input and the wire does not already have an input
                // 2. You are an output and the wire does not already have an output

                // End point for line has been designated, finish drawing line
                currentRenderer.lr.GetComponent<ConnectingWires>().DrawLine(this.gameObject);

                // Add end node to list so that the line parent object can link the ioNode with the line render
                if (input_or_output == false)
                {
                    // Input of chip but output of wire
                    currentRenderer.setOutputIo(this.gameObject);
                }
                
                else if (input_or_output == true)
                {
                    // Output of chip but input of wire
                    currentRenderer.setInputIo(this.gameObject);
                }
                
                // Adds the Line to memory such that upon subsequent updates, the line's position will update to the ioNode's position
                LineParent.GetComponent<LineMemory>().addLineToMemory(currentRenderer);

                // Remove this instance of linerenderer from the LineParent so you can create a new line
                LineParent.GetComponent<LineMemory>().setCurrentLineRenderer(null);
            }

            else
            {
                Debug.Log("Attempting to end wire at an identical io type. Wire is either terminating at two inputs or two outputs \nChange your configuration such that the wire ends at an opposite terminal, input to output or output to input");
            }
        }

        else
        {
            // Manipulate the wire connected to the input as long as you have no other loose wires
            if (LineParent.GetComponent<LineMemory>().getCurrentLineRenderer() == null)
            {
                LineParent.GetComponent<LineMemory>().setCurrentLineRenderer(currentRenderer);
                // Free this node as it no longer has a wire attached
                connected = false;
                currentRenderer.lr.GetComponent<ConnectingWires>().RewireLine(currentRenderer, this.gameObject);

                if (input_or_output == false)
                {
                    // Input of chip but output of wire
                    currentRenderer.setOutputIo(null); // Free the input
                }

                else if (input_or_output == true)
                {
                    // Output of chip but input of wire
                    currentRenderer.setInputIo(null);
                }
            }
            
            else
            {
                Debug.Log("You already have a 'free standing' wire currently being edited \nPlace that line first and then you may edit other lines");
            }
            
        }
        
    }
}
