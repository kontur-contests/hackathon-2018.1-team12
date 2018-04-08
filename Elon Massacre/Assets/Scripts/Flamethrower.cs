using UnityEngine;

public class Flamethrower : MonoBehaviour {
    public GameObject bloodPrefab;

    public int Ammo = 100;
    public float Reload = 0.1f;
    public float Damage = 1f;
    private float timer;
    public GameObject BulletPrefab;
    public Transform BulletSpawn;
    public Transform BulletDirection;

    bool damaging = false;

    void Awake()
    {
        timer = Reload;
    }

    void FixedUpdate()
    {
        if (Ammo <= 0)
        {
            Ammo = 0;
            return;
        }

        timer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse0) && timer >= Reload)
        {
            damaging = true;
            Spawn();
        }
        else
        {
            damaging = false;
        }
    }

    void Spawn()
    {
        timer = 0f;
        --Ammo;
        Instantiate(BulletPrefab, gameObject.transform);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (damaging)
            {
                damaging = false;
                other.gameObject.GetComponent<Health>().HP -= Damage;

                var blood = Instantiate(bloodPrefab);
                blood.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 3.0f, other.transform.position.z);
                blood.transform.rotation = Quaternion.Euler(0.0f, 180.0f + other.transform.rotation.eulerAngles.y + Random.Range(-60.0f, 60.0f), 0.0f);
                Destroy(blood, 0.5f);
            }
        }
    }
}
