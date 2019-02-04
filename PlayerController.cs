using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;
    public Text livesText;

    private Rigidbody rb;
    private int count;
    private int score;
    private int lives;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        lives = 3;
        SetCountText();
        SetScoreText();
        SetLivesText();
        winText.text = "";
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
  
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetCountText();
            SetLivesText();
            SetScoreText();
        }
        if (other.gameObject.CompareTag("BPick Up"))
        {
            other.gameObject.SetActive(false);
            score = score - 1;
            lives = lives - 1;
            SetCountText();
            SetLivesText();
            SetScoreText();
        }
    }
    void SetLivesText ()
    {
        livesText.text = "Lives: " + lives.ToString();
    }
    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 12) 
{
    transform.position = new Vector3(72.993f, transform.position.y,3.0f); 
}
    }
    void SetScoreText ()
    {
        scoreText.text = "Score: " + score.ToString();
        if (count >= 24)
        {
            winText.text = "You Win!";
        }
        if ( lives == 0)
        {
            Destroy(this.gameObject);
            winText.text = "You Lost!";
        }
    }
}
