using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlidableImage : GenericInteractable
{
    private float startXTransform;
    private float startXFinger;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void Pressed(Vector2 position)
    {
        startXTransform = transform.position.x;
        startXFinger = position.x;
    }

    public override void UpdateFingerPosition(Vector2 position)
    {
        transform.position = new Vector3(startXTransform + ((position.x - startXFinger)*1.5f), transform.position.y, transform.position.z);
    }

    public override void Released(Vector2 position)
    {
        startXTransform = 0;
        startXFinger = 0;
    }
}
