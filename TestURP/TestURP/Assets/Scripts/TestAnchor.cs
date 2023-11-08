using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TestAnchor : MonoBehaviour
{
    [SerializeField] public GameObject cube;
    [SerializeField] public ARAnchorManager aRAnchorManager;
    public ARPlane plane;


    void Start()
    {
        Pose pose = new Pose(cube.transform.position, cube.transform.rotation);
        ARAnchor anchor = aRAnchorManager.AttachAnchor(plane, pose);
    }
}
