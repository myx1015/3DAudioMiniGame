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
        //magnitude:向量的模长
       // float dis2 = (cube2.position - transform.position).sqlMagnitude;
        //sqlMagnitude:向量模长的平方
        print("cub1和cub2之间的距离是" + dis1);
       // print("cub1和cub2之间的距离的平方是" + dis2);
       // float dis = Vector3.Distance(cube2.position, transform.position);
       // print("正方体和球之间的距离是：" + dis);
    }

    // Update is called once per frame
    void Update()
    {
        float dis1 = (cube2.position - transform.position).magnitude;
        print("cub1和cub2之间的距离是" + dis1);
    }
}
