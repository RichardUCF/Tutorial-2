using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public Text scoreText;
    public Text lifeText;
    public Text winText;
    //public Text loseText;
    //public GameObject Player;
    private int scoreValue = 0;
    private int lifeValue = 3;
   // ItemDatabase database;
     

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        scoreText.text = scoreValue.ToString();
        lifeText.text = lifeValue.ToString();
        SetscoreValue();
        SetlifeValue();
        winText.text = "";
        //loseText.text = "";
        //database = GameObject.FindWithTag("Player").GetComponent<ItemDatabase>();
        //Player.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector3(hozMovement * speed, vertMovement * speed));
         //SetwinText();
         //SetloseText();
         if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            scoreText.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            SetlifeValue();
            SetscoreValue();
        }
        if (collision.collider.tag == "Enemy")
        {
         //AdjustlifeValue(-1);
         lifeValue -= 1;
         lifeText.text = lifeValue.ToString();
         Destroy(collision.collider.gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector3(0, 3), ForceMode2D.Impulse);
            }
        }
    }
    void SetscoreValue ()
    {
       scoreText.text = "Count: " + scoreValue.ToString ();

       if (scoreValue >= 4)
       { 
        //SetwinText();
        winText.text = "You Win! Game created by Richard Brauckmuller";      
       }  
      // if (count >= 8)
       {
      //     winText.text = "You Win! Game created by Richard Brauckmuller";
       }
    }
    void SetlifeValue ()
    {
        lifeText.text = "Life: " + lifeValue.ToString ();
        //if (lifeValue == 0)
        if (lifeValue <= 0)
        {
        //winText.text enabled;
        //SetloseText();
        winText.text = "You lose!";
       //public GameObject Name = GameObject.Find("Player");
       //Player.enabled = true;
       //Destroy(Player.gameobject);
        }


    }
}