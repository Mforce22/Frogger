using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{
    //create a sprite array
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
        //get the sprite renderer
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        //set the sprite to the first sprite in the array
        spriteRenderer.sprite = Sprites[result];
        spriteRenderer.enabled = true;
    }
}
