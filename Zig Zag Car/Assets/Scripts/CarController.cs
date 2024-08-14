using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CarController : MonoBehaviour
{
    public float moveSpeed;
    bool faceLeft, firstTab;


    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameStarted)
        {
            Move();
            CheckInput();
        }

        if(transform.position.y <= -2)  // araba düþtüðünde platform dursun
        {
            GameManager.instance.GameOver();
        }

    }//Update

    void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }//Move

    void CheckInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ChangeDirection(); //ChangeDir
        }
    }//CheckInput

    void ChangeDirection()
    {
        if (faceLeft)
        {
            faceLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);    //y 90 olacak dediðimizde araba saða doðru yön deðiþtirecek
        }
        else
        {
            faceLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);     //y tekrar 0 olcak yani sola döncek
        }
    }


}
