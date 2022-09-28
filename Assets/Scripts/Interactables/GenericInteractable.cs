using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericInteractable : MonoBehaviour
{
    protected virtual void Awake()
    {
        gameObject.layer = 6;
    }

    public abstract void Pressed(Vector2 position);

    public abstract void UpdateFingerPosition(Vector2 position);

    public abstract void Released(Vector2 position);
}
