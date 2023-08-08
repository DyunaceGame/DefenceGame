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

            // 대상이 있다면 실행
            if (hit)
            {
                if (hit.collider.CompareTag("Character"))
                {
                    // 입력받은 화면 위치를 디스플레이 위치로 변경
                    // 벡터 포지션 값을 0~1 까지의 값으로 변경함
                    Vector2 targetPos = mainCam.ScreenToViewportPoint(Input.mousePosition);

                    // 디스플레이 위치를 이동 가능한 지점까지 제한
                    targetPos = new(Mathf.Clamp(targetPos.x, 0, 1), Mathf.Clamp(targetPos.y, 0, 1));

                    // 변경된 위치를 월드 좌표로 계산
                    targetPos = mainCam.ViewportToWorldPoint(targetPos);

                    print(targetPos);

                    // 좌표 적용
                    hit.transform.position = targetPos;
                }
            }
        }
    }
}
