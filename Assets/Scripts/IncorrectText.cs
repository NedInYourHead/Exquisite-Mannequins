using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncorrectText : MonoBehaviour
{
    private TextMeshProUGUI text;
    //[SerializeField] private string message;
    [SerializeField] private float fadeLength;
    private float fadePerSecond;
    private bool isFading;
    private bool IsFading
    {
        get { return isFading; }
        set
        {
            isFading = value;
            if(value)
            {
                fadePerSecond = 1f / fadeLength;
                currentFade = 0f;
            }
        }
    }

    private float currentFade;

    private void Awake()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
        text.color = Color.clear;
        IsFading = false;
    }

    public void ShowMessage()
    {
        //text.text = message;
        text.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-12f, 12f));
        IsFading = true;
    }


    private void Update()
    {
        if (IsFading)
        {
            currentFade += fadePerSecond * Time.deltaTime;
            fadePerSecond += fadePerSecond * 2f * Time.deltaTime;
            text.color = Color.Lerp(Color.red, Color.clear, currentFade);
            if (currentFade >= 1)
            {
                IsFading = false;
            }
        }
    }
}
