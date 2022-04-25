using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventHandler : GenericSingleton<EventHandler>
{
    public event Action OnCompleteLevel;
    public event Action OnNextButton;
    public event Action <Vector3> OnIncorrectInput;

    public void InvokeOnCompleteLevel()
    {
        OnCompleteLevel?.Invoke();
    }
    public void InvokeOnNextButton()
    {
        OnNextButton?.Invoke();
    }
    public void InvokeOnIncorrectInput(Vector3 position)
    {
        OnIncorrectInput?.Invoke(position);
    }
}
