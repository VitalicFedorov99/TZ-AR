using UnityEngine;

public class TranslateARObject 
{
    private float speedTranslate;
    private Vector3 vectorMove;
    private GameObject arObject;
 
    
    public TranslateARObject(float speed) 
    {
        speedTranslate = speed;
    }
    
    public void Setup(GameObject obj)
    {
        arObject = obj;
    }

    public void DeleteObject() 
    {
        arObject = null;
    }
    public void Translate(EnumOrientations orientation)
    {
        if (arObject == null)
            return;

        vectorMove = arObject.transform.position;
        switch (orientation)
        {
            case EnumOrientations.XPositive:
                vectorMove.x += speedTranslate;
                break;
            case EnumOrientations.XNegative:
                vectorMove.x -= speedTranslate;
                break;
            case EnumOrientations.YPositive:
                vectorMove.y += speedTranslate;
                break;
            case EnumOrientations.YNegative:
                vectorMove.y -= speedTranslate;
                break;
            case EnumOrientations.ZPositive:
                vectorMove.z += speedTranslate;
                break;
            case EnumOrientations.ZNegative:
                vectorMove.z -= speedTranslate;
                break;
        }
        arObject.transform.position = vectorMove;
    }
}
