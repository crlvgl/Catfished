using UnityEngine;

public class DestroyBubbles : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bubble")
        {
            Destroy(other.gameObject);
        }
    }
}