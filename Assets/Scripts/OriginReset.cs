using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginReset : MonoBehaviour
{
    private float textureUnitSizeX;

    private void Awake()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }
    private void Update()
    {
        if (transform.position.x > 14.4f)
        {
            transform.position = new Vector3(transform.position.x - textureUnitSizeX, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -15f)
        {
            transform.position = new Vector3(transform.position.x + textureUnitSizeX, transform.position.y, transform.position.z);
        }
    }
}
