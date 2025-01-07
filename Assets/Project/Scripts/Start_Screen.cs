using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Screen : MonoBehaviour
{
    public GameObject Screen;

    public AudioSource startAudio;

    public AudioSource howToPlayAudio;

    bool isScreenDestroyed = false;


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
            StartCoroutine(DestroyAndPlay());  // ȭ�� ���� �� ����� ���
        }
        if (Screen == null)
        {
            StopCoroutine(DestroyAndPlay());//��ũ���� ������� �ڷ�ƾ ����.
        }
    }

    void startAudio_() //������ �ε��ð��� ���������� �ʵ��� ������ ������.
    {
        startAudio.Play();
    }

    // ȭ���� �ı��ϰ� 10�� �Ŀ� ������� ���
    IEnumerator DestroyAndPlay()
    {
        isScreenDestroyed = true;
        yield return new WaitForSeconds(10f);  // 10�� ��ٸ���
        Destroy(Screen);  // Screen�� �ı�
        howToPlayAudio.Play();  // �� �� howToPlayaudio ���
    }
}
