using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player; // 참조할 게임오브젝트. 이 경우엔 Vehicle
    private Vector3 offset = new Vector3(0, 2.53f, 3.23f); // 오프셋 정의

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
