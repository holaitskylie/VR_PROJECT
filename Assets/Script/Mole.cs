using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    //show & Hide Variables
    public float visibleYHeight = 2f; //�δ����� ���̴� Y��
    public float hiddenYHeight = - 1.6f; //�δ����� �Ⱥ��̴� Y��
    private Vector3 myNewXYZPosition;
    public float speed = 4f; //�δ����� �����̴� �ӵ�
    public float hideMoleTimer = 1.5f; //�δ��� ���� Ÿ�̸�

    private AudioSource audioSource;
    public AudioClip clip;

    private bool isHit = false;

    public float sinkSpeed = 10f; // �δ����� �������� �ӵ�
    private bool isSinking = false; // �δ����� �������� ������ ���θ� ��Ÿ���� ����


    void Awake()
    {
        HideMole();

        //���� ��ġ�� �����´�
        transform.localPosition = myNewXYZPosition;

        //����� �ҽ� ������Ʈ �Ҵ�
        audioSource = GetComponent<AudioSource>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //�δ����� myNewXYZPosition�� �����̰� �Ѵ�
        transform.localPosition = Vector3.Lerp(transform.localPosition, myNewXYZPosition,Time.deltaTime*speed);

        //timer ���� 0���� �۾����� �δ����� ����
        hideMoleTimer -= Time.deltaTime;
        if(hideMoleTimer < 0f)
        {
            HideMole();
        }

        if (isSinking)
        {
            // �δ����� �Ʒ��� �������� ���� �̵�
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x, hiddenYHeight, transform.localPosition.z), Time.deltaTime * sinkSpeed);
        }
    }

    public void HideMole()
    {
        // ���� ��ġ�� ������ ��ġ�� ����
        myNewXYZPosition = new Vector3(transform.localPosition.x,hiddenYHeight,transform.localPosition.z);
        
    }

    public void ShowMole()
    {
        
        //���� �����ǿ��� Y���� �����Ͽ� �δ����� ��Ÿ���� ��
        myNewXYZPosition = new Vector3(transform.localPosition.x, visibleYHeight, transform.localPosition.z);

        //�δ��� ���� Ÿ�̸Ӹ� �ٽ� �ʱ�ȭ
        hideMoleTimer = 1.5f;
    }

   
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hammer" && !isHit)
        {
            isHit = true;
            audioSource.PlayOneShot(clip);
           
            GameManager.instance.AddScore(1);

            // �δ����� �������� ���·� ����
            isSinking = true;
        }
    }

}
