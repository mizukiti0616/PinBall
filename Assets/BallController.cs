using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    public Text GameScoreText;

    private int score = 0;
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    private GameObject gameScoreText;


    // Use this for initialization
    void Start()
    {

        //シーン中のGameOverTextオブジェクトを取得

        this.GameScoreText = GetComponent<Text>();

        this.gameoverText = GameObject.Find("GameOverText");
        this.gameScoreText = GameObject.Find("GameScoreText");

        if(gameScoreText == null)
        {
            Debug.Log("nullだよ");
        }
        else
        {
            Debug.Log("Findで取得できたよ");
        }

        score = 0;
        SetScore();

        




    }

    void OnCollisionEnter(Collision collision)
    {
        string yourTag = collision.gameObject.tag;

        if (yourTag == "SmallCloudTag")
        {
            score += 50;
        }
        else if(yourTag == "SmallStarTag")
        {
            score += 100;
        }
        else if (yourTag == "LargeStarTag")
        {
            score += 200;
        }
        else if (yourTag == "LargeCloudTag")
        {
            score += 300;
        }
        else
        {
            score += 0;

        }


        SetScore();
    }

    void SetScore()
    {
        gameScoreText.GetComponent<Text>().text = string.Format("Score：{0}", score);
    }









        // Update is called once per frame
        void Update()
    {




        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }
   
   


}