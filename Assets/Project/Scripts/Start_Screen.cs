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
        StartCoroutine(DestroyAndPlay());  // ȭ�� ���� �� ����� ���
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void startAudio_() //������ �ε��ð��� ���������� �ʵ��� ������ ������.
    {
        startAudio.Play();
    }

    // ȭ���� �ı��ϰ� 10�� �Ŀ� ������� ���
    IEnumerator DestroyAndPlay()
    {
        yield return new WaitForSeconds(10f);  // 10�� ��ٸ���
        Destroy(Screen);  // Screen�� �ı�
        howToPlayAudio.Play();  // �� �� howToPlayaudio ���
    }
}
