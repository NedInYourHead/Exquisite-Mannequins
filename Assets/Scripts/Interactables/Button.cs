using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : GenericInteractable
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private UnityEvent OnClick;

    protected override void Awake()
    {
        base.Awake();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;
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
            spriteRenderer.color = Color.white;
        }
    }

    public override void Released(Vector2 position)
    {
        spriteRenderer.color = Color.white;
        if (Physics2D.Raycast(position, Vector2.zero, Mathf.Infinity, 1 << 7))
        {
            OnClick.Invoke();
        }
    }

    public void DebugEvent()
    {
        Debug.Log("Button " + name + " Activated");
        StartCoroutine(Activate());
    }

    IEnumerator Activate()
    {
        spriteRenderer.color = Color.green;
        yield return new WaitForSeconds(3);
        spriteRenderer.color = Color.white;
    }
}
