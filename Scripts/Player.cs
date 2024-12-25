using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
    //     
    // }
    // 움직임 속도
    // [SerializeField] 속성을 사용하면 Unity Inspector에서 private 변수인 moveSpeed를 수정할 수 있음
    [SerializeField] private float moveSpeed;

    [SerializeField] private GameObject weapon; // 발사할 무기를 나타내는 프리팹(GameObject).

    [SerializeField] private Transform shootTransform; // 무기가 발사될 위치를 나타내는 Transform.

    [SerializeField] private float shootingInterval = 0.05f; // 발사 간격(초 단위) 설정.

    private float lastShotTime = 0f; // 마지막 발사 시간을 저장하기 위한 변수.
    
    // Update is called once per frame
    void Update()
    {
        // 키보드 형 제어

        // Input.GetAxisRaw("Horizontal")
        // 사용자의 가로축 입력(WASD, 화살표 키 등)을 감지
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // // Input.GetAxisRaw("Vertical")
        // // 사용자의 세로축 입력(WASD, 화살표 키 등)을 감지
        // float verticalInput = Input.GetAxisRaw("Vertical");
        // // 입력 값에 따라 이동할 방향 벡터를 생성. Z축은 사용하지 않으므로 0으로 설정
        // Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);
        // // transform.position
        // // 현재 위치에 moveTo 방향으로 moveSpeed와 Time.deltaTime을 곱한 값을 더하여 플레이어를 이동
        // // Time.deltaTime은 프레임 간 경과 시간을 보정하여 이동 속도를 일정하게 유지
        // transform.position += moveTo * moveSpeed * Time.deltaTime;

        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        //
        //
        //     if (Input.GetKey(KeyCode.LeftArrow))
        //     {
        //         transform.position -= moveTo;
        //     }
        //     else if (Input.GetKey(KeyCode.RightArrow))
        //     {
        //         transform.position += moveTo;
        //     }
        //

        // 마우스형 제어
        // 디버깅 Log 
        // Debug.Log(Input.mousePosition);

        // 현재 마우스 커서의 화면 좌표를 월드 좌표로 변환.
        // Camera.main: 현재 활성화된 메인 카메라를 가져옴.
        // ScreenToWorldPoint: 화면 좌표(Screen Space)에서 월드 좌표(World Space)로 변환.
        // 즉, 사용자 별 화면 좌표를 Unity 메인 카메라 기준으로 변환
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Debug.Log(mousePos);

        // unity method
        // 최소 값, 최대 값 이상의 값은 나올 수 없게 하는 메서드
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);

        // position.y, z를 그대로 넣어줘서 움직이지 않게 고정 \
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);

        Shoot();
    }

    // Shoot 메서드는 발사 간격을 확인하고 무기를 생성.
    void Shoot()
    {
        // 현재 시간(Time.time)에서 마지막 발사 시간(lastShotTime)을 뺀 값이 발사 간격(shootingInterval)보다 큰 경우에만 발사.
        if (Time.time - lastShotTime > shootingInterval)
        {
            // Instantiate: 지정된 위치와 회전(Quaternion.identity)으로 weapon 프리팹을 생성.
            Instantiate(weapon, shootTransform.position, Quaternion.identity);

            // 마지막 발사 시간을 현재 시간으로 업데이트.
            lastShotTime = Time.time;
        }
    }
}