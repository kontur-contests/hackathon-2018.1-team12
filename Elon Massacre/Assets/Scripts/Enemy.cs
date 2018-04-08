using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    public Animator animator;

    public GameObject FAK;

    Transform elon;
    NavMeshAgent nav;

    public float Damage = 10f;
    public float Reload = 3f;
    private float timer;
    private bool isDead = false;

    public GameObject Health;
    public GameObject Ammo;
    public GameObject Fuel;

    void Awake() {
        elon = GameObject.FindGameObjectWithTag("Elon").transform;
        nav = GetComponent<NavMeshAgent>();
        timer = Reload;
    }

    void Update() {
        nav.SetDestination(elon.position);
        timer += Time.deltaTime;

        if (!isDead && GetComponent<Health>().HP <= 0) {
            isDead = true;
            GetComponent<NavMeshAgent>().speed = 0f;
            Destroy(gameObject, 0.5f);
            animator.SetTrigger("Death");
            elon.GetComponent<Score>().Killed++;

            if (1 == 1) {
                Invoke("SpawnHelp", 0.2f);
            }
        }

        animator.SetBool("Moving", nav.velocity.sqrMagnitude != 0.0f);
    }

    void OnCollisionStay(Collision other) { 
        if (other.gameObject.tag == "Elon") {
            if (timer >= Reload) {
                other.gameObject.GetComponent<Health>().HP -= Damage;
                timer = 0f;
                animator.SetTrigger("Hit");
            }
        }
    }

    void SpawnHelp()
    {
        var r = Random.Range(1, 4);

        if (r == 1) {
            Instantiate(Health, transform.position + Vector3.up * 2f, Quaternion.identity).GetComponent<FirstAidKit>().HP = 10;
        }
        else if (r == 2) {
            Instantiate(Ammo, transform.position + Vector3.up * 2f, Quaternion.identity).GetComponent<FirstAidKit>().Ammo = 10;
        }
        else {
            Instantiate(Fuel, transform.position + Vector3.up * 2f, Quaternion.identity).GetComponent<FirstAidKit>().Fuel = 10;
        }
    }
}
