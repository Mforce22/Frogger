using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{
    public Sprite[] Sprites;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndGame(int result)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Sprites[result];
        spriteRenderer.enabled = true;
    }
}
