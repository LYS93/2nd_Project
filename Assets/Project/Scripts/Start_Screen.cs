using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Screen : MonoBehaviour
{
    public GameObject Screen;

    public AudioSource startAudio;

    public AudioSource howToPlayAudio;

    bool isScreenDestroyed = false;

    Coroutine destroyAndPlayCoroutine;  // ���� ���� �ڷ�ƾ�� ����

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
            destroyAndPlayCoroutine = StartCoroutine(DestroyAndPlay());  // ȭ�� ���� �� ����� ���
        }
        if (Screen == null && isScreenDestroyed)
        {
            StopCoroutine(DestroyAndPlay());//��ũ���� ������� �ڷ�ƾ ����.
            isScreenDestroyed = false;
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
        isScreenDestroyed = false;
    }

    // �ٸ� ��ũ��Ʈ���� ȣ���Ͽ� �ڷ�ƾ�� �ߴ��ϰ� ������� ����ϵ��� �ϴ� �޼���
    public void StopCoroutineAndPlayAudio()
    {
        if (destroyAndPlayCoroutine != null)
        {
            StopCoroutine(destroyAndPlayCoroutine);  // ���� ���� �ڷ�ƾ�� ����
            destroyAndPlayCoroutine = null;  // �ڷ�ƾ ���� �ʱ�ȭ
        }
        howToPlayAudio.Play();  // ��� howToPlayAudio�� ���
    }
}
