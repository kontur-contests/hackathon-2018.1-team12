using UnityEngine;

public class Bullet : MonoBehaviour {
    public GameObject bloodPrefab;

    public float Damage = 10f;

	void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<Health>().HP -= Damage;

            var blood = Instantiate(bloodPrefab);
            blood.transform.position = transform.position;
            blood.transform.rotation = Quaternion.Euler(0.0f, transform.rotation.eulerAngles.y + Random.Range(-60.0f, 60.0f), 0.0f);
            Destroy(blood, 0.5f);
        }

        if (other.gameObject.tag != "Elon") {
            Destroy(gameObject);
        }
    }
}
