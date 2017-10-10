using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject Room_0; //Main Room
    public GameObject Room_1; //Sub Room
    public GameObject[] Cats;
    public Sprite[] CatSprites; //고양이 스프라이트들(임시)
    public Canvas uiConfig;
    public Canvas uiShop;
    public Canvas uiInventory;
    public Canvas uiStatus;
    public Canvas uiNote;
    public GameObject buyBox;

    private int current_Room = 0;
    private bool isUiOn = false;
    private AudioSource clickSound;

    void Awake()
    {
        clickSound = GetComponent<AudioSource>();

        uiConfig.enabled = false;
        uiShop.enabled = false;
        uiInventory.enabled = false;
        uiNote.enabled = false;

        current_Room = 0;
        isUiOn = false;

    }

    void Update()
    {
        if ( (uiConfig.enabled | uiShop.enabled | uiNote.enabled) == false)
        {
            isUiOn = false;
        }
        else
        {
            isUiOn = true;
        }

        if (isUiOn)
        {
            Cats[0].GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            Cats[0].GetComponent<BoxCollider2D>().enabled    = true;
        }
    }

    public void btnRoomChange()
    {
        clickSound.Play();
        RoomChange();
    }
    public void btnConfig()
    {
        clickSound.Play();
        uiConfig.enabled = !uiConfig.enabled;
        uiNote.enabled = false;
        uiShop.enabled = false;
        uiStatus.enabled = false;
        uiInventory.enabled = false;

    }
    public void btnNote()
    {
        clickSound.Play();
        uiNote.enabled = !uiNote.enabled;
        uiConfig.enabled = false;
        uiShop.enabled = false;
        uiStatus.enabled = false;
        uiInventory.enabled = false;

    }
    public void btnShop()
    {
        clickSound.Play();
        uiShop.enabled = !uiShop.enabled;
        if(!uiShop.enabled)
        {
            buyBox.SetActive(false);
        }
        uiNote.enabled = false;
        uiConfig.enabled = false;
        uiStatus.enabled = false;
        uiInventory.enabled = false;
        uiShop.GetComponent<AudioSource>().Play();
    }
    public void btnInventory()
    {
        clickSound.Play();
        uiInventory.enabled = !uiInventory.enabled;
        uiStatus.enabled = uiInventory.enabled;
        uiNote.enabled = false;
        uiShop.enabled = false;
        uiConfig.enabled = false;
    }
    public void clickGameBtn()
    {
        clickSound.Play();
        SceneManager.LoadScene("SelectGame");
    }

    void RoomChange()
    {
        switch (current_Room)
        {
            case 0: // main room
                {
                    Room_0.transform.localPosition
                        = new Vector2(-720, 0);
                    Room_1.transform.localPosition
                        = new Vector2(0, 0);
                    current_Room = 1;
                    break;
                }

            case 1: // sub room
                {
                    Room_0.transform.localPosition
                        = new Vector2(0, 0);
                    Room_1.transform.localPosition
                        = new Vector2(-720, 0);
                    current_Room = 0;
                    break;
                }
            default:
                {
                    break;
                }

        }

    }
}
