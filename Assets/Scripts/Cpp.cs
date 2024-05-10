using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cpplayer : MonoBehaviour
{
    public static GameObject[] checkpoints;
    public int m = -1;
    
    public GameObject UIthang;
    public static Cpplayer Instance;
    public Vector3 position;
    public TopDownCarController carController;
    private Rigidbody2D rb;
    public TextMeshProUGUI tbthutuplayer;

    countdown cdt;
    int Sovong = 1;
    public static int[] Order ;
    public static GameObject[] OrderGameobject;
    public GameObject xe1;
    public GameObject xe2;
    public GameObject xe3;
    public GameObject xe4;
    public GameObject Player;
    int thutuplayer;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
       
    }
    void Start()
    {
        Sovong = PlayerPrefs.GetInt("sovong", 1);
       
        Order = new int[4] { -1, -1, -1, -1 };
        OrderGameobject = new GameObject[4] {xe1,xe2,xe3,xe4};
        carController = GetComponent<TopDownCarController>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (m == checkpoints.Length - 1 + (checkpoints.Length *(Sovong -1)) && collision.gameObject.tag=="cp")
        {
            carController.stop();

            if (this.gameObject.tag == "Player")
            {
                for (int u = 0; u < OrderGameobject.Length; u++)
                {
                    if (OrderGameobject[u] == Player)
                    {
                       thutuplayer = u + 1;
                        break;
                    }

                }
                cdt = gameObject.GetComponent<countdown>();
                cdt.Finish(); 
                UIthang.SetActive(true);
                tbthutuplayer.text = "Your Rank: " + thutuplayer;

            }

           



        }


        for (int i = 0; i < checkpoints.Length; i++)
        {
            if (collision.gameObject == checkpoints[i] && (m == i - 1 || (m == i - 1 + checkpoints.Length) || (m == i - 1 + checkpoints.Length*2)))
            {
                

                m ++;




                
                for (int u = 0; u < Order.Length; u++)
                {
                    if (OrderGameobject[u] == gameObject)
                    {
                        // Di chuyển các phần tử sau vị trí i lên trước 1 bước để xóa đi xe khỏi mảng
                        for (int j = u; j < Order.Length - 1; j++)
                        {
                            Order[j] = Order[j + 1];
                            OrderGameobject[j] = OrderGameobject[j + 1];
                        }
                        // Set phần tử cuối cùng là giá trị 'trống'
                        Order[Order.Length - 1] = -1;
                        OrderGameobject[Order.Length - 1] = null;
                        break;
                    }
                }

                // Chèn m mới và xe vào vị trí thích hợp
                for (int p = 0; p < Order.Length; p++)
                {
                    if (m > Order[p])
                    {
                        // Dịch chuyển các giá trị trong mảng để tạo khoảng trống cho giá trị mới
                        for (int j = Order.Length - 1; j > p; j--)
                        {
                            Order[j] = Order[j - 1];
                            OrderGameobject[j] = OrderGameobject[j - 1];
                        }

                        // Chèn giá trị mới vào vị trí tìm được
                        Order[p] = m;
                        OrderGameobject[p] = gameObject;
                        break; // thoát khỏi vòng lặp sau khi chèn thành công
                    }


                }
                break;
                }
            }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "trap")
        {
           
            //transform.position = position;
            



        }
    }
    public GameObject timxephiatruoc()
    {
        GameObject xedangtruoc = null;
        for (int u = 0; u < OrderGameobject.Length; u++)
        {
            if (OrderGameobject[u] == gameObject)
            {
                if (u == 0)
                {
                    xedangtruoc = OrderGameobject[OrderGameobject.Length-1];
                }
                else
                {
                    xedangtruoc = OrderGameobject[u - 1];
                    
                }
                break;
            }
            
        }
        return xedangtruoc;
    }

}
