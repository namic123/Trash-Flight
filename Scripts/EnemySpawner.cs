using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemySpawner : MonoBehaviour
{
    // 적 오브젝트 프리팹 배열. Inspector에서 설정함
    [SerializeField] private GameObject[] enemies;

    // 적이 생성될 X축 위치들. 배열로 관리해서 일정한 위치에 적을 스폰시킴
    private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f };

    // 적 생성 간격(초 단위). 기본값은 1.5초
    [SerializeField] private float spawnInterval = 1.5f;

    // 게임 시작 시 호출되는 메서드
    void Start()
    {
        // 적 생성 코루틴 시작
        StartEnemyRoutine();
    }

    // EnemyRoutine 코루틴 호출하는 메서드
    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine");
    }

    // 적 생성 루틴 코루틴
    IEnumerator EnemyRoutine()
    {
        // 초기 대기 시간 3초
        yield return new WaitForSeconds(3f);
        
        // 무한 루프. 적을 일정 간격으로 생성
        while (true)
        {
            // arrPosX에 정의된 X 좌표 각각에 대해 적을 스폰
            foreach (float posX in arrPosX)
            {
                // 적 배열 중 랜덤한 인덱스 선택
                int index = Random.Range(0, enemies.Length);
                
                // 선택된 X 위치와 적 인덱스로 적 스폰
                SpawnEnemy(posX, index);
            }

            // 다음 생성까지 spawnInterval만큼 대기
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // 적을 스폰하는 메서드
    void SpawnEnemy(float posX, int index)
    {
        // 스폰 위치 계산 (X, Y, Z)
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        // enemies 배열에서 index에 해당하는 적 오브젝트를 생성
        Instantiate(enemies[index], spawnPos, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
    }
}