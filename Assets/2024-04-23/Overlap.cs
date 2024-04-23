using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlap : MonoBehaviour
{

    // 검색할 범위를 나타내는 변수. 초기값은 4로 설정됨.
    float findRange = 4f;
    // 어떤 레이어에서 객체를 찾을지 결정하는 레이어 마스크 변수.
    public LayerMask findLayer;
    // 주어진 범위 내에서 찾은 객체를 저장할 배열.
    public Collider2D[] findList;

    void Update()
    {
        // 매 프레임마다 가장 가까운 객체를 찾는 함수 호출
        FindNear();
    }

    void OnDrawGizmos()
    {
        // Gizmos 색상 설정
        Gizmos.color = Color.blue;
        // 현재 객체의 위치를 중심으로 하고, 주어진 검색 범위를 반지름으로 하는 원 그리기
        Gizmos.DrawWireSphere(transform.position, findRange);
    }

    void FindNear()
    {
        // 임시 변수 초기화
        Transform temp = null;
        // 검색 범위 설정
        float findRange = this.findRange;
        // 주어진 위치 주변에 있는 모든 객체 찾기
        findList = Physics2D.OverlapCircleAll(transform.position, this.findRange, findLayer);

        // 찾은 각 객체에 대해 반복
        foreach (var i in findList)
        {
            // 현재 객체의 위치와 찾은 객체의 위치 계산
            Vector3 myPos = transform.position;
            Vector3 findPos = i.transform.position;
            float distance = Vector3.Distance(myPos, findPos);

            // 현재 찾은 객체가 더 가까우면 임시 변수 업데이트
            if (distance <= findRange)
            {
                findRange = distance;
                temp = i.transform;
            }
        }
        // 가장 가까운 위치를 디버그 로그로 출력
        if (temp != null)
            Debug.Log("가장 가까운 위치 : " + temp.position);
    }
}
