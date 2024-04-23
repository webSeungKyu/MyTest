using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlap : MonoBehaviour
{

    // �˻��� ������ ��Ÿ���� ����. �ʱⰪ�� 4�� ������.
    float findRange = 4f;
    // � ���̾�� ��ü�� ã���� �����ϴ� ���̾� ����ũ ����.
    public LayerMask findLayer;
    // �־��� ���� ������ ã�� ��ü�� ������ �迭.
    public Collider2D[] findList;

    void Update()
    {
        // �� �����Ӹ��� ���� ����� ��ü�� ã�� �Լ� ȣ��
        FindNear();
    }

    void OnDrawGizmos()
    {
        // Gizmos ���� ����
        Gizmos.color = Color.blue;
        // ���� ��ü�� ��ġ�� �߽����� �ϰ�, �־��� �˻� ������ ���������� �ϴ� �� �׸���
        Gizmos.DrawWireSphere(transform.position, findRange);
    }

    void FindNear()
    {
        // �ӽ� ���� �ʱ�ȭ
        Transform temp = null;
        // �˻� ���� ����
        float findRange = this.findRange;
        // �־��� ��ġ �ֺ��� �ִ� ��� ��ü ã��
        findList = Physics2D.OverlapCircleAll(transform.position, this.findRange, findLayer);

        // ã�� �� ��ü�� ���� �ݺ�
        foreach (var i in findList)
        {
            // ���� ��ü�� ��ġ�� ã�� ��ü�� ��ġ ���
            Vector3 myPos = transform.position;
            Vector3 findPos = i.transform.position;
            float distance = Vector3.Distance(myPos, findPos);

            // ���� ã�� ��ü�� �� ������ �ӽ� ���� ������Ʈ
            if (distance <= findRange)
            {
                findRange = distance;
                temp = i.transform;
            }
        }
        // ���� ����� ��ġ�� ����� �α׷� ���
        if (temp != null)
            Debug.Log("���� ����� ��ġ : " + temp.position);
    }
}
