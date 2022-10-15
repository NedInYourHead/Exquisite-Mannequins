using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourPuzzle : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private int correctColourIndex;
    private Color[] colours = {Color.black, Color.red, Color.blue, Color.green};
    private int currentColour;
    private int CurrentColour
    {
        get { return currentColour; }
        set
        {
            currentColour = value;
            spriteRenderer.color = colours[value];
            Debug.Log(spriteRenderer.color.ToString());
        }
    }

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        CurrentColour = 0;
    }

    public void ChangeColour()
    {
        if (CurrentColour < 3)
        {
            CurrentColour += 1;
        }
        else
        {
            CurrentColour = 0;
        }
    }
}
