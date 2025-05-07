using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform flappyGateSpawn;
    [SerializeField] private Transform stackGateSpawn;
    [SerializeField] private Transform topDownGateSpawn;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject MainCamera;

    void Start()
    {
        string spawnKey = PlayerPrefs.GetString("SpawnPointKey", ""); // PlayerController에서 키값을 받는 구조임임

        switch (spawnKey)
        {
            case "FlappyGateSpawn":
                player.transform.position = flappyGateSpawn.position;

                break;
            case "StackGateSpawn":
                player.transform.position = stackGateSpawn.position;
                
                break;
            case "TopDownGateSpawn":
                player.transform.position = topDownGateSpawn.position;
               
                break;
            default:
                Debug.Log("기본 위치에 스폰됩니다.");
                break;
        }
        PlayerPrefs.DeleteKey("SpawnPointKey"); // 재사용 방지
    }
}
