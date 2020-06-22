﻿

using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    Vector3 _initialPosition; //the underscore means that its a private variable
   
    [SerializeField] private float _launchPower = 500;
    
    private bool _birdWasLaunched;
    private float _timeSittingAround;

    private void Awake() {
        _initialPosition = transform.position; 

    }
    private void Update()
    {
        if (_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1) {

            _timeSittingAround += Time.deltaTime; 
        
        }

        if (transform.position.y > 10 || transform.position.x > 10 || transform.position.x < -10 || _timeSittingAround >=3) {
            string currentSceneName = SceneManager.GetActiveScene().name; //Which scence am i in right now
            SceneManager.LoadScene(currentSceneName);//Make sure I am always in that scene
        }

        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
    }


    private void OnMouseDown() {

        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true; 
    }

    private void OnMouseUp() {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);//takes a vector 
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunched = true;
        GetComponent<LineRenderer>().enabled = false;

    }

    private void OnMouseDrag() {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3 (newPosition.x,newPosition.y); 
        
    }
}
