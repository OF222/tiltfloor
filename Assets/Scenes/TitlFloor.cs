using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ���ʃI�u�W�F�N�g����L�[����ɂ���ăI�C���[�ŉ�]������X�N���v�g
public class TiltFloor : MonoBehaviour
{
    // SerialHandler�N���X
    public SerialHandler serialHandler;
    // Arduino�ɑ��M����f�[�^�@�`��:Xnum,num,num,num,num, (X==T/F num==move_ms num...num==act_UpDown)

    [SerializeField] GameObject gameObject;
    [SerializeField] private char rotate_direction = 'w'; // switch case �ŉ�]�����𔻒肷��
    private float change_deg = 0;
    private float target_deg = 0;
    private bool isMoving = false; // true �ŉ�]�`��

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start() in Titlfloor");
    }

    // Update is called once per frame
    void Update()
    {
        // ��]�����@Inspector����Ȃ��ăL�[����ł��ς����
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

        // 1: 1deg
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // ��ʓ��̌X�Ε`��
            setDeg(3.00f);
            Debug.Log("serial 1deg");
            // �V���A�����M
            serialHandler.Write("F45,-1,1,1,-1,");

        }
        // 2deg
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            setDeg(3.00f);
            Debug.Log("serial 2deg");
            serialHandler.Write("F90,-1,1,1,-1,");
        }
        // 3deg
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            setDeg(3.00f);
            Debug.Log("serial 3deg");
            serialHandler.Write("F145,-1,1,1,-1,");
        }
        //4deg
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            setDeg(3.00f);
            Debug.Log("serial 4deg");
            serialHandler.Write("F180,-1,1,1,-1,");
        }
        //5deg
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            setDeg(3.00f);
            Debug.Log("serial 5deg");
            serialHandler.Write("F215,-1,1,1,-1,");
        }




        // T�L�[�@��]���Z�b�g
        if (Input.GetKeyDown(KeyCode.T))
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            Debug.Log("get T key");
            serialHandler.Write("T");
        }


        if (isMoving == true)
        {

            switch (rotate_direction)
            {
                case 'w': // �s�b�`�O
                    gameObject.transform.Rotate(target_deg * Time.deltaTime, 0, 0);
                    break;
                case 's': // �s�b�`��
                    gameObject.transform.Rotate(-(target_deg * Time.deltaTime), 0, 0);
                    break;
                case 'a': // ���[����
                    gameObject.transform.Rotate(0, 0, target_deg * Time.deltaTime);
                    break;
                case 'd': //���[���E
                    gameObject.transform.Rotate(0, 0, -(target_deg * Time.deltaTime));
                    break;

            }
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

    }

    private void setDeg(float deg)
    {
        target_deg = deg;
        isMoving = true;
    }

}
