using System.Collections;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void DeathAction();

    public event DeathAction OnDeath;

    public float MovementSpeed = 1;

    private Camera theCam;

    public Rigidbody2D theRB;

    public SpriteRenderer sprite;

    public const float FORCED_CHANGE_TIME = 3f;

    public const float COOL_DOWN_TIME = 0.45f;

    private float availableTime = 0;

    private const float CAMERA_EDGE = 4.5f;

    private float forcedTimer = 0f;

    private SelectColor nextColor; 

    private SelectColor currentColor;

    public ColorSlider colorSlider;

    private void Start()
    {
        //At start collider layer is white
        nextColor = GetRandomColor();
        colorSlider.ResetTimer(nextColor);
        gameObject.layer = 11;
        sprite = GetComponent<SpriteRenderer>();
        theRB = GetComponent<Rigidbody2D>();
        theCam = Camera.main;
    }
    private void Update()
    {
        //ternary statement
        float vertMov = Input.GetAxisRaw("Vertical");

        if (transform.position.y >= CAMERA_EDGE)
        {
            if (Input.GetAxisRaw("Vertical") > 0) vertMov = 0f;
        }

        if (transform.position.y <= -CAMERA_EDGE)
        {
            if (Input.GetAxisRaw("Vertical") < 0) vertMov = 0f;
        }

        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), vertMov) * MovementSpeed;

        Vector3 mouse = Input.mousePosition;

        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        HandleChangeColor();

        //   if(Input.GetKeyDown(KeyCode.Space)) 
        //   {  
        //        n = Random.Range(0, 3);
        //       Debug.Log(n);
        //       if(n == 0)
        //       {
        //           sprite.color = Color.red;
        //           gameObject.layer = 10;
        //           gameObject.tag = "Red";
        //       }
        //       else if(n == 1)
        //       {
        //           sprite.color = Color.cyan;
        //           gameObject.layer = 9;
        //           gameObject.tag = "Cyan";
        //       }
        //       else if(n == 2)
        //       {
        //           sprite.color = Color.white;
        //           gameObject.layer = 8;
        //           gameObject.tag = "White";
        //       }
        //       //sprite.color = new Color(Random.Range(0f, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f), 1);
        //   }

    }
  
    private void ChangeColor()
    {
        Debug.Log("Changing color");
        switch (nextColor)
        {
            case SelectColor.White:
                sprite.color = Color.white;
                gameObject.layer = 8;
                gameObject.tag = "White";
                break;                                                                  

            case SelectColor.Cyan:
                sprite.color = Color.cyan;
                gameObject.layer = 9;
                gameObject.tag = "Cyan";
                break;

            case SelectColor.Red:
                sprite.color = Color.red;
                gameObject.layer = 10;
                gameObject.tag = "Red";
                break;
        }
        currentColor = nextColor;
        nextColor = GetRandomColor();
        colorSlider.ResetTimer(nextColor);
        forcedTimer = 0;
    }

    private SelectColor GetRandomColor() 
    {
        Array values = Enum.GetValues(typeof(SelectColor));
        SelectColor randomColor = (SelectColor)values.GetValue(UnityEngine.Random.Range(0, values.Length));

        while(randomColor == currentColor) 
        {
            randomColor = (SelectColor)values.GetValue(UnityEngine.Random.Range(0, values.Length));
        }

        return randomColor;
        
    }
       
    private void HandleChangeColor()
    {
        forcedTimer += Time.deltaTime;
        colorSlider.SetColorProgress(forcedTimer);
        if (forcedTimer >= FORCED_CHANGE_TIME)
        {
            ChangeColor();
        }

        if (Time.time > availableTime)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                FindObjectOfType<AudioManager>().Play("PlayerChangeColor");
                nextColor = SelectColor.White;
                ChangeColor();
                availableTime = Time.time + COOL_DOWN_TIME;
            }   

            else if(Input.GetKeyDown(KeyCode.K))
            {
                FindObjectOfType<AudioManager>().Play("PlayerChangeColor");
                nextColor = SelectColor.Cyan;
                ChangeColor();
                availableTime = Time.time + COOL_DOWN_TIME;
            }

            else if (Input.GetKeyDown(KeyCode.L))
            {
                FindObjectOfType<AudioManager>().Play("PlayerChangeColor");
                nextColor = SelectColor.Red;
                ChangeColor();
                availableTime = Time.time + COOL_DOWN_TIME;
            }

            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Red")
        {
            GameDeath();
            Destroy(this.gameObject);
            //FindObjectOfType<GameManager>().EndGame();

        }

        else if (collision.gameObject.tag == "White")
        {
            GameDeath();
            Destroy(this.gameObject);
            //FindObjectOfType<GameManager>().EndGame();
        }

        else if (collision.gameObject.tag == "Cyan")
        {

            GameDeath();
            Destroy(this.gameObject);
            //FindObjectOfType<GameManager>().EndGame();
        }
    }

    public SelectColor getColor()
    {
        return currentColor;
    }

    public void GameDeath()
    {
        Debug.Log("In game death");
        AudioManager.instance.Play("DeathSound");

        if (OnDeath != null)
        {
            OnDeath();
        }
    }

}
    
    
    
