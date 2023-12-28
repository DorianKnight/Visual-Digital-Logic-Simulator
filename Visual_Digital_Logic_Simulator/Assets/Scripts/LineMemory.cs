using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMemory : MonoBehaviour
{
    public wire currentLineRenderer;
    private Camera GameCamera;
    private List<wire> wires = new List<wire>();
    [SerializeField] public bool on_off;
    // Start is called before the first frame update
    void Start()
    {
        currentLineRenderer = null;
        on_off = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the wire positions with the transforms of the io nodes
        for (int i = 0; i < wires.Count; i++)
        {
            wire currentWire = wires[i];
            LineRenderer currentLr = currentWire.lr.GetComponent<LineRenderer>();

            currentLr.SetPosition(0, currentWire.getInputIo().transform.position);
            currentLr.SetPosition(1, currentWire.getOutputIo().transform.position);

            if (currentWire.input.GetComponent<InputOutputBehaviour>().state == true)
            {
                currentWire.lr.GetComponent<LineRenderer>().startColor = Color.green;
                currentWire.lr.GetComponent<LineRenderer>().endColor = Color.green;
                currentWire.output.GetComponent<InputOutputBehaviour>().state = true;
            }

            else if (currentWire.input.GetComponent<InputOutputBehaviour>().state == false)
            {
                currentWire.lr.GetComponent<LineRenderer>().startColor = Color.red;
                currentWire.lr.GetComponent<LineRenderer>().endColor = Color.red;
                currentWire.output.GetComponent<InputOutputBehaviour>().state = false;
            }
        }
    }

    // Create function that updates all of the line renderers to conform to the position of the io nodes
    public void addLineToMemory(wire wire)
    {
        wires.Add(wire);
    }

    public void setCurrentLineRenderer(wire currLr)
    {
        currentLineRenderer = currLr;
    }

    public wire getCurrentLineRenderer()
    {
        return currentLineRenderer;
    }
}

public class wire
{
    public GameObject lr { get; set; }
    public GameObject input { get; set; }
    public GameObject output { get; set; }
    public bool state { get; set; }

    public wire (GameObject renderer)
    {
        lr = renderer;
        input = null;
        output = null;
    }

    public GameObject getInputIo()
    {
        return input;
    }

    public void setInputIo(GameObject ioNode)
    {
        input = ioNode;
    }

    public GameObject getOutputIo()
    {
        return output;
    }

    public void setOutputIo(GameObject ioNode)
    {
        output = ioNode;
    }
}
