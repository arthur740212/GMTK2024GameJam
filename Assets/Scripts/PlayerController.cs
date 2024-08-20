using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 10.0f;
    // Start is called before the first frame update
    private Vector3 velocity;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //gravity
        if(velocity.y <= 9.8f)
            velocity.y += Physics.gravity.y * Time.deltaTime;

        controller.Move(velocity*Time.deltaTime);
        
        Movement();
    }

    private void Movement()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        //direction movement
        var direction = new Vector3( horizontal, 0, vertical).normalized;
        var move = direction * speed * Time.deltaTime;
        controller.Move(move);

        //rotation

        //var angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z);

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }

        // mouse rotation
        //var playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        //var point = Input.mousePosition - playerScreenPoint;
        //var angle = Mathf.Atan2(point.x, point.y) * Mathf.Rad2Deg;
        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z);
    }
}
