using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject centerOfMass;
    //[SerializeField] private float speed = 20.0f;
    [SerializeField] private float horsePower = 150000;
    [SerializeField] private float turnSpeed = 60.0f;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private TextMeshProUGUI rpmText;
    [SerializeField] private List<WheelCollider> allWheels;

    private float speed;
    private float rpm;

    private float horizontalInput;
    private float verticalInput;
    
    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Input클래스의 입력 메서드들은 생성자 및 Start()에서 호출 불가. 
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            // verticalInput을 받아서 전진
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            playerRb.AddRelativeForce(horsePower * verticalInput * Vector3.forward);

            // horizontalInput을 받아서 시계방향으로 회전
            transform.Rotate(horizontalInput * Time.deltaTime * turnSpeed * Vector3.up);

            // 3.6 for kph, 2.237 for mph
            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f);
            speedometerText.SetText("Speed: " + speed + " mph");

            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }
    }

    bool IsOnGround()
    {
        int wheelsOnGround = 0;
        foreach (var wheelCollider in allWheels)
        {
            if (wheelCollider.isGrounded) wheelsOnGround++;
        }
        if (wheelsOnGround == 4) return true;
        else return false;
    }
}
