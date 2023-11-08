using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CustomButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] private Vector3 vectorMovement;
    private EventBus bus;


    private bool flagWork; 


    public void Setup(EventBus eventBus) 
    {
        bus = eventBus;
        flagWork = false;
    }
    
    

    public void OnPointerDown(PointerEventData eventData)
    {
         if (!flagWork)
             bus.Invoke(new SignalPressButtonMovement(vectorMovement));

         flagWork = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
           flagWork = false;
           bus.Invoke(new SignalUpButtonMovement());

    }
}
