using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DisCal : MonoBehaviour
{

    public Transform cube2;
    // Start is called before the first frame update
    void Start()
    {
        float dis1 = (cube2.position - transform.position).magnitude;
        //magnitude:������ģ��
       // float dis2 = (cube2.position - transform.position).sqlMagnitude;
        //sqlMagnitude:����ģ����ƽ��
        print("cub1��cub2֮��ľ�����" + dis1);
       // print("cub1��cub2֮��ľ����ƽ����" + dis2);
       // float dis = Vector3.Distance(cube2.position, transform.position);
       // print("���������֮��ľ����ǣ�" + dis);
    }

    // Update is called once per frame
    void Update()
    {
        float dis1 = (cube2.position - transform.position).magnitude;
        print("cub1��cub2֮��ľ�����" + dis1);
    }
}
