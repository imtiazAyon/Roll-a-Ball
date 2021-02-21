using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Text countText;
    public Text winText;
    private int count;
    private Rigidbody2D rb2d;
    int Flag = 0;
    public Canvas quitLevel1;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = " ";
        SetCountText();
        quitLevel1 = quitLevel1.GetComponent<Canvas>();
        quitLevel1.enabled = false;
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        if (Flag == 1)
        {
            StartCoroutine("Wait");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!(SceneManager.GetActiveScene().name.Equals("Game")) && Time.timeScale == 1)
            {
                quitLevel1.enabled = true;
                Time.timeScale = 0;
            }
            else
            {
                quitLevel1.enabled = false;
                Time.timeScale = 1;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
     if (other.gameObject.CompareTag("PickUp"))
       {
            
            other.gameObject.SetActive(false);

            count++;
            SetCountText();


        }
       }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Spikes"))
        {
            StartCoroutine("Lose");
        }
    }
    void SetCountText()
    {

        countText.text = "count: " + count.ToString();
        if (count >= 10)
        {
            Flag = 1;
        }

    }

    IEnumerator Wait()
    {
        winText.text = "You are winner!";
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Game");
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void NoPress()
    {
        quitLevel1.enabled = false;
        Time.timeScale = 1;
    }

    IEnumerator Lose()
    {
        winText.text = "GameOver!";
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Game");
    }


}
