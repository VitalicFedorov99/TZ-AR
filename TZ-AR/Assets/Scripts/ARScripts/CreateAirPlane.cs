using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;



public class CreateAirPlane : MonoBehaviour
{
    [SerializeField]
    GameObject m_Prefab;


    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private ARAnchorManager aRAnchorManager;

    [SerializeField] private bool flag = true;
    [SerializeField] private Vector3 vectorRotate;
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text text2;

    [SerializeField] private GameObject airPlane;
    [SerializeField] private Vector3 testVector;

    private ARPlane chooseArPlane;

    private Vector3 vectorScale;

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
            text.text = "x: " + plane.size.x + " y: " + plane.size.y;
            chooseArPlane = plane;
            // Vector3 scale = new Vector3(plane.size.x, 1f, plane.size.y);
            // airPlane.transform.localScale = scale;
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


    public void Scale(bool scaleFlag)
    {
        vectorScale = airPlane.transform.localScale;

        if (scaleFlag)
        {
            vectorScale.x += 0.1f;
            vectorScale.y += 0.1f;
            vectorScale.z += 0.1f;
        }
        else
        {
            vectorScale.x -= 0.1f;
            vectorScale.y -= 0.1f;
            vectorScale.z -= 0.1f;
        }
        text2.text = "x: " + airPlane.transform.position.x + " y: " + airPlane.transform.position.y + " z: " + airPlane.transform.position.z;
        airPlane.transform.localScale = vectorScale;
    }

    /*  ARAnchor CreateAnchor(in ARRaycastHit hit)
      {
          ARAnchor anchor = null;

          // If we hit a plane, try to "attach" the anchor to the plane
          if (hit.trackable is ARPlane plane)
          {
              var planeManager = GetComponent<ARPlaneManager>();
              if (planeManager != null)
              {
                  Logger.Log("Creating anchor attachment.");

                  if (m_Prefab != null)
                  {
                      var oldPrefab = m_AnchorManager.anchorPrefab;
                      m_AnchorManager.anchorPrefab = m_Prefab;
                      anchor = m_AnchorManager.AttachAnchor(plane, hit.pose);
                      m_AnchorManager.anchorPrefab = oldPrefab;
                  }
                  else
                  {
                      anchor = m_AnchorManager.AttachAnchor(plane, hit.pose);
                  }

                  SetAnchorText(anchor, $"Attached to plane {plane.trackableId}");
                  return anchor;
              }
          }

          // Otherwise, just create a regular anchor at the hit pose
          Logger.Log("Creating regular anchor.");

          if (m_Prefab != null)
          {
              // Note: the anchor can be anywhere in the scene hierarchy
              var gameObject = Instantiate(m_Prefab, hit.pose.position, hit.pose.rotation);

              // Make sure the new GameObject has an ARAnchor component
              anchor = ComponentUtils.GetOrAddIf<ARAnchor>(gameObject, true);
          }
          else
          {
              var gameObject = new GameObject("Anchor");
              gameObject.transform.SetPositionAndRotation(hit.pose.position, hit.pose.rotation);
              anchor = gameObject.AddComponent<ARAnchor>();
          }

          SetAnchorText(anchor, $"Anchor (from {hit.hitType})");

          return anchor;
      }*/
}
