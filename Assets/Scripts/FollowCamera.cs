using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    float offsetX;
    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        return;

        offsetX = transform.position.x - target.position.x; // 카메라와 플레이어 사이의 값을 저장함, 거리 유지용
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        return;

        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX; // 플레이어와 카메라 플레이어 사이의 값 더하기
        transform.position = pos;
    }
}
