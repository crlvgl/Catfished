using UnityEngine;

public class DestroyBubbles : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == "Bubble")
        {
            Destroy(other.gameObject);
        }
    }
}