using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject canvas; // ������ ������ ĵ����
    private CanvasGroup canvasGroup; // CanvasGroup ������Ʈ

    public float targetAlpha = 1f; // ��ǥ ���� (0: ���� ����, 1: ������)
    public float fadeSpeed = 1f; // ������ ���ϴ� �ӵ�
    private bool endswitch = false; // ���¸� Ʈ��ŷ�� ����

    private float timer = 0f; // 5�� ���� �ð��� ���� Ÿ�̸�

    public GameObject printer;

    void Start()
    {
        // CanvasGroup ������Ʈ�� ã�ų� �߰��մϴ�.
        canvasGroup = canvas.GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = canvas.AddComponent<CanvasGroup>();
        }

        // �ʱ� ������ ���� (���� ����)
        canvasGroup.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // 'endswitch'�� true�� �Ǹ� ������ ������ ����
        if (endswitch)
        {
            Destroy(printer);
            // ������ ���������� ���� (Lerp ���)
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, fadeSpeed * Time.deltaTime);

            // ��ǥ ������ �����ϸ� �� �̻� �������� ���� (�ɼ�)
            if (Mathf.Abs(canvasGroup.alpha - targetAlpha) < 0.01f)
            {
                canvasGroup.alpha = targetAlpha; // ��Ȯ�ϰ� ��ǥ���� ���߱�
            }

            // ������ 1�� ������ �ٲ� ��, 5�� ���
            if (canvasGroup.alpha >= 0.99f)
            {
                timer += Time.deltaTime;

                if (timer >= 5f)
                {
                    Destroy(this.gameObject); // 5�� �� ������Ʈ ����
                }
            }
        }
        else
        {
            // 'endswitch'�� false�� ���, ĵ������ ���� ���·� ����
            canvasGroup.alpha = 0f;
        }

        // �̵� �ڵ� (���� ������ �ڵ�)
        transform.Translate(0, Time.deltaTime * 0.5f, 0);

        // Ư�� ���ǿ��� endswitch�� true�� ����
        if (transform.position.y > 10 && !endswitch)
        {
            endswitch = true; // ������ ������ 'endswitch'�� true�� ����
        }
    }
}
