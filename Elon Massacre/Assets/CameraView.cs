using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour {
    public GameObject Cam;

    bool firstPerson = true;

    void Start() {
        Change();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) {
            firstPerson ^= true;
            Change();
        }
    }

    void Change() {
        if (firstPerson) { SetFirst(); }
        else { SetThird(); }
    }


    void SetFirst() {
        Cam.transform.localPosition = new Vector3(3, 3.3f, -1);
    }

    void SetThird() {
        Cam.transform.localPosition = new Vector3(2.4f, 7.3f, -9.5f);
    }
}
