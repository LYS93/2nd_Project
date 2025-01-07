using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Con : MonoBehaviour
{
    private float delaytimer = 0f; // �����̼� ������

    AudioSource bgm; //�������.

    float targetVolume = 0.1f; // ��ǥ ���� ����ũ��.

    float decreaseSpeed = 1f; // ���� �پ��� �ӵ�.

    public AudioSource finishAudio; // ��������Ʈ.

    public AudioSource otherPlayAudio; // �ٸ� ü�� ���ҽ� ��Ʈ.

    private bool hasPlayedFinishAudio = false; // finishAudio�� �� ���� ����ǵ��� �ϴ� �÷���


    // Start is called before the first frame update
    void Start()
    {
        bgm = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (delaytimer >= 50.0f && !hasPlayedFinishAudio)
        {
            // 50�ʰ� ����ϰ� finishAudio�� ���� ������� �ʾҴٸ� ����
            finishAudio.Play();
            hasPlayedFinishAudio = true; // finishAudio�� ����Ǿ����� ǥ��
            Invoke("otherPlayAudio_", 6.5f); // 6.5�� �Ŀ� �ٸ� ������ ���
        }
        else if (delaytimer < 50.0f)
        {
            delaytimer += Time.deltaTime;
            Debug.Log("Ÿ���� ��� ��������.");
            if (38.0f < delaytimer && delaytimer < 50.0f)
            {
                bgm.volume = Mathf.Lerp(bgm.volume, targetVolume, decreaseSpeed * Time.deltaTime);
            }
        }
    }

    void otherPlayAudio_()
    {
        otherPlayAudio.Play();
    }

}
