using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// Background 클래스는 Unity의 MonoBehaviour를 상속받아 특정 오브젝트의 동작을 제어.
public class Background : MonoBehaviour
{
    // // Start is called before the first frame update
    // void Start()
    // {
    //     
    // }
    // 배경 오브젝트가 아래로 이동하는 속도를 제어하는 변수
    private float moveSpeed = 3f;
    
    // Update is called once per frame
    void Update()
    {
        // transform.position
        // 오브젝트의 현재 위치를 나타냅니다.
        // Vector3.down * moveSpeed * Time.deltaTime
        // 배경 오브젝트를 매 프레임마다 아래로 이동시킴
        // Vector3.down은 (0, -1, 0)(x,y,z)좌표를 의미하며, moveSpeed는 이동 속도,
        // Time.deltaTime은 프레임 간 경과 시간을 고려해 부드러운 이동을 보장 (즉 기기별 프레임 속도를 고려해서 프레임 속도를 일정하게 만들어줌)
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        
        if (transform.position.y < -10)
        {
            transform.position += new Vector3(0, 20f, 0);
        }
    }
}
