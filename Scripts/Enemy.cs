using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
// 적의 이동 속도를 설정하는 변수. 기본값은 10f
    [SerializeField]
    private float moveSpeed = 10f;
// 적이 화면에서 사라질 최소 Y 좌표. 기본값은 -7f
    [SerializeField]
    private float minY = -7f;
    // 적의 체력을 나타내는 변수. 기본값은 1f
    private float hp = 1f;
    // 이동 속도를 외부에서 설정할 수 있도록 하는 메서드
    // 적 단계별 속도 설정을 위함
    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // 적을 아래쪽으로 이동시킴 (Vector3.down은 (0, -1, 0)을 의미)
        // moveSpeed와 Time.deltaTime을 곱해 프레임 속도와 관계없이 일정한 속도로 이동
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        // 적이 화면 아래로 벗어났으면 제거함
        if (transform.position.y < minY)
        {
            Destroy(gameObject); // 현재 게임 오브젝트 삭제
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if ()
        // {
        // }
    }
}
