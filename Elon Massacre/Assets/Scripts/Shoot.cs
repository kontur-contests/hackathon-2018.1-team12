using UnityEngine;

public class Shoot : MonoBehaviour {
    public int Ammo = 100;
    public float BulletSpeed = 600f;
    public float Reload = 0.5f;
    public float Damage = 10f;
    private float timer;
    public GameObject BulletPrefab;
    public Transform BulletSpawn;
    public Transform BulletDirection;

    void Awake() {
        timer = Reload;
    }
    
    void FixedUpdate() {
        if (Ammo <= 0)
        {
            Ammo = 0;
            return;
        }

        timer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse0) && timer >= Reload) {
            Spawn();
        }
    }

    void Spawn() {
        timer = 0f;

        --Ammo;

        var bullet = Instantiate(
            BulletPrefab,
            BulletSpawn.transform.position ,
            BulletSpawn.transform.rotation);

        bullet.transform.Rotate(0f, 0f, 90f);

        bullet.GetComponent<Bullet>().Damage = Damage;
        bullet.GetComponent<Rigidbody>().velocity = BulletDirection.forward * BulletSpeed;
        Destroy(bullet, 5f);
    }
}
