using UnityEngine;

public class Picking : MonoBehaviour {
    public float MaxDistance = 10f;
    public bool InRange = false;

    public Health Health;
    public Shoot Shoot;
    public Flamethrower Flamethrower;

    private GameObject cam;

    void Awake() {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FirstAidKit")
        {
            var fak = other.gameObject.GetComponent<FirstAidKit>();

            float hp = fak.HP;
            int ammo = fak.Ammo;
            int fuel = fak.Fuel;

            if (hp != 0)
            {
                Health.HP += hp;
                Destroy(other.gameObject);
            }
            else if (ammo != 0)
            {
                Shoot.Ammo += ammo;
                Destroy(other.gameObject);
            }
            else
            {
                Flamethrower.Ammo += fuel;
                Destroy(other.gameObject);
            }
        }
    }
}
