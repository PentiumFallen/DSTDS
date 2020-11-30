using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public bool fall;
    public Vector2 target;

    private Vector2 originalPos;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        originalPos = rb.position;
        //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (!fall)
        {
            //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            rb.MovePosition(rb.position + target * speed * Time.deltaTime);

            if (Vector2.Distance(originalPos, rb.position) >= 7.5f)
            {
                fall = true;
            }
        }
    }
}