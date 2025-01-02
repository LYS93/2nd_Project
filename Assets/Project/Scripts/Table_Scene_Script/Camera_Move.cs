using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{
    public OVRCameraRig Player_camera;

    Vector3 startcamPos = new Vector3(-1, 3.5f, -8);
    Vector3 startcamRot = new Vector3(4.33f, 0f, 0f);

    Vector3 MoveDirection = new Vector3(1.21f, 2.58f, -1.74f);
    Vector3 KioskDirection = new Vector3(1.86f, 2.3f, -1.3f); // �ʱ��� z��: -1.22f

    //float TransTime = 1.0f; //ī�޶� �ε巴�� ���ϱ�. => �ٸ���ũ��Ʈ�� �־���.
    //Coroutine myCoroutine; //ī�޶� �ε巴�� ���ϱ�. => �ٸ���ũ��Ʈ�� �־���.

    GameObject Door;
    float speed;

    public bool iscameramove = false; // �ڵ���
    bool iscameramoved = false; // Ű����ũ

    public ParticleSystem footParticle;

    // Start is called before the first frame update
    void Start()
    {
        Player_camera = GetComponent<OVRCameraRig>();

        Player_camera.transform.position = startcamPos; //ī�޶� �ʱ� ����(��ġ)
        Player_camera.transform.eulerAngles = startcamRot; //ī�޶� �ʱ� ����(����)

        Door = GameObject.Find("door");
        //Door.transform.position = Vector3.zero;
        //Door.transform.position = new Vector3(3.2f, 0, 0);

        footParticle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (iscameramove == true) //�ڵ���
        {
            Door.transform.position = new Vector3(3.2f, 0, 0);

            if (Door.transform.position.x > 0)
            {
                speed += Time.deltaTime;
                Door.transform.Translate(speed * -0.3f, 0, 0);
            }
            if (Door.transform.position.x <= 0)
            {
                Door.transform.position = Vector3.zero;// �ȸ���. �����ʿ�
            }
        }
        
    }

    public void Camera_move() // ������ ���� ���� ������ ���� �޼���
    {
        transform.position = MoveDirection;
        transform.eulerAngles = new Vector3(0, 90, 0);

        iscameramove = true;

        footParticle.Stop();


    }

    public void Camera_moveToKiosk() //Ű����ũ ���� �ٶ󺸴� �޼���
    {
        transform.position = KioskDirection;
        transform.eulerAngles = new Vector3(-1.5f, 1, 0.001f);

        //iscameramove = true;


    }

    //public IEnumerator changeToKiosk(Vector3 _addVector3, Vector3 _addAngles, float _duration) //Lerp�� �ε巴�� ȭ����ȯ.
    //{
    //    float time = 0;
    //    Vector3 start_position = transform.position;
    //    Vector3 end_position = _addVector3;
    //    Vector3 start_angle = transform.eulerAngles;
    //    Vector3 end_angle = _addAngles;

    //    if (iscameramoved == false)
    //    {
    //        iscameramoved = true;

    //        while (time < _duration)
    //        {
    //            transform.position = Vector3.Lerp(start_position, end_position, time / _duration);
    //            transform.eulerAngles = Vector3.Lerp(start_angle, end_angle, time / _duration);
    //            time += Time.deltaTime;
    //            yield return null;
    //        }
    //        transform.position = end_position;
    //        transform.eulerAngles = end_angle;

    //    }

    //    ///*myCoroutine = null;*/
    //}

}
