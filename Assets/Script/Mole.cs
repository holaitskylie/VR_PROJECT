using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    //show & Hide Variables
    public float visibleYHeight = 2f; //두더지가 보이는 Y값
    public float hiddenYHeight = - 1.6f; //두더지가 안보이는 Y값
    private Vector3 myNewXYZPosition;
    public float speed = 4f; //두더지가 움직이는 속도
    public float hideMoleTimer = 1.5f; //두더지 숨김 타이머

    private AudioSource audioSource;
    public AudioClip clip;

    private bool isHit = false;

    public float sinkSpeed = 10f; // 두더지가 내려가는 속도
    private bool isSinking = false; // 두더지가 내려가는 중인지 여부를 나타내는 변수


    void Awake()
    {
        HideMole();

        //현재 위치를 가져온다
        transform.localPosition = myNewXYZPosition;

        //오디오 소스 컴포넌트 할당
        audioSource = GetComponent<AudioSource>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //두더지가 myNewXYZPosition로 움직이게 한다
        transform.localPosition = Vector3.Lerp(transform.localPosition, myNewXYZPosition,Time.deltaTime*speed);

        //timer 값이 0보다 작아지면 두더지를 숨김
        hideMoleTimer -= Time.deltaTime;
        if(hideMoleTimer < 0f)
        {
            HideMole();
        }

        if (isSinking)
        {
            // 두더지를 아래로 내려가는 보간 이동
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x, hiddenYHeight, transform.localPosition.z), Time.deltaTime * sinkSpeed);
        }
    }

    public void HideMole()
    {
        // 현재 위치를 숨겨진 위치로 셋팅
        myNewXYZPosition = new Vector3(transform.localPosition.x,hiddenYHeight,transform.localPosition.z);
        
    }

    public void ShowMole()
    {
        
        //현재 포지션에서 Y값을 변경하여 두더지를 나타나게 함
        myNewXYZPosition = new Vector3(transform.localPosition.x, visibleYHeight, transform.localPosition.z);

        //두더지 숨김 타이머를 다시 초기화
        hideMoleTimer = 1.5f;
    }

   
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hammer" && !isHit)
        {
            isHit = true;
            audioSource.PlayOneShot(clip);
           
            GameManager.instance.AddScore(1);

            // 두더지를 내려가는 상태로 변경
            isSinking = true;
        }
    }

}
