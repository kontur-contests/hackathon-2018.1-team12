using UnityEngine;

public abstract class Weapon : MonoBehaviour {
    public int Ammo = 100;
    public float Reload = 0.5f;
    public float Damage = 10f;
    private float timer;
    public GameObject BulletPrefab;
    public Transform BulletSpawn;
    public Transform BulletDirection;

    void Awake()
    {
        timer = Reload;
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse0) && timer >= Reload)
        {
            Spawn();
        }
    }

    public abstract void Spawn();
}
