using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    public SpriteRenderer currentSprite;

    public void spriteChange(Sprite newSprite)
    {
        currentSprite.sprite = newSprite;
    }
}
