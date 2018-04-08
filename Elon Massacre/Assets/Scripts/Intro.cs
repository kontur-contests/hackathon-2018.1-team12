using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {
    public Sprite[] pages;

    private SpriteRenderer spriteRenderer;

    private int currentPage = 0;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = pages[currentPage];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ++currentPage;

            if (currentPage < pages.Length)
            {
                spriteRenderer.sprite = pages[currentPage];

                var position = transform.position;

                // Govnokod has come to
                if (currentPage == 2)
                {
                    position.z = 5.6f;
                }
                else if (currentPage == 3)
                {
                    position.z = -0.3f;
                }
                else
                {
                    position.z = 0.0f;
                }

                transform.position = position;
            }
            else
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
