using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Move : MonoBehaviour
{
    GameObject  Door;
    float speed;
    GameObject Camera_Pos;
    Camera Player_cam;

    Camera_Move camM;

    

    // Start is called before the first frame update
    void Start()
    {
        //시작하자마자 카메라의 위치값을 설정해보자.
        Camera_Pos = GameObject.Find("OVRCameraRig");
        Camera_Pos.transform.position = new Vector3(-1, 3.5f, -8);
        Camera_Pos.transform.eulerAngles = new Vector3(4.33f, 0, 0);

        Player_cam = GameObject.Find("OVRCameraRig").GetComponent<Camera>();


        //시작하자마자 열어보자.
        Door = GameObject.Find("door");
        Door.transform.position = Vector3.zero;
        //Door.transform.position = new Vector3(3.2f, 0, 0);

        camM = GameObject.Find("OVRCameraRig").GetComponent<Camera_Move>();
    }

    // Update is called once per frame
    void Update()
    {
        //if() 만약 발바닥 표시를 안눌렀다면 문이 천천히 열리고
        //else{} 문이 닫히도록 설정.
        if (camM.iscameramove == false)
        {
            if (Door.transform.position.x < 3.2f) // 3.2의 값 이전까지 문 열림.
            {
                speed += Time.deltaTime;
                Door.transform.Translate(speed * 0.3f * Time.deltaTime, 0, 0);
            }
        }

        //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        //{

        //}

        
            //StartCoroutine(close_Door(iscameramove));



    }

    //public IEnumerator close_Door(bool C_M)
    //{
    //    //if ()
    //    //{
    //    //    Door.transform.position = new Vector3(3.2f, 0, 0);
    //    //}
    //    yield return new WaitForSeconds(0.3f);
    //    if (C_M == true)
    //    {
    //        GameObject Door = GameObject.Find("door");
    //        float speed_ = 0;

    //        Door.transform.position = new Vector3(3.2f, 0, 0);
    //        Debug.Log("hmm..");
    //        if (Door.transform.position.x > 0)
    //        {
    //            speed_ += Time.deltaTime;
    //            Door.transform.Translate(speed * -0.3f * Time.deltaTime, 0, 0);
    //        }
    //    }
            
    //}
}
