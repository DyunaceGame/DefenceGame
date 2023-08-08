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

            // 대상이 있다면 실행
            if (hit)
            {
                print("hit");

                if (hit.collider.CompareTag("Character"))
                {
                    Vector2 targetPos = mainCam.ScreenToViewportPoint(Input.mousePosition);

                    targetPos = new(Mathf.Clamp(targetPos.x, 0, 1), Mathf.Clamp(targetPos.y, 0, 1));

                    // 화면 밖으로 나가면 안됌.
                    // 포지션 값은 마우스 위치를 기준으로 받음
                    // 
                    
                    hit.transform.position = targetPos;
                }
            }
        }
    }
}
