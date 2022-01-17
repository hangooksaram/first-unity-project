using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    // 1. 초기화

    // 1-1. 게임 오브젝트 생성할 때, 최초 실행
    void Awake()
    {
        Debug.Log("플레이어 데이터가 준비되었습니다.");
    }

    // 1-2. 게임 오브젝트가 활성화 되었을 때
    void OnEnable()
    {
        Debug.Log("플레이어가 로그인 했습니다.");
    }

    // 1-3. 업데이트 영역으로 들어가기전 최초로 실행
    void Start()
    {
        Debug.Log("사냥 장비를 챙겼습니다.");
    }

    // 2. 물리영역
    // 2-1. 물리 연산 업데이트
    void FixedUpdate()
    {
        Debug.Log("이동~");
    }

    //3. 게임로직 (주기적으로 변동)
    //3-1. 게임로직 업데이트
    void Update()
    {
        Debug.Log("몬스터 사냥!!");
    }

    //3-2. 모든 업데이트 끝난후 실행
    void LateUpdate()
    {
        Debug.Log("경험치");
    }

    //3-3. 게임 오브젝트가 비활성화 되었을 때
    void OnDisable()
    {
        Debug.Log("플레이어가 로그아웃하였습니다.");
    }

    //4. 해체
    //4-1. 게임 오브젝트가 삭제될 때
    void OnDestory()
    {
        Debug.Log("플레이어 데이터를 해체했습니다.");
    }
}
