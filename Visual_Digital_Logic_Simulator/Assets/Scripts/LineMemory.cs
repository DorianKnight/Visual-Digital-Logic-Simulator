using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMemory : MonoBehaviour
{
    public GameObject currentLineRenderer;
    private Camera GameCamera;
    // Start is called before the first frame update
    void Start()
    {
        currentLineRenderer = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setCurrentLineRenderer(GameObject currLr)
    {
        currentLineRenderer = currLr;
    }

    public GameObject getCurrentLineRenderer()
    {
        return currentLineRenderer;
    }
}
