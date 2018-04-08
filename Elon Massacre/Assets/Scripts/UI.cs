using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public Health health;
    public Image healthImage;
    public Text healthText;
    public Sprite[] faces;

    public WeaponManager weaponManager;
    public Text ammoText;

    public Score score;
    public Text scoreText;

    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (health.HP < 0) { health.HP = 0; }

        if (health.HP == 100.0f)
        {
            healthImage.sprite = faces[0];
        }
        else if (health.HP > 75.0f)
        {
            healthImage.sprite = faces[1];
        }
        else if (health.HP > 50.0f)
        {
            healthImage.sprite = faces[2];
        }
        else if (health.HP > 25.0f)
        {
            healthImage.sprite = faces[3];
        }
        else if (health.HP <= 25.0f && health.HP > 0.0f)
        {
            healthImage.sprite = faces[4];
        }
        else if (health.HP <= 0.0f)
        {
            healthImage.sprite = faces[5];
        }

        healthText.text = "HP " + health.HP;

        if (weaponManager.blaster == null || weaponManager.flamethrower == null)
        {
            return;
        }

        if (weaponManager.useBlaster)
        {
            ammoText.text = "AMMO " + weaponManager.blaster.GetComponent<Shoot>().Ammo;
        }
        else
        {
            ammoText.text = "AMMO " + weaponManager.flamethrower.GetComponent<Flamethrower>().Ammo;
        }

        scoreText.text = "SCORE " + score.Killed;
    }
}
