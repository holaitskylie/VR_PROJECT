using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject moleContainer;
    private Mole[] moles;

    public float showMoletimer = 1.5f; //1.5초마다 두더지를 나타낸다
    public float timer = 60f;
    // Start is called before the first frame update
    void Start()
    {
        //게임이 시작하면 모든 두더지에 대한 참조를 가져온다
        moles = moleContainer.GetComponentsInChildren<Mole>();
        Debug.Log("Number of moles : " + moles.Length);

        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer > 0f)
        {
            //showMoletimer가 0이면 두더지가 나타난다
            showMoletimer -= Time.deltaTime;
            if(showMoletimer < 0f)
            {
                //두더지 참조값 중 랜덤으로 하나를 나타냄(Mole스크립트의 ShowMole메서드 호출)
                //배열의 인덱스를 Random.Range로 사용하여 랜덤하게 나타냄
                moles[Random.Range(0, moles.Length)].ShowMole();

                //두더지 타이머를 다시 초기화
                showMoletimer = 1.5f;
            }
        }
    }
}
