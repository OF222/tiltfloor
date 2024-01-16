using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltPattern2 : MonoBehaviour
{
    // SerialHandler�N���X
    public SerialHandler serialHandler;
    // csv�L�q
    GameObject csv2;
    Csv2 saveCsv;
    // Arduino�ɑ��M����f�[�^�@�`��:Xnum,num,num,num,num, (X==T/F num==move_ms num...num==act_UpDown)

    [SerializeField] GameObject gameObject;
    //[SerializeField] private char rotate_direction = 'w'; // ��]�̓������(w,a,s,d)�@�l�Ԃ̌����Ă��������ɂ��āA�O�ɌX���Ȃ�w
    private float change_deg = 0; // ���݂̊p�x�ړ���
    private float target_deg = 0; // �ڕW��]��
    private bool isMoving = false; // true �ŉ�]�`��

    void Start()
    {
        csv2 = GameObject.Find("csv");
        saveCsv = csv2.GetComponent<Csv2>();
    }

    // Update is called once per frame
    void Update()
    {
        // 2deg
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // ��ʓ��̌X�Ε`��
            setDeg(3.00f);
            // �V���A�����M
            serialHandler.Write("F45,1,-1,-1,1,");
            saveCsv.SaveData("2");
            Debug.Log("serial 2deg");

        }
        // 1deg
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            setDeg(3.00f);
            serialHandler.Write("F90,1,-1,-1,1,");
            saveCsv.SaveData("1");
            Debug.Log("serial 1deg");
        }
        // 0.5deg
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            setDeg(3.00f);
            serialHandler.Write("F120,1,-1,-1,1,");
            saveCsv.SaveData("0.5");
            Debug.Log("serial 0.5deg");
        }
        // 0deg
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            setDeg(3.00f);
            serialHandler.Write("F145,1,-1,-1,1,");
            saveCsv.SaveData("0");
            Debug.Log("serial 0deg");
        }
        // -0.5deg
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            setDeg(3.00f);
            serialHandler.Write("F160,1,-1,-1,1,");
            saveCsv.SaveData("-0.5");
            Debug.Log("serial -0.5deg");
        }
        // -1deg
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            setDeg(3.00f);
            serialHandler.Write("F180,1,-1,-1,1,");
            saveCsv.SaveData("-1");
            Debug.Log("serial -1deg");
        }
        // -2deg
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            setDeg(3.00f);
            serialHandler.Write("F215,1,-1,-1,1,");
            saveCsv.SaveData("-2");
            Debug.Log("serial -2deg");
        }

        // ��]����
        if (isMoving == true)
        {
            gameObject.transform.Rotate(-(target_deg * Time.deltaTime) , 0, 0);
            change_deg += target_deg * Time.deltaTime; // �p�x�X�V

            // �p�x�ɓ��B�������]�I��
            if (change_deg >= target_deg)
            {
                isMoving = false;
                change_deg = 0;
                target_deg = 0;
                Debug.Log("end rotate");
            }
        }

        // T�L�[�@��]���Z�b�g
        if (Input.GetKeyDown(KeyCode.T))
        {
            this.transform.rotation = Quaternion.Euler(3, 0, 0);
            serialHandler.Write("T");
        }

        /*
        // ��]����
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
        */

    }


    private void setDeg(float deg)
    {
        target_deg = deg;
        isMoving = true;
    }

    /*
    public char getWASD()
    {
        return this.rotate_direction;
    }
    */
}
