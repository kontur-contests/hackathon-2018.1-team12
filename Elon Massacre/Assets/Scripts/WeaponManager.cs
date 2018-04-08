using UnityEngine;

public class WeaponManager : MonoBehaviour {
    public GameObject blaster;
    public GameObject flamethrower;

    public bool useBlaster = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            useBlaster = !useBlaster;
        }

        if (blaster == null || flamethrower == null)
        {
            return;
        }

        if (useBlaster)
        {
            blaster.SetActive(true);
            flamethrower.SetActive(false);
        }
        else
        {
            blaster.SetActive(false);
            flamethrower.SetActive(true);
        }
    }
}
