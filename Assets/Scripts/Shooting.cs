using Assets.Scripts.Magazines;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    public FixedJoystick aimStick;

    private Transform playerPos;
    private Vector2 direction;
    private Vector2 aimingAt;
    private bool aiming;
    private IMagazine mag;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GetComponent<Transform>();
        mag = new QueueMagazine();
        mag.reload(Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        direction = aimStick.Direction;
        var flick = direction.magnitude;
        // Not holding aimstick or just fired
        if (flick == 0)
        {
            // Just fired
            if (aiming)
            {
                Color bullet = mag.shoot();
                if (!bullet.Equals(Color.clear))
                {
                    GameObject shot = Instantiate(projectile, playerPos.position, Quaternion.Euler(aimingAt.x, aimingAt.y, 0));
                    shot.GetComponent<SpriteRenderer>().material.SetColor("_Color", bullet);
                    shot.GetComponent<Projectile>().fall = false;
                }
                aimingAt = Vector2.zero;
                aiming = false;
            }
            else { /* Wasn't aiming */ }
        }
        else if (flick > 0 && flick < 0.2)
        {
            // Holding aimstick in dead zone (for cancelling shots)
            aiming = false;
        }
        else //(flick >= .2)
        {
            // Holding aimstick and actively aiming
            aiming = true;
            aimingAt = aimStick.Direction;
        }
    }
}
