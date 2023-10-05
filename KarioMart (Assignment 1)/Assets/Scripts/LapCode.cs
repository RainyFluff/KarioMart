using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LapCode : MonoBehaviour
{
    //A list to manage all the checkpoints making this code a bit modular for several levels
    public List<Collider> checkpoints;
    private int checkpointNumber;
    private int checkpointsGoneThrough;
    public Collider start;
    private bool isFinished = false;
    public TextMeshProUGUI checkpointsText;
    //Includes postprocessing and correct win text "Player1" "Player2"
    public GameObject winScreen;
    public GameObject lapFinishedText;
    // Start is called before the first frame update
    void Start()
    {
        checkpointNumber = checkpoints.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkpointNumber == checkpointsGoneThrough)
        {
            lapFinishedText.SetActive(true);
            isFinished = true;
        }
        checkpointsText.text = checkpointsGoneThrough.ToString()+ "/" +checkpointNumber.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Checkpoint")
        {
            checkpointsGoneThrough++;
        }

        if (other.tag == "Finish" && isFinished)
        {
            StartCoroutine(finish());
        }
    }

    IEnumerator finish()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0.2f;
        Time.fixedDeltaTime = 0.2f * 0.02f;
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 1f * 0.02f;
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
