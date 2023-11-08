using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CreateAirPlane : MonoBehaviour
{
    [SerializeField]
    GameObject m_Prefab;


    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private ARAnchorManager aRAnchorManager;

    [SerializeField] private bool flag = true;
    [SerializeField] private Vector3 vectorRotate;



    [SerializeField] private GameObject airPlane;
    [SerializeField] private Vector3 testVector;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float speed;
    private ARPlane chooseArPlane;


    

    public void InstantiateAirPlane(ARRaycastHit hit)
    {
        if (!flag)
            return;


        if (hit.trackable is ARPlane plane)
        {
            Vector3 planeVector = new Vector3(plane.center.x + testVector.x, plane.center.y + testVector.y, plane.center.z + testVector.z);
            planeVector.x = Mathf.Ceil(planeVector.x);
            planeVector.y = Mathf.Ceil(planeVector.y);
            planeVector.z = Mathf.Ceil(planeVector.z);

            airPlane = Instantiate(m_Prefab, planeVector, Quaternion.Euler(vectorRotate));
            chooseArPlane = plane;
            flag = false;
        }
        planeManager.enabled = false;
    }

    public void CreateAnchor()
    {
        Pose pose = new Pose(airPlane.transform.position, airPlane.transform.rotation);
        ARAnchor anchor = aRAnchorManager.AttachAnchor(chooseArPlane, pose);

        //aRAnchorManager.anchorPrefab = cube;
    }


    
}
