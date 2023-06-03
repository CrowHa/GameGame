using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitPoints : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] waitpoint;
    private int CurrentwaitpointIndex = 0;

    [SerializeField] private float speed = 2f;
    private void Update()
    {
        //Trong hàm Update, Vector2.Distance được sử dụng để tính khoảng cách giữa vị trí hiện tại của thanh và điểm đến hiện tại trong mảng waitpoint.
        //Nếu khoảng cách nhỏ hơn một ngưỡng (0.1f), CurrentwaitpointIndex được tăng lên một và kiểm tra xem đã đến điểm cuối cùng trong mảng waitpoint hay chưa.
        //Nếu đã đến điểm cuối cùng, CurrentwaitpointIndex sẽ được đặt lại về 0.
        if (Vector2.Distance(waitpoint[CurrentwaitpointIndex].transform.position, transform.position) < .1f)
        {
            CurrentwaitpointIndex++;
            if(CurrentwaitpointIndex >= waitpoint.Length)
            {
                CurrentwaitpointIndex = 0;
            }
        }
    //Sử dụng Vector2.MoveTowards để di chuyển thanh từ vị trí hiện tại đến điểm đến hiện tại trong mảng waitpoint.
    //Hàm này sẽ lerp từ vị trí hiện tại đến vị trí đích với tốc độ được tính dựa trên speed và Time.deltaTime.
        transform.position = Vector2.MoveTowards(transform.position, waitpoint[CurrentwaitpointIndex].transform.position, Time.deltaTime * speed);
        //current: Vị trí hiện tại của điểm cần di chuyển (Vector2).
        // target: Vị trí đích mà điểm cần di chuyển đến(Vector2).
        //maxDistanceDelta: Khoảng cách tối đa mà điểm có thể di chuyển trong một lần gọi
    }
}
