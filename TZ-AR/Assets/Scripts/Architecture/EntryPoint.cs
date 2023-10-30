using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private EventBus eventBus;
    private CheckboxManager checkboxManager;

    [SerializeField] private UILocator uiLocator;
    [SerializeField] private ErrorSystem errorSystem;
    private void Start()
    {
        Setup();
    }


    private void Setup() 
    {
        eventBus = new EventBus();
        uiLocator.Setup(eventBus);
        errorSystem.Setup(eventBus);
        checkboxManager = new CheckboxManager(eventBus);
    }

   
   
}
