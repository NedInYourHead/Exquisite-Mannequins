using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginReset : MonoBehaviour
{
    [SerializeField] private float loopPosition;

    private void Awake()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
    }
    private void Update()
    {
        if (transform.position.x > loopPosition)
        {
            transform.position = new Vector3(transform.position.x - (loopPosition * 2), transform.position.y, transform.position.z);
        }

        if (transform.position.x < -loopPosition)
        {
            transform.position = new Vector3(transform.position.x + (loopPosition*2), transform.position.y, transform.position.z);
        }
    }
}
