using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetuperButtonAirPlane : MonoBehaviour, ISetup
{
    [SerializeField] private List<ButtonController> buttons;

    public void SetupEventBus(EventBus eventBus)
    {
        foreach (var but in buttons)
            but.Setup(eventBus);
    }
}
