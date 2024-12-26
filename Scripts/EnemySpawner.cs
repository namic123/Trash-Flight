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
        
        // 적의 이동 속도, 적 인덱스, 생성 횟수를 초기화.
        float moveSpeed = 5f; // 초기 적 이동 속도.
        int enemyIndex = 0; // 적 배열의 초기 인덱스.
        int spawnCount = 0; // 적 생성 횟수.
        
        // 무한 루프. 적을 일정 간격으로 생성
        while (true)
        {
            // X 좌표 배열에 따라 적을 생성.
            foreach (float posX in arrPosX)
            {
                SpawnEnemy(posX, enemyIndex, moveSpeed); // 적 스폰 메서드 호출.
            }

            spawnCount++; // 적 생성 횟수 증가.

            // 생성된 적이 10회마다 강화됨.
            if (spawnCount % 10 == 0)
            {
                enemyIndex++; // 적 배열에서 더 강한 적으로 변경.
                moveSpeed += 2; // 적 이동 속도 증가.
            }

            // 다음 스폰까지 대기.
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // 적을 스폰하는 메서드
    void SpawnEnemy(float posX, int index, float moveSpeed)
    {
        // 스폰 위치 계산. X 위치는 지정된 배열 값, Y와 Z는 현재 위치 사용.
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        // 20% 확률로 적 레벨을 1단계 높임.
        if (Random.Range(0, 5) == 0)
        {
            index += 1; // 적 레벨 증가.
        }

        // 적 인덱스가 배열 길이를 초과하지 않도록 제한.
        if (index >= enemies.Length)
        {
            index = enemies.Length - 1; // 마지막 인덱스로 고정.
        }

        // 지정된 적 프리팹을 스폰 위치에 생성.
        GameObject enemyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity);

        // 생성된 적의 `Enemy` 컴포넌트 가져오기.
        Enemy enemy = enemyObject.GetComponent<Enemy>();

        // 적의 이동 속도 설정.
        enemy.SetMoveSpeed(moveSpeed);
    }
    // Update is called once per frame
    void Update()
    {
    }
}