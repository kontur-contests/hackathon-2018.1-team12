using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour {
    public float HP = 0f;
    public int Ammo = 0;
    public int Fuel = 0;

    void FixedUpdate() {
        gameObject.transform.Rotate(300f * Time.deltaTime, 300f * Time.deltaTime, 0f);
    }
}
