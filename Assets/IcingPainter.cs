using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcingPainter : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    private Texture2D texture; // Texture to store the icing
    private Color[] icingColour; // Array to store the colour of the icing
    private bool isPainting = false; // Flag to check if the player is painting
    private SpriteRenderer _spriteRenderer; // Reference to the SpriteRenderer component

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Clone the texture to avoid modifying the original asset.
        texture = Instantiate(_spriteRenderer.sprite.texture);
        Rect spriteRect= _spriteRenderer.sprite.rect;
        _spriteRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        
        //EXAMPLE TEST set brush colour to red FOR EXAMPLE
        icingColour = new Color[] {Color.red, };
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPainting = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isPainting = false;
        }

        if (isPainting)
        {
            Vector2? pixelUV = GetMouseTexturePosition();
            if(pixelUV.HasValue)
            {
                Paint((Vector2)pixelUV);
            }
        }
    }
    
    void Paint(Vector2 pixelUV)
    {
        int x = (int)(pixelUV.x * texture.width);
        int y = (int)(pixelUV.y * texture.height);
        texture.SetPixels(x, y, 1, 1, icingColour);
        texture.Apply();
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    Vector2? GetMouseTexturePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider == GetComponent<Collider>())
        {
            Vector2 localPoint = hit.textureCoord;
            return localPoint;
        }
        return null;
    }
    

   
}
