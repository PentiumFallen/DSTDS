using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public GameObject effect;
    private Player player;
    private Transform playerPos;
    private Spawner spawner;
    private Color color;

    public Color Color { get => color; }

    // Start is called before the first frame update
    void Start()
    {
        color = GetComponent<SpriteRenderer>().color;
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Player lose health
            player.hp--;
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Projectile"))
        {
            Projectile projectile = collision.GetComponent<Projectile>();
            // Projectile is airborne
            if (!projectile.fall)
            {
                // Projectile matches enemy color
                if (projectile.GetComponent<SpriteRenderer>().material.color.Equals(color))
                {
                    // Enemy destroyed
                    player.score++;
                    Destroy(collision.gameObject);
                    Instantiate(effect, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                else { /* Nothing happens */ }
            }
            else { /* Nothing happens */ }
        }
    }
}