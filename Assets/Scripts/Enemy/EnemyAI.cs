using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    // public const int totalColors = Enum.GetNames(typeof(EnemyColor)).Length;

    public float speed;

    private const float MAX_DISTANCE_PLAYER = 6.5f;

    public SelectColor myColor;

    private Transform targetTransform;

    private PlayerController targetController;

    int currentColor;


    void Start()
    {
        targetTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        targetController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (myColor != targetController.getColor()) 
        {
            if (Vector2.Distance(transform.position, targetTransform.position) < MAX_DISTANCE_PLAYER)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, speed * Time.deltaTime);
            }
        }


        //if ((target2.getColor() == 0 || target2.getColor() == 1) && myColor == SelectColor.White)
        //{
        //    if (Vector2.Distance(transform.position, target.position) < MAX_DISTANCE_PLAYER)
        //    {
        //        //If distance less than 7 and colour is red or cyan
        //        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //    }
        //}

        //if ((target2.getColor() == 1 || target2.getColor() == 2) && myColor == SelectColor.Red)
        //{
        //    if (Vector2.Distance(transform.position, target.position) < MAX_DISTANCE_PLAYER)
        //    {
        //        //If distance less than 7 and colour is red or cyan
        //        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //    }
        //}

        //if ((target2.getColor() == 0 || target2.getColor() == 2) && myColor == SelectColor.Cyan)
        //{
        //    if (Vector2.Distance(transform.position, target.position) < MAX_DISTANCE_PLAYER)
        //    {
        //        //If distance less than 7 and colour is red or cyan
        //        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //    }
        //}

    }

}
