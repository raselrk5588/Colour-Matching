using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 40f;
    public Rigidbody2D rb;
    public string currentColour;

    public Color Syk_Blue;
    public Color Yellow;
    public Color Red;
    public Color Blue;

    public SpriteRenderer sr;

    private void Start()
    {
        SetRandomColour();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * speed;
        }
        // if (Input.GetMouseButtonUp(0))
        // {
        //     rb.velocity = Vector2.zero * Time.deltaTime;
        // }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ColorChange")
        {
            SetRandomColour();
            Destroy(col.gameObject);
            return;
        }
        if (col.tag != currentColour)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void SetRandomColour()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:
                currentColour = "Sky_Blue";
                sr.color = Syk_Blue;
                break;
            case 1:
                currentColour = "yellow";
                sr.color = Yellow;
                break;
            case 2:
                currentColour = "red";
                sr.color = Red;
                break;
            case 3:
                currentColour = "blue";
                sr.color = Blue;
                break;
        }
    }
}
