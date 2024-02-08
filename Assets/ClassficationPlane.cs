using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using System.Diagnostics;


public class ClassficationPlane : MonoBehaviour
{

    public ARPlane aRPlane;
    public MeshRenderer meshRenderer;
    public TextMesh textMesh;
    public GameObject textObj;
    
    GameObject mainCam;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCam= FindObjectOfType<Camera>().gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateLabel();
        UpdatePlaneColor();
    }

    void UpdateLabel()
    {
        textMesh.text=aRPlane.classification.ToString();
        textObj.transform.position=aRPlane.center;
        textObj.transform.LookAt(mainCam.transform);
        textObj.transform.Rotate(new Vector3(0,180,0));

    }

    void UpdatePlaneColor()
    {
        Color planeMatColor=Color.cyan;

        switch(aRPlane.classification)
        {
            case PlaneClassification.None:
                planeMatColor=Color.cyan;
                break;
            case PlaneClassification.Wall:
                planeMatColor=Color.white;
                break;
            case PlaneClassification.Floor:
                planeMatColor=Color.green;
                break;
            case PlaneClassification.Ceiling:
                planeMatColor=Color.blue;
                break;
            case PlaneClassification.Table:
                planeMatColor=Color.yellow;
                break;
            case PlaneClassification.Seat:
                planeMatColor=Color.magenta;
                break;
            case PlaneClassification.Door:
                planeMatColor=Color.red;
                break;
            case PlaneClassification.Window:
                planeMatColor=Color.clear;
                break;
        }
        planeMatColor.a=0.33f;
        meshRenderer.material.color=planeMatColor;
    }


}
