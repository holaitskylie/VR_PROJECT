using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject moleContainer;
    private Mole[] moles;

    public float showMoletimer = 1.5f; //1.5�ʸ��� �δ����� ��Ÿ����
    public float timer = 60f;
    // Start is called before the first frame update
    void Start()
    {
        //������ �����ϸ� ��� �δ����� ���� ������ �����´�
        moles = moleContainer.GetComponentsInChildren<Mole>();
        Debug.Log("Number of moles : " + moles.Length);

        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer > 0f)
        {
            //showMoletimer�� 0�̸� �δ����� ��Ÿ����
            showMoletimer -= Time.deltaTime;
            if(showMoletimer < 0f)
            {
                //�δ��� ������ �� �������� �ϳ��� ��Ÿ��(Mole��ũ��Ʈ�� ShowMole�޼��� ȣ��)
                //�迭�� �ε����� Random.Range�� ����Ͽ� �����ϰ� ��Ÿ��
                moles[Random.Range(0, moles.Length)].ShowMole();

                //�δ��� Ÿ�̸Ӹ� �ٽ� �ʱ�ȭ
                showMoletimer = 1.5f;
            }
        }
    }
}
