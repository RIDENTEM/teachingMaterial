using System;
using UnityEngine.UI;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.IO;


public class teachScript : MonoBehaviour
{

    float currentSpeed;
    float maxSpeed = 10.0f;
    Rigidbody2D ourRB;

    // Use this for initialization
    void Start()
    {
        ourRB = GetComponent<Rigidbody2D>();
    }

    void getPlayerInput()
    {

        currentSpeed = CrossPlatformInputManager.GetAxis("Horizontal");

        ourRB.velocity = new Vector2(currentSpeed * maxSpeed, ourRB.velocity.y);
    } 

    // Update is called once per frame
    void Update()
    {
        getPlayerInput();

    }
}







//class Human
//{
//    int age;
//    public string interests;
//    float height;
//    float weight;



//    void goOutside()
//    {
//        //Do outside stuff
//    }

//    int howManyDonutsHaveIEaten()
//    {
//        return 99;
//    }

//    bool didIPooToday(bool didPoo)
//    {
//        return didPoo;
//    }

//}

//class Bear
//{
//    Human h = new Human();

//    void f()
//    {
//        h.interests = "";
//    }
//}