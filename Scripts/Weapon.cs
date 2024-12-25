using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 시작 후, 5초에 한번씩 Object를 삭제
        // 무한히 Create되는 Weapon Object 삭제를 위함
        Destroy(this.gameObject, 1f);
    }

    [SerializeField] private float moveSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}