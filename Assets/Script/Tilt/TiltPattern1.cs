using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 平面オブジェクトを矢印キー操作によってオイラーで回転させるスクリプト
public class TiltFloor : MonoBehaviour
{
    // SerialHandlerクラス
    public SerialHandler serialHandler;
    // Arduinoに送信するデータ　形式:Xnum,num,num,num,num, (X==T/F num==move_ms num...num==act_UpDown)

    [SerializeField] GameObject gameObject;
    [SerializeField]  char rotate_direction = 'w'; // 回転の内部情報(w,a,s,d)　人間の向いてる方向を基準にして、前に傾くならw
    private float change_deg = 0; // 現在の角度移動量
    private float target_deg = 0; // 目標回転量
    private bool isMoving = false; // true で回転描画

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 1: 1deg
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 画面内の傾斜描画
            setDeg(3.00f);
            // シリアル送信
            serialHandler.Write("F45,-1,1,1,-1,");
            Debug.Log("serial 1deg");

        }
        // 2deg
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            setDeg(3.00f);
            serialHandler.Write("F90,-1,1,1,-1,");
            Debug.Log("serial 2deg");
        }
        // 2.5deg
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            setDeg(3.00f);
            serialHandler.Write("F120,-1,1,1,-1,");
            Debug.Log("serial 2.5deg");
        }
        // 3deg
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            setDeg(3.00f);
            serialHandler.Write("F145,-1,1,1,-1,");
            Debug.Log("serial 3deg");
        }
        // 3.5deg
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            setDeg(3.00f);
            serialHandler.Write("F160,-1,1,1,-1,");
            Debug.Log("serial 3.5deg");
        }
        //4deg
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            setDeg(3.00f);
            serialHandler.Write("F180,-1,1,1,-1,");
            Debug.Log("serial 4deg");
        }
        //5deg
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            setDeg(3.00f);
            serialHandler.Write("F215,-1,1,1,-1,");
            Debug.Log("serial 5deg");
        }

        // 回転動作
        if (isMoving == true)
        {
            
            /* 実験参加者が傾斜装置の上で回転したらよい
            switch (rotate_direction)
            {
                case 'w': // ピッチ前
                    gameObject.transform.Rotate( target_deg * Time.deltaTime, 0, 0);
                    break;
                case 's': // ピッチ後
                    gameObject.transform.Rotate( -(target_deg * Time.deltaTime), 0, 0);
                    break;
                case 'a': // ロール左
                    gameObject.transform.Rotate( 0, 0, target_deg * Time.deltaTime);
                    break;
                case 'd': //ロール右
                    gameObject.transform.Rotate( 0, 0, -(target_deg * Time.deltaTime));
                    break;

            }
            */
            gameObject.transform.Rotate( target_deg * Time.deltaTime, 0, 0);
            change_deg += target_deg * Time.deltaTime; // 角度更新

            // 角度に到達したら回転終了
            if (change_deg >= target_deg)
            {
                isMoving = false;
                change_deg = 0;
                target_deg = 0;
                Debug.Log("end rotate");
            }
        }

        // Tキー　回転リセット
        if (Input.GetKeyDown(KeyCode.T))
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            serialHandler.Write("T");
        }

        // 回転方向
        if (Input.GetKeyDown(KeyCode.W))
        {
            rotate_direction = 'w';
            Debug.Log("change w");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rotate_direction = 'a';
            Debug.Log("change a");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rotate_direction = 's';
            Debug.Log("change s");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rotate_direction = 'd';
            Debug.Log("change d");
        }

    }

    private void setDeg(float deg)
    {
        target_deg = deg;
        isMoving = true;
    }

    public char getWASD()
    {
        return this.rotate_direction;
    }
}
