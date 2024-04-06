using UnityEngine;

public class IcingPainter : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Texture2D _texture;
    public Color[] brushColor;
    private bool _isPainting = false;

    
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        InitializeTexture();
        brushColor = new Color[] { Color.red }; // Default brush color is red
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isPainting = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isPainting = false;
        }

        if (_isPainting)
        {
            Paint();
        }
    }

    private void InitializeTexture()
    {
        Sprite originalSprite = _spriteRenderer.sprite;
        Texture2D originalTexture = originalSprite.texture;

        // Create a new Texture2D with the same dimensions and format
        _texture = new Texture2D(originalTexture.width, originalTexture.height, TextureFormat.RGBA32, false);
        _texture.filterMode = FilterMode.Point;
        _texture.wrapMode = TextureWrapMode.Clamp;

        // Manually copy pixels from the original texture
        Color[] pixels = originalTexture.GetPixels();
        _texture.SetPixels(pixels);
        _texture.Apply();

        // Create a new sprite with the new texture
        _spriteRenderer.sprite = Sprite.Create(_texture, originalSprite.rect, new Vector2(0.5f, 0.5f), originalSprite.pixelsPerUnit);
    }


    // ReSharper disable Unity.PerformanceAnalysis
    private void Paint()
    {
        Vector2 mousePos =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 localPos = _spriteRenderer.transform.InverseTransformPoint(mousePos);
        Vector2Int pixel = WorldToPixel(localPos);
        
        Debug.Log("mousepos" + mousePos);
        Debug.Log("localpos" + localPos);
        Debug.Log("pixel" + pixel);
        

        for (int x = pixel.x - 5; x < pixel.x + 5; x++)
        {
            for (int y = pixel.y - 5; y < pixel.y + 5; y++)
            {
                if (x >= 0 && x < _texture.width && y >= 0 && y < _texture.height)
                {
                    _texture.SetPixel(x, y, brushColor[0]);
                    Debug.Log("Painted" +"x="+ x + " y= " + y);
                }
            }
        }
        _texture.Apply();
    }

    private Vector2Int WorldToPixel(Vector2 localPoint)
    {
        Vector2Int pixel = new Vector2Int(
            Mathf.FloorToInt((localPoint.x + 0.5f) * _texture.width),
            Mathf.FloorToInt((localPoint.y + 0.5f) * _texture.height)
        );

        return pixel;
    }
}
