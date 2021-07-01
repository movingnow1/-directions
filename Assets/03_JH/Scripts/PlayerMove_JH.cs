using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_JH : MonoBehaviour
{
    public float speed = 2;
    float rotX, rotY;
    bool space;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //좌 우
        float x = Input.GetAxis("Vertical");
        //앞 뒤
        float y = Input.GetAxis("Horizontal");
        //움직이는 방향 지정
        Vector3 dir = (transform.forward * x + transform.right * y) * speed * Time.deltaTime;
        //자신의 포지션에서 지정된 방향값으로 더하기
        transform.position += dir;

        //마우스 상하 좌우
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
        //각도
        rotX += mx;
        rotY += my;
        //화면 각도 셋팅
        transform.eulerAngles = new Vector3(-rotY, rotX, 0);


        //Space 바 클릭 시 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //bool space 가 true 면 카메라를 Player 위치에 
            if (space)
                Camera.main.transform.position = transform.position;
            //bool space 가 false 면 카메라를 Player 위치에서 y축으로 2 높은 지점에 놓기
            else
                Camera.main.transform.position = transform.position + new Vector3(0, 2, 0);
            //요거는 한 번 클릭했을 때 space의 true , false 를 전환하기 위함
            //예시 : space가 true일 때 !space하면 !true이므로 false가 되고
            //반대로하면 !false 면 true가 됨
            space = !space;
        }
    }
}
