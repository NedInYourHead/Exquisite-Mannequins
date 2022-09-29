using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButtonColour : MonoBehaviour
{
    [SerializeField] private SpriteRenderer buttonToChange;
    [SerializeField] private Color colorToChangeTo;
    
    public void ChangeColor()
    {
        buttonToChange.color = colorToChangeTo;
    }
}
