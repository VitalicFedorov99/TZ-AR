using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

using TMPro;

public class TestAnchor : MonoBehaviour
{
    public GameObject cube;
    public ARAnchorManager aRAnchorManager;
    public ARPlane plane;
    public GameObject CameraObject;

    public TMP_Text text;

    private void Start()
    {
        CreateAnchor();
        //arAnchor.

        //   aRAnchorManager.AttachAnchor(arAnchor, cube);
    }


    private void CreateAnchor()
    {
        Pose pose = new Pose(cube.transform.position, cube.transform.rotation);
        ARAnchor anchor = aRAnchorManager.AttachAnchor(plane, pose);
        
        //aRAnchorManager.anchorPrefab = cube;
    }

    private void Update()
    {
        if (text == null)
            return;

        text.text = "X1: " + CameraObject.transform.position.x + "Y1: " + CameraObject.transform.position.y + "Z1: " + CameraObject.transform.position.z + "/n " +
            "X2: " + cube.transform.position.x + "Y2: " + cube.transform.position.y + "Z2: " + cube.transform.position.z;
    }
}
