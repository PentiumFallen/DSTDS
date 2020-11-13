using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public bool fall;

    private Vector2 originalPos;
    private Vector2 target;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        originalPos = rb.position;
        target = new Vector2(transform.rotation.x, transform.rotation.y);
        transform.rotation = Quaternion.identity;
        //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        while (!fall)
        {
            //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            rb.MovePosition(rb.position + target * speed * Time.fixedDeltaTime);

            if (Vector2.Distance(originalPos, rb.position) >= 5.0f)
            {
                fall = true;
            }
        }
    }
}