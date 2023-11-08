using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCreateAirPlane : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Vector3 vectorRotate;


    void Start()
    {
        Instantiate(prefab, transform.position, Quaternion.Euler(vectorRotate));
    }

 
}
