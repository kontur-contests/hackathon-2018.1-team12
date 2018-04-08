using UnityEngine;

public class Aim : MonoBehaviour
{
    public Transform From;
    public Transform Direction;
    public Vector2 Offset;
    private LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        var position = new Vector3(From.position.x + Offset.x, From.position.y + Offset.y, From.position.z);

        RaycastHit hit;
        if (Physics.Raycast(position, Direction.forward, out hit)) {
            if (hit.collider && hit.collider.gameObject.tag != "Bullet") {
                lr.SetPosition(1, new Vector3(0f, 0f, hit.distance));
            }
            else {
                lr.SetPosition(1, new Vector3(0f, 0f, 1000f));
            }
        }
    }
}
