using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    /*
     * アニマ関連
     */
    //インクの最大量(秒)
    [Range(0.0f, 100.0f)]
    public double MaxInkAmount = 2.0;

    //インクの回復測度(秒/秒)
    [Range(0.0f, 100.0f)]
    public double InkRecovery = 0.5;

    //インク残量(秒)
    private double _inkLeft;
    public double InkLeft
    {
        get { return _inkLeft; }
        set { _inkLeft = value; }
    }

    private double _inkUpdateAmount;

    /*
     * その他
     */
    //HP表示用
    public Text HPtext;
    //最大HP
    [Range(1f, 10f)]
    public int MaxHP = 2;
    //HP計算用
    public int HP;

    //無敵時間
    [Range(0.0f, 5.0f)]
    public double maxGodMode;
    //無敵時間計算用
    public double godModeCount;
    //無敵時間フラグ
    public int godModeFlag = 0;

    //スクリプト取得用
    public StageInputController InputController;

    void OnAnimaDrawingStart(Vector3 startPositionWorld, int color)
    {
        _inkUpdateAmount = -1;
    }

    void OnAnimaDrawingEnd(Vector3 endPositionWorld, bool cancel)
    {
        _inkUpdateAmount = InkRecovery;
    }

    // Start is called before the first frame update
    void Start()
    {
        //HP初期化
        HP = MaxHP;
        //HP表示初期化
        HPtext.text = "HP:" + HP;

        InkLeft = MaxInkAmount;
        _inkUpdateAmount = InkRecovery;

        InputController.OnAnimaDrawingStart += OnAnimaDrawingStart;
        InputController.OnAnimaDrawingEnd += OnAnimaDrawingEnd;
    }

    // Update is called once per frame
    void Update()
    {
        ////他スクリプトの情報を受け取る変数
        //double goalInFlag;

        ////オブジェクトがゴールエリアにあって無敵時間外なら
        //if (goalInFlag == 1 && godModeFlag == 0)
        //{
        //    //HP更新
        //    HP--;
        //    //HP表示更新
        //    HPtext.text = "HP:" + HP;
        //    //無敵時間開始
        //    godModeCount = 0;
        //    godModeFlag = 1;
        //}

        ////無敵時間の経過時間を計測
        ////無敵時間開始時にリセットされる
        //godModeCount += Time.deltaTime;

        ////無敵時間が終わったか判定
        //if (godModeCount >= maxGodMode)
        //{
        //    godModeFlag = 0;
        //}

        //インク残量を減らす・回復する
        InkLeft += _inkUpdateAmount * Time.deltaTime;
        if (InkLeft < 0.0f)
        {
            InkLeft = 0.0f;
        }
        else if (InkLeft > MaxInkAmount)
        {
            InkLeft = MaxInkAmount;
        }
    }
}
