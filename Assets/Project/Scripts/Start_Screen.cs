using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Screen : MonoBehaviour
{
    public GameObject Screen;

    public AudioSource startAudio;

    public AudioSource howToPlayAudio;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("startAudio_", 2.0f);
        StartCoroutine(DestroyAndPlay());  // 화면 삭제 후 오디오 재생
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void startAudio_() //시작전 로딩시간에 음성나오지 않도록 딜레이 시켜줌.
    {
        startAudio.Play();
    }

    // 화면을 파괴하고 10초 후에 오디오를 재생
    IEnumerator DestroyAndPlay()
    {
        yield return new WaitForSeconds(10f);  // 10초 기다리기
        Destroy(Screen);  // Screen을 파괴
        howToPlayAudio.Play();  // 그 후 howToPlayaudio 재생
    }
}
