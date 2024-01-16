using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

// scvに保存するためのコード
// SaveCsvにアタッチする
public class Csv1 : MonoBehaviour
{
    // System.IO
    private StreamWriter sw;
    // ファイル名
    private string file_name = "";
    // csvに記入する情報
    [SerializeField] private string subject_name;
    [SerializeField] private string WASD;
    private string tmp;

    // Start is called before the first frame update
    void Start()
    {
        // パターン名の取得
        file_name = "pattern1_" + subject_name + ".csv";

        // 新しくcsvファイルを作成して{}の中の要素分csvに追記する
        sw = new StreamWriter(file_name, true, Encoding.GetEncoding("Shift_JIS"));

        // CSV1行目のカラムで StreamWriter オブジェクトに書き込む
        string[] s1 = { "wasd", "deg", "1 / 0 (大きい/小さい)" };

        // s1の文字列配列のすべての要素を「,」で連結する
        tmp = string.Join(",", s1);

        // s2文字列をcsvファイルへ書き込む
        sw.WriteLine(tmp);
    }

    // Update is called once per frame
    void Update()
    {
        // 大きい(1)
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            tmp += ",1";
            sw.WriteLine(tmp);
        }
        // 小さい(0)
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            tmp += ",0";
            sw.WriteLine(tmp);
        }

        // Enterキーが押されたらcsvへの書き込みを終了する
        if (Input.GetKeyDown(KeyCode.Return))
        {
            sw.Close();
        }

        // 回転方向
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
