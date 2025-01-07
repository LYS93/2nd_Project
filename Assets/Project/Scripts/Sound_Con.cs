using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Con : MonoBehaviour
{
    private float delaytimer = 0f; // 나레이션 딜레이

    AudioSource bgm; //배경음악.

    float targetVolume = 0.1f; // 목표 사운드 볼륨크기.

    float decreaseSpeed = 1f; // 사운드 줄어드는 속도.

    public AudioSource finishAudio; // 마지막멘트.

    public AudioSource otherPlayAudio; // 다른 체험 원할시 멘트.

    private bool hasPlayedFinishAudio = false; // finishAudio가 한 번만 재생되도록 하는 플래그


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
            // 50초가 경과하고 finishAudio가 아직 재생되지 않았다면 실행
            finishAudio.Play();
            hasPlayedFinishAudio = true; // finishAudio가 재생되었음을 표시
            Invoke("otherPlayAudio_", 6.5f); // 6.5초 후에 다른 음성을 재생
        }
        else if (delaytimer < 50.0f)
        {
            delaytimer += Time.deltaTime;
            Debug.Log("타임이 계속 더해진다.");
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
