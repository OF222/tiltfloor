using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

// scv�ɕۑ����邽�߂̃R�[�h
// SaveCsv�ɃA�^�b�`����
public class Csv1 : MonoBehaviour
{
    // System.IO
    private StreamWriter sw;
    // �t�@�C����
    private string file_name = "";
    // csv�ɋL��������
    [SerializeField] private string subject_name;
    [SerializeField] private string WASD;
    private string tmp;

    // Start is called before the first frame update
    void Start()
    {
        // �p�^�[�����̎擾
        file_name = "pattern1_" + subject_name + ".csv";

        // �V����csv�t�@�C�����쐬����{}�̒��̗v�f��csv�ɒǋL����
        sw = new StreamWriter(file_name, true, Encoding.GetEncoding("Shift_JIS"));

        // CSV1�s�ڂ̃J������ StreamWriter �I�u�W�F�N�g�ɏ�������
        string[] s1 = { "wasd", "deg", "1 / 0 (�傫��/������)" };

        // s1�̕�����z��̂��ׂĂ̗v�f���u,�v�ŘA������
        tmp = string.Join(",", s1);

        // s2�������csv�t�@�C���֏�������
        sw.WriteLine(tmp);
    }

    // Update is called once per frame
    void Update()
    {
        // �傫��(1)
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            tmp += ",1";
            sw.WriteLine(tmp);
        }
        // ������(0)
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            tmp += ",0";
            sw.WriteLine(tmp);
        }

        // Enter�L�[�������ꂽ��csv�ւ̏������݂��I������
        if (Input.GetKeyDown(KeyCode.Return))
        {
            sw.Close();
        }

        // ��]����
        if (Input.GetKeyDown(KeyCode.W))
        {
            WASD = "w";
            Debug.Log("change w");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            WASD = "a";
            Debug.Log("change a");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            WASD = "s";
            Debug.Log("change s");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            WASD = "d";
            Debug.Log("change d");
        }

    }

    public void SaveData(string deg)
    {
        string[] s1 = { WASD, deg };
        tmp = string.Join(",", s1);
    }
}
