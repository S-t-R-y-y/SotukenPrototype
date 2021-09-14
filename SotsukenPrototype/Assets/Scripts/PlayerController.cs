using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 3.0f;
    public float JumpHeight = 5.0f;
    Rigidbody rb;
    bool JumpFlag = true;
    private Vector2 LastMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LastMousePosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        CharaMove();
        CharaDirection();
    }

    private void OnCollisionEnter(Collision collision)
    {
        JumpFlag = true;
    }

    private void CharaMove()
    {
        Vector3 force;

        if (Input.GetAxis("Horizontal") != 0.0f)
        {
            transform.position += Speed * transform.right * Input.GetAxis("Horizontal") * Time.deltaTime;
        }
        if (Input.GetAxis("Vertical") != 0.0f)
        {
            transform.position += Speed * transform.forward * Input.GetAxis("Vertical") * Time.deltaTime;
        }

        if (JumpFlag && Input.GetKey(KeyCode.Space))
        {
            force = new Vector3(0.0f, JumpHeight, 0.0f);
            rb.AddForce(force, ForceMode.Impulse);
            JumpFlag = false;
        }
    }

    private void CharaDirection()
    {
        Vector3 RotaAngle = new Vector3(0.0f, 0.0f, 0.0f);

        RotaAngle.y = (Input.mousePosition.x - LastMousePosition.x) / 2;

        this.transform.Rotate(RotaAngle);
        LastMousePosition = Input.mousePosition;
    }
}
