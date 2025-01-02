using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInsert : MonoBehaviour
{
    public PanelmanagerScript panelM;

    public GameObject fixedCard;

    // Start is called before the first frame update
    void Start()
    {
        fixedCard.SetActive(false);
        if (panelM == null)  // panelM이 할당되지 않았다면 경고 메시지 출력
        {
            Debug.LogWarning("PanelmanagerScript가 할당되지 않았습니다.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("cardReader")) //카드가 카드리더기에 인식되면
        {

            Debug.Log("카드가 카드 리더기에 닿았습니다.");

            // 움직일 수 있는 카드 숨기기, 꽂힌 카드 표시
            this.gameObject.SetActive(false);
            fixedCard.SetActive(true);

            // 결제가 완료되었습니다 창 표시
            if (panelM != null)  // panelM이 null이 아닌지 확인
            {
                panelM.orderedPanel.SetActive(true);
            }


            //Debug.Log("안되나?");
            //// 움직일 수 있는 카드가 숨겨지고 꽂혀있는 카드가 표시.
            //this.gameObject.SetActive(false);
            //fixedCard.SetActive(true);
            //// 결제가 완료되었습니다 창 표시.
            //panelM.orderedPanel.SetActive(true);
            
        }
    }
}
