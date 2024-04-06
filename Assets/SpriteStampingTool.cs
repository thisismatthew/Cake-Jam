using UnityEngine;

public class SpriteStampingTool : MonoBehaviour
{
    public GameObject stampPrefab; // Assign the prefab of the sprite you want to stamp in the Inspector
    public float stampInterval = 0.1f; // Time interval between stamps to avoid overcrowding
    private float stampTimer;
    
    public AudioClip stampSound; // Assign the sound effect in the Inspector
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
        if(audioSource == null)
        {
            // If there is no AudioSource component attached, add one
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StampSpriteAtCursor();
        }
        
        if (stampTimer > 0)
        {
            stampTimer -= Time.deltaTime;
        }
    }

    void StampSpriteAtCursor()
    {
        if (stampTimer <= 0)
        {
            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position,
                cursorPosition - (Vector2)Camera.main.transform.position);
            Debug.Log("Hit: " + hit.collider);
            Debug.Log("Tag: " + hit.collider.gameObject.tag);
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Cake"))
            {
                Instantiate(stampPrefab, new Vector3(cursorPosition.x, cursorPosition.y, 0), Quaternion.identity);
                stampTimer = stampInterval; // Reset the timer
                // Play the stamp sound here
                if (stampSound != null)
                {
                    audioSource.PlayOneShot(stampSound);
                }
            }
        }
    }

    public void ChangeStampPrefab(GameObject newStampPrefab)
    {
        stampPrefab = newStampPrefab;
    }
}