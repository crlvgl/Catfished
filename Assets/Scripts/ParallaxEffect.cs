using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float parallaxEffect;
    public Camera cam;
    private float startpos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }

        startpos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = cam.transform.position;
        float distance = camPos.x * parallaxEffect;

        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
    }
}
