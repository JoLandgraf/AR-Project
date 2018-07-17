using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnerScript : MonoBehaviour {

    public Text myScore;
    public static spawnerScript instance;
    private GameObject Zombie;
    private Animator anim;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BeginGame()
    {
        SpawnProcess();
    }

    public void SpawnProcess()
    {
        InvokeRepeating("spawn", 2.5f, 1.5f);
    }

    void spawn()
    {
        GameObject x = (GameObject)Instantiate(Resources.Load("pointButtom"));
        x.transform.parent = transform;

        RectTransform position = x.GetComponent<RectTransform>();
        position.localPosition = new Vector3(0, 0, 0);
        position.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }

    public void addScore(int theScore)
    {
        myScore.text = (int.Parse(myScore.text) + theScore).ToString();
        removeKids();
    }

    private void removeKids()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    
    public void makeMove(string danceMove)
    {
        Zombie = GameObject.Find("UserDefinedTarget-1/warzombie_f_pedroso@Zombie Walk");
        anim = Zombie.GetComponent<Animator>();
        anim.SetTrigger(danceMove);
    }
}
