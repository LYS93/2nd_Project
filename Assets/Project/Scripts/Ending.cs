using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject canvas; // 투명도를 조절할 캔버스
    private CanvasGroup canvasGroup; // CanvasGroup 컴포넌트

    public float targetAlpha = 1f; // 목표 투명도 (0: 완전 투명, 1: 불투명)
    public float fadeSpeed = 1f; // 투명도가 변하는 속도
    private bool endswitch = false; // 상태를 트래킹할 변수

    private float timer = 0f; // 5초 유지 시간을 위한 타이머

    public GameObject printer;

    void Start()
    {
        // CanvasGroup 컴포넌트를 찾거나 추가합니다.
        canvasGroup = canvas.GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = canvas.AddComponent<CanvasGroup>();
        }

        // 초기 투명도를 설정 (완전 투명)
        canvasGroup.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // 'endswitch'가 true가 되면 투명도를 서서히 증가
        if (endswitch)
        {
            Destroy(printer);
            // 투명도를 점진적으로 변경 (Lerp 사용)
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, fadeSpeed * Time.deltaTime);

            // 목표 투명도에 도달하면 더 이상 변경하지 않음 (옵션)
            if (Mathf.Abs(canvasGroup.alpha - targetAlpha) < 0.01f)
            {
                canvasGroup.alpha = targetAlpha; // 정확하게 목표값에 맞추기
            }

            // 투명도가 1로 완전히 바뀐 후, 5초 대기
            if (canvasGroup.alpha >= 0.99f)
            {
                timer += Time.deltaTime;

                if (timer >= 5f)
                {
                    Destroy(this.gameObject); // 5초 후 오브젝트 삭제
                }
            }
        }
        else
        {
            // 'endswitch'가 false일 경우, 캔버스는 투명 상태로 유지
            canvasGroup.alpha = 0f;
        }

        // 이동 코드 (원래 제공된 코드)
        transform.Translate(0, Time.deltaTime * 0.5f, 0);

        // 특정 조건에서 endswitch를 true로 변경
        if (transform.position.y > 10 && !endswitch)
        {
            endswitch = true; // 조건이 맞으면 'endswitch'를 true로 설정
        }
    }
}
