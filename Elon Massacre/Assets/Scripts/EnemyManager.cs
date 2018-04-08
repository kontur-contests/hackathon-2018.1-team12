using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    private Health Elon;

    public float RepeatRate = 30f;
    public float RepeatRateTop = 7f;
    public float StartDelay = 5f;
    public int StartAmount = 5;
    public Transform[] SpawnPoints;

    public GameObject Alien;
    public GameObject Crab;

    void Awake() {
        Elon = GameObject.FindGameObjectWithTag("Elon").GetComponent<Health>();
    }

	void Start () {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn() {
        yield return new WaitForSeconds(StartDelay);

        for (int i = (int)RepeatRate; i > RepeatRateTop && Elon.HP > 0; --i) {
            for (int j = 0; j < StartAmount && Elon.HP > 0; ++j) {
                var sp = Random.Range(0, SpawnPoints.Length);

                if (Random.Range(0.0f, 1.0f) < 0.1f)
                {
                    Instantiate(Crab, SpawnPoints[sp].transform);
                }
                else
                {
                    Instantiate(Alien, SpawnPoints[sp].transform);
                }

                yield return new WaitForSeconds(0.5f);
            }

            yield return new WaitForSeconds(i);
        }

        while (Elon.HP > 0) {
            for (int i = 0; i < StartAmount && Elon.HP > 0; ++i) {
                var sp = Random.Range(0, SpawnPoints.Length);

                if (Random.Range(0.0f, 1.0f) < 0.1f)
                {
                    Instantiate(Crab, SpawnPoints[sp].transform);
                }
                else
                {
                    Instantiate(Alien, SpawnPoints[sp].transform);
                }

                yield return new WaitForSeconds(0.5f);
            }

            yield return new WaitForSeconds(RepeatRateTop);
            ++StartAmount;
        }
    }
}
