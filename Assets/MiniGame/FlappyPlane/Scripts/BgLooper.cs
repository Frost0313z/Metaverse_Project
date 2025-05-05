using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5;
    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>(); // 모든 장애물 찾아서 배열에다가 넣어버렷
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++) // 하나하나 랜덤하게 배치한다.
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision) // Trigger는 부딪힌 충돌체에 대한 정보만 알림
    {
        Debug.Log("Triggerd: " + collision.name);

        if(collision.CompareTag("BackGround")) // 충돌 물체의 태그가 BackGround인 경우에는
        {
            float widthOFBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOFBgObject * numBgCount;
            collision.transform.position = pos;

            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if(obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}
