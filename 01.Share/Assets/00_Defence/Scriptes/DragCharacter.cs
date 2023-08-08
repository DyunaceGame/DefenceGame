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
            //RaycastHit2D hit = Physics2D.Raycast(mainCam.ViewportToWorldPoint(Input.mousePosition), transform.forward, Mathf.Infinity);
            RaycastHit2D hit = Physics2D.Raycast(mainCam.ScreenToWorldPoint(Input.mousePosition), transform.forward, Mathf.Infinity);

            // ����� �ִٸ� ����
            if (hit)
            {
                print("hit");

                if (hit.collider.CompareTag("Character"))
                {
                    Vector2 targetPos = mainCam.ScreenToViewportPoint(Input.mousePosition);

                    targetPos = new(Mathf.Clamp(targetPos.x, 0, 1), Mathf.Clamp(targetPos.y, 0, 1));

                    // ȭ�� ������ ������ �ȉ�.
                    // ������ ���� ���콺 ��ġ�� �������� ����
                    // 
                    
                    hit.transform.position = targetPos;
                }
            }
        }
    }
}