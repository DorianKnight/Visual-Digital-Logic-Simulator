using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMemory : MonoBehaviour
{
    public wire currentLineRenderer;
    private Camera GameCamera;
    private List<wire> wires = new List<wire>();
    // Start is called before the first frame update
    void Start()
    {
        currentLineRenderer = null;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the wire positions with the transforms of the io nodes
        Debug.Log(wires.Count);
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