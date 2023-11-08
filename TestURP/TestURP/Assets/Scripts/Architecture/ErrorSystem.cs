using System.Collections;
using UnityEngine;

using TMPro;


public class ErrorSystem: MonoBehaviour
{
    [SerializeField] private GameObject imageError;
    [SerializeField] private TMP_Text textError;
    [SerializeField] private float timeError;

    private EventBus bus;

    public void Setup(EventBus eventBus)
    {
        bus = eventBus;
        RegisterEvents();
        imageError.SetActive(false);
    }

    private void RegisterEvents()
    {
        bus.Subscribe<SignalErrorClick>(Error);
    }

    private void Error(SignalErrorClick signal)
    {
        imageError.SetActive(true);
        textError.text = "Wrong " + signal.Number;
        StartCoroutine(CoroutineError());
    }

    private IEnumerator CoroutineError() 
    {
        yield return new WaitForSeconds(timeError);
        imageError.SetActive(false);
    }


}
