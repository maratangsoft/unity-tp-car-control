using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float turnSpeed = 60.0f;
    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Input클래스의 입력 메서드들은 생성자 및 Start()에서 호출 불가. 
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // verticalInput을 받아서 전진
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        // horizontalInput을 받아서 시계방향으로 회전
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput); 
    }
}
