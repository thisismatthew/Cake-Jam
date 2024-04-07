using UnityEngine;

public class PlateDetector : MonoBehaviour
{
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Object entered the plate");
        // Make the object a child of the plate
        other.transform.SetParent(transform);

        // If the object has a Rigidbody2D, you might want to further ensure it doesn't move.
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll; // This freezes position and rotation.
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        Debug.Log("Object exited the plate");

        // When the object exits the plate, it's no longer a child of the plate
        other.transform.SetParent(null);

        // Reset the Rigidbody2D constraints to allow movement again
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints2D.None; // This unfreezes all constraints.
        }
    }
}