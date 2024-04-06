using UnityEngine;

public class DecorationPlacer : MonoBehaviour
{
    public GameObject decoration; // Assign the prefab of the sprite you want to stamp in the Inspector
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
            if(decoration == null)
            {
                grabDecoration();
            }
            else
            {
                placeDecoration();
            }
        }
    }
    
    //load the decoration in the bowl into the decoration placer
    void grabDecoration()
    {
        Debug.Log("grabbing decoration");
        // Use a raycast to check if there is a decoration at the cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        
        //Debug Print   
        Debug.Log("trying to grab... Hit: " + hit.collider);
        Debug.Log("grabbed object Tag: " + hit.collider.gameObject.tag);
        

        // If there is a decoration at the cursor position, load it into the decoration placer
        if (hit.collider.gameObject.CompareTag("Decoration"))
        {
            decoration = hit.collider.gameObject;
        }
    }

    void placeDecoration()
    {
        // Check if the decoration placer is empty
        if (decoration == null)
        {
            return;
        }

        // Instantiate a new decoration at the cursor's position
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(decoration, new Vector3(cursorPosition.x, cursorPosition.y, 0), Quaternion.identity);

        // Set the decoration variable to null to indicate that the decoration placer is now empty
        decoration = null;
        
    }

    public void ChangeStampPrefab(GameObject newStampPrefab)
    {
        decoration = newStampPrefab;
    }
}