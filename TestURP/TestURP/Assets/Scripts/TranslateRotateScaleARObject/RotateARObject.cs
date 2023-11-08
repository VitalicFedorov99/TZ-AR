using UnityEngine;

public class RotateARObject 
{
    private float rotationSpeed;
    private GameObject arObject;
    private float newRotation;
 
    
    public RotateARObject(float speed) 
    {
        rotationSpeed = speed;
    }

    public void Setup(GameObject obj)
    {
        arObject = obj;
    }

    public void DeleteObject() 
    {
        arObject = null;
    }


    public void Rotate(EnumOrientations orientation)
    {
        if (arObject == null)
            return;
        
        switch (orientation)
        {
            case EnumOrientations.XPositive:
                newRotation = arObject.transform.rotation.eulerAngles.x + rotationSpeed;
                arObject.transform.rotation = Quaternion.Euler(newRotation, arObject.transform.rotation.eulerAngles.y, arObject.transform.rotation.eulerAngles.z);
                break;
            case EnumOrientations.XNegative:
                newRotation = arObject.transform.rotation.eulerAngles.x - rotationSpeed;
                arObject.transform.rotation = Quaternion.Euler(newRotation, arObject.transform.rotation.eulerAngles.y, arObject.transform.rotation.eulerAngles.z);
                break;
            case EnumOrientations.YPositive:
                newRotation = arObject.transform.rotation.eulerAngles.y + rotationSpeed;
                arObject.transform.rotation = Quaternion.Euler(arObject.transform.rotation.eulerAngles.x, newRotation, arObject.transform.rotation.eulerAngles.z);
                break;
            case EnumOrientations.YNegative:
                newRotation = arObject.transform.rotation.eulerAngles.y - rotationSpeed;
                arObject.transform.rotation = Quaternion.Euler(arObject.transform.rotation.eulerAngles.x, newRotation, arObject.transform.rotation.eulerAngles.z);
                break;
            case EnumOrientations.ZPositive:
                newRotation = arObject.transform.rotation.eulerAngles.z + rotationSpeed;
                arObject.transform.rotation = Quaternion.Euler(arObject.transform.rotation.eulerAngles.x, arObject.transform.rotation.eulerAngles.y, newRotation);
                break;
            case EnumOrientations.ZNegative:
                newRotation = arObject.transform.rotation.eulerAngles.z - rotationSpeed;
                arObject.transform.rotation = Quaternion.Euler(arObject.transform.rotation.eulerAngles.x, arObject.transform.rotation.eulerAngles.y, newRotation);
                break;
        }


    }
}
