using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : GenericInteractable
{
    private SpriteRenderer spriteRenderer;
    private Color deactivatedColour;
    [SerializeField] private Color activatedColour;
    [SerializeField] private bool changeColourOnActivation;
    [SerializeField] private UnityEvent OnClick;

    protected override void Awake()
    {
        base.Awake();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void Pressed(Vector2 position)
    {
        if (changeColourOnActivation)
        {
            deactivatedColour = spriteRenderer.color;
            spriteRenderer.color = activatedColour;
        }
    }

    public override void UpdateFingerPosition(Vector2 position)
    {
        if (Physics2D.Raycast(position, Vector2.zero, Mathf.Infinity, 1 << 7))
        {
            if (changeColourOnActivation)
            {
                spriteRenderer.color = activatedColour;
            }
        }
        else
        {
            if (changeColourOnActivation)
            {
                spriteRenderer.color = deactivatedColour;
            }
        }
    }

    public override void Released(Vector2 position)
    {
        if (changeColourOnActivation)
        {
            spriteRenderer.color = deactivatedColour;
        }
        if (Physics2D.Raycast(position, Vector2.zero, Mathf.Infinity, 1 << 7))
        {
            OnClick.Invoke();
        }
    }

    public void DebugEvent()
    {
        Debug.Log("Button " + name + " Activated");
    }
}
