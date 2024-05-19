using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hieuungmap : MonoBehaviour
{
    public bool ishot;
    TopDownCarController carController;
    float tocdogoc;
    damageflash damageflash;
    void Start()
    {
        carController = GetComponent<TopDownCarController>();
        damageflash = GetComponentInChildren<damageflash>();

        tocdogoc = carController.maxSpeed;
        string Map = PlayerPrefs.GetString("MapSelect", "");


        if (Map == "map3")
        {
            StartCoroutine(DecreaseValueCoroutine());
        }
        else if (Map == "map4")
        {
            carController.driftFactor = 0.97f;
        }
    }
    IEnumerator DecreaseValueCoroutine()
    {
        while (true)
        {
            if (!ishot) // Nếu ishot là false
            {
                yield return new WaitForSeconds(5f); // Chờ 5 giây
                ishot = true; // Sau 5 giây, đặt ishot thành true

                // Kích hoạt giảm tốc độ sau khi ishot trở thành true
                StartCoroutine(DelayDecreaseSpeed());
            }
            yield return null; // chờ cho đến khi khung hình kế tiếp để kiểm tra lại điều kiện
        }
    }

    IEnumerator DelayDecreaseSpeed()
    {
        // Đợi cho đến khi ishot là true
        yield return new WaitUntil(() => ishot == true);

        // Nếu ishot là true, bắt đầu giảm tốc độ
        while (carController.maxSpeed > 12)
        {
            carController.maxSpeed--;
            yield return new WaitForSeconds(2f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "lammat")
        {
            carController.maxSpeed = tocdogoc;
            ishot = false;
            Debug.Log(ishot);
        }
    }
    void Update()
    {
        if (ishot)
        {
            
            damageflash.isflash = true;

        }
        else { damageflash.isflash = false; }
    }
}
