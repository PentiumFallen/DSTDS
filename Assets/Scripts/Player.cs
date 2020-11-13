using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public int hp;
    public int score = 0;
    public Text health_score;
    public FixedJoystick moveStick;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        health_score.text = "HP:" + hp + "\nScore:" + score;
        //hud.color = new Color(hud.color.r, hud.color.g, hud.color.b, 255);
        //if (hp <= 0)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}

        // WASD or Arrow keys
        //Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //moveVelocity = moveInput.normalized * speed;

        // Left Joystick
        //Vector2 moveInput = Vector2.up * moveStick.Vertical + Vector2.right * moveStick.Horizontal;
        moveVelocity = moveStick.Direction * speed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
