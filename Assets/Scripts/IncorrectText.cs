using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncorrectText : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] private string message;
    [SerializeField] private float fadeLength;
    private float fadeStepTime;
    private bool isFading;

    private void Awake()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
        text.color = Color.clear;
        isFading = false;
    }

    public void ShowMessage()
    {
        text.text = message;
        text.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-12f, 12f));
        text.color = Color.red;
        StartCoroutine(Fade(fadeLength));
    }

    private IEnumerator Fade(float seconds)
    {
        isFading = true;
        yield return new WaitForSeconds(seconds);
        isFading = false;
    }

    private void Update()
    {
        if (isFading)
        {
            
        }
    }
}
