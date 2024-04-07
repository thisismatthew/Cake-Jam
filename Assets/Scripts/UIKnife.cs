using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIKnife : MonoBehaviour
{
    private SpriteRenderer KnifeSprite;

    public float xMouseOffset, yMouseOffset;
    // Start is called before the first frame update
    void Start()
    {
        KnifeSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos += new Vector2(xMouseOffset, yMouseOffset);
        transform.position = pos;
        if (Input.GetMouseButtonDown(1))
        {
            KnifeSprite.DOFade(1, .2f);
        }
        if (Input.GetMouseButtonUp(1))
        {
            KnifeSprite.DOFade(0, .2f);
        }
    }
}
