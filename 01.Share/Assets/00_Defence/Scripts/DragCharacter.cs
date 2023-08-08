using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCharacter : MonoBehaviour
{
    Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mainCam.ScreenToWorldPoint(Input.mousePosition), transform.forward, Mathf.Infinity);

            // ����� �ִٸ� ����
            if (hit)
            {
                if (hit.collider.CompareTag("Character"))
                {
                    // �Է¹��� ȭ�� ��ġ�� ���÷��� ��ġ�� ����
                    // ���� ������ ���� 0~1 ������ ������ ������
                    Vector2 targetPos = mainCam.ScreenToViewportPoint(Input.mousePosition);

                    // ���÷��� ��ġ�� �̵� ������ �������� ����
                    targetPos = new(Mathf.Clamp(targetPos.x, 0, 1), Mathf.Clamp(targetPos.y, 0, 1));

                    // ����� ��ġ�� ���� ��ǥ�� ���
                    targetPos = mainCam.ViewportToWorldPoint(targetPos);

                    print(targetPos);

                    // ��ǥ ����
                    hit.transform.position = targetPos;
                }
            }
        }
    }
}