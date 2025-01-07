using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInsert : MonoBehaviour
{
    public PanelmanagerScript panelM;

    public GameObject fixedCard;

    Rigidbody cardRg;

    public AudioSource myaudio;

    // Start is called before the first frame update
    void Start()
    {
        cardRg = GetComponent<Rigidbody>();

        // AudioSource가 할당되지 않았다면 경고
        if (myaudio == null)
        {
            Debug.LogWarning("AudioSource가 할당되지 않았습니다.");
        }

        fixedCard.SetActive(false);
        if (panelM == null)  // panelM이 할당되지 않았다면 경고 메시지 출력
        {
            Debug.LogWarning("PanelmanagerScript가 할당되지 않았습니다.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(cardRg != null)
        {
            cardRg.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("cardReader")) //카드가 카드리더기에 인식되면
        {

            Debug.Log("카드가 카드 리더기에 닿았습니다.");

            // 카드 리더기 소리 출력
            if (myaudio != null)
            {
                myaudio.Play();  // 카드 리더기 소리 재생
            }

            // 움직일 수 있는 카드 숨기기, 꽂힌 카드 표시
            this.gameObject.SetActive(false);
            fixedCard.SetActive(true);

            // 결제가 완료되었습니다 창 표시
            if (panelM != null)  // panelM이 null이 아닌지 확인
            {
                // 5초 뒤에 ShowOrderedPanel 메서드를 호출하도록 설정
                Invoke("ShowOrderedPanel", 5.0f);
            }

            //Debug.Log("안되나?");
            //// 움직일 수 있는 카드가 숨겨지고 꽂혀있는 카드가 표시.
            //this.gameObject.SetActive(false);
            //fixedCard.SetActive(true);
            //// 결제가 완료되었습니다 창 표시.
            //panelM.orderedPanel.SetActive(true);

        }
    }

    // 3초 후에 호출될 메서드
    void ShowOrderedPanel()
    {
        if (panelM != null && panelM.orderedPanel != null)  // panelM과 orderedPanel이 null이 아닌지 확인
        {
            panelM.orderedPanel.SetActive(true);  // orderedPanel을 활성화
            Debug.Log("5초 후에 패널이 표시되었습니다.");

        }
    }

    
}
