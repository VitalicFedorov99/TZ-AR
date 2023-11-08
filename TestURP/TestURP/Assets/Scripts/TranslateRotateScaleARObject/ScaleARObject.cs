using UnityEngine;

public class ScaleARObject
{
    private Vector3 vectorScale;
    private GameObject arObject;
    public void Setup(GameObject obj) 
    {
        arObject = obj;
    }

    public void DeleteObject() 
    {
        arObject = null;
    }


    public void Scale(bool scaleFlag)
    {
        if (arObject == null)
            return;

        vectorScale = arObject.transform.localScale;

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
        arObject.transform.localScale = vectorScale;
    }
}
