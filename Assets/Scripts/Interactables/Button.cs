using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : GenericInteractable
{
    private SpriteRenderer spriteRenderer;
    private Color currentColour;

    protected override void Awake()
    {
        base.Awake();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        currentColour = Color.white;
    }

    public override void Pressed(Vector2 position)
    {
        spriteRenderer.color = Color.red;
    }

    public override void UpdateFingerPosition(Vector2 position)
    {
        if (Physics2D.Raycast(position, Vector2.zero, Mathf.Infinity, 1 << 7))
        {
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.color = currentColour;
        }
    }

    public override void Released(Vector2 position)
    {
        if (Physics2D.Raycast(position, Vector2.zero, Mathf.Infinity, 1 << 7))
        {
            if (currentColour == Color.white)
            {
                currentColour = Color.green;
            }
            else if (currentColour == Color.green)
            {
                currentColour = Color.white;
            }
        }
        spriteRenderer.color = currentColour;
    }
}
