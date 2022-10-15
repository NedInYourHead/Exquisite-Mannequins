using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textToEdit;
    private TouchScreenKeyboard keyboard;

    public void OpenKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open(textToEdit.text, TouchScreenKeyboardType.Default, false, true, false, false, "type something...");
    }

    private void Update()
    {
        if (keyboard.active)
        {
            textToEdit.text = keyboard.text;
        }
        Debug.Log(TouchScreenKeyboard.area.yMin);
    }
}
