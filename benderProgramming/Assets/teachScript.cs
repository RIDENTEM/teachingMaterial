using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class teachScript : MonoBehaviour {

    float currentSpeed;
    float maxSpeed = 10.0f;
    Rigidbody2D ourRB;

	// Use this for initialization
	void Start () {
        ourRB = GetComponent<Rigidbody2D>();
	}
	

    class Human
    {
        int age;
        string interests;
        float height;
        float weight;

        void goOutside()
        {
            //Do outside stuff
        }

        int howManyDonutsHaveIEaten()
        {
            return 99;
        }

    }


    void getPlayerInput()
    {

        currentSpeed = CrossPlatformInputManager.GetAxis("Horizontal");

        ourRB.velocity = new Vector2(currentSpeed * maxSpeed, ourRB.velocity.y);
    }


    private void FixedUpdate()
    {

        getPlayerInput();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
