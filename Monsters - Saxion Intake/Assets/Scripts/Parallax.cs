using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startposX, startposY, height;
    public GameObject cam;
    public float parallaxEffect;

    private void Start()
    {
        startposX = transform.position.x;
        startposY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void FixedUpdate()
    {
        float distance = (cam.transform.position.x * parallaxEffect);
        float high = (cam.transform.position.y * parallaxEffect);
        float temp = (cam.transform.position.x * (1 - parallaxEffect));

        transform.position = new Vector3(startposX + distance, startposY + high, transform.position.z);
        
        if (temp > startposX + length)
        {
            startposX += length;
        }
        else if (temp < startposX - length)
        {
            startposX -= length;
        }
    }
}
