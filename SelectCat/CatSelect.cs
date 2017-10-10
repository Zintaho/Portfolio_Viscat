using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class CatSelect : MonoBehaviour
{
    //배경이미지 전환용
    public GameObject BackGround;
    public Sprite[] BackGrounds; // 배경이미지 전환용

    //고양이 선택용 오브젝트
    public GameObject thisCat;
    public GameObject FirstCat;
    public GameObject[] Icons;
    int curIndex = 0;
    /*전역변수로 스프라이트 목록을 만들기 보단, 
    동적 리스트로 Resources폴더에서 불러왔어야 하나,
    개발 당시에 지식이 부족하였음. 추후에 수정필요.*/
    public Sprite[] CatSprites; 

    //말풍선
    public GameObject textBalloon;
    public GameObject balloonPrefab;
    /*대사 목록 역시 동적 리스트로 만들었어야 한다.*/
    const int MAX_TEXT = 3;
    string[] Texts; //말풍선 대사집
    int offset = 0;
    bool isTextEnd = false;

    public AudioClip click;
    public AudioClip ok;

    enum Cats { White, Yellow, Black };

    void Start()
    {
        setBackGround(0);
        setVisible(FirstCat, false);
        setVisible(Icons, false);
        setVisible(thisCat, false);
        setTexts();
        makeBalloon();
    }

    void setBackGround(int k)
    {
        BackGround.GetComponent<SpriteRenderer>().sprite = BackGrounds[k];
    }
    void setVisible(GameObject obj, bool value)
    {
        obj.SetActive(value);
    }
    void setVisible(GameObject[] Objs, bool value)
    {
        foreach (GameObject obj in Objs)
        {
            obj.SetActive(value);
        }
    }

    void setTexts()
    {
        Texts = new string[MAX_TEXT];
        offset = 0;

        //텍스트 리소스는 따로 관리해야 하나, 개발 당시에 지식이 부족.
        Texts[0] = "안녕하세요!";
        Texts[1] = "날 키울거냥에 잘 오셨어요!";
        Texts[2] = "고양이를 골라주세요!";
    }

    void Update()
    {
        TouchEvent();
    }

    void test(string s)
    {
        PlayerPrefs.SetString("Name", s);
    }

    void makeBalloon()
    {
        balloonPrefab = Instantiate(textBalloon) as GameObject;
        balloonPrefab.transform.SetParent(GameObject.Find("Canvas").transform);
        balloonPrefab.transform.localScale = new Vector3(1, 1, 1);
        var tempPosition = balloonPrefab.transform.localPosition;
        balloonPrefab.transform.localPosition = new Vector3(tempPosition.x, tempPosition.y, 0);
        balloonPrefab.transform.FindChild("Text").GetComponent<Text>().text = Texts[offset++];
    }

    void SpriteChange(int k)
    {
        FirstCat.GetComponent<SpriteRenderer>().sprite = CatSprites[k];
    }

    public void LeftClick()
    {
        int len = CatSprites.Length;
        if (curIndex > 0 && curIndex <= len - 1)
        {
            SpriteChange(--curIndex);
        }
        else if (curIndex == 0)
        {
            curIndex = len - 1;
            SpriteChange(curIndex);
        }
        AudioSource.PlayClipAtPoint(click, transform.position);
    }
    public void RightClick()
    {
        int len = CatSprites.Length;
        if (curIndex >= 0 && curIndex < len - 1)
        {
            SpriteChange(++curIndex);
        }
        else if (curIndex == len - 1)
        {
            curIndex = 0;
            SpriteChange(curIndex);
        }
        AudioSource.PlayClipAtPoint(click, transform.position);
    }
    public void confirmClick()
    {
        AudioSource.PlayClipAtPoint(ok, transform.position);
        foreach (Cats kitty in Enum.GetValues(typeof(Cats)))
        {
            if(Convert.ToInt32(kitty) == curIndex)
            {
                PlayerPrefs.SetString("Cat", kitty.ToString());
                Debug.Log(kitty.ToString());
                break;
            }
        }
        SceneManager.LoadScene("Main");
    }

    void TouchEvent()
    {
        /*Debug*/
        if (Input.GetMouseButtonUp(0))
        {
            if (offset < Texts.Length)
            {
                AudioSource.PlayClipAtPoint(click, transform.position);
                balloonPrefab.transform.FindChild("Text").GetComponent<Text>().text = Texts[offset++];
            }
            else
            {
                if (!isTextEnd)
                {
                    AudioSource.PlayClipAtPoint(ok, transform.position);
                    Destroy(balloonPrefab);

                    setBackGround(1);

                    setVisible(FirstCat, true);
                    setVisible(Icons, true);
                    setVisible(thisCat, true);

                    SpriteChange(curIndex);

                    isTextEnd = true;
                }
            }
}
