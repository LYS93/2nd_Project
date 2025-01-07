using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Screen : MonoBehaviour
{
    public GameObject Screen;

    public AudioSource startAudio;

    public AudioSource howToPlayAudio;

    bool isScreenDestroyed = false;

    Coroutine destroyAndPlayCoroutine;  // 실행 중인 코루틴을 추적

    // Start is called before the first frame update
    void Start()
    {
        Invoke("startAudio_", 2.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.activeSelf && !isScreenDestroyed)
        {
            destroyAndPlayCoroutine = StartCoroutine(DestroyAndPlay());  // 화면 삭제 후 오디오 재생
        }
        if (Screen == null && isScreenDestroyed)
        {
            StopCoroutine(DestroyAndPlay());//스크린이 사라지면 코루틴 정지.
            isScreenDestroyed = false;
        }
    }

    void startAudio_() //시작전 로딩시간에 음성나오지 않도록 딜레이 시켜줌.
    {
        startAudio.Play();
    }

    // 화면을 파괴하고 10초 후에 오디오를 재생
    IEnumerator DestroyAndPlay()
    {
        isScreenDestroyed = true;
        yield return new WaitForSeconds(10f);  // 10초 기다리기
        Destroy(Screen);  // Screen을 파괴
        howToPlayAudio.Play();  // 그 후 howToPlayaudio 재생
        isScreenDestroyed = false;
    }

    // 다른 스크립트에서 호출하여 코루틴을 중단하고 오디오를 재생하도록 하는 메서드
    public void StopCoroutineAndPlayAudio()
    {
        if (destroyAndPlayCoroutine != null)
        {
            StopCoroutine(destroyAndPlayCoroutine);  // 실행 중인 코루틴을 중지
            destroyAndPlayCoroutine = null;  // 코루틴 변수 초기화
        }
        howToPlayAudio.Play();  // 즉시 howToPlayAudio를 재생
    }
}
