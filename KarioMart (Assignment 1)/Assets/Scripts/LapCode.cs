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
    public int laps = 3;
    private int privLaps;
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
        //Checking if i have gone through enough checkpoints to count it as a lap.
        if (checkpointNumber == checkpointsGoneThrough)
        {
            privLaps++;
            checkpointsGoneThrough = 0;
        }
//Increases my laps so that i can then later finish a level.
        if (privLaps >= laps)
        {
            lapFinishedText.SetActive(true);
            isFinished = true;
        }
        checkpointsText.text = checkpointsGoneThrough.ToString()+ "/" +checkpointNumber.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Simple checks for if i have collided with a checkpoint or my finish line.
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
        //A courountine to activate post processing, UI, slow time and to then change scene after 5 seconds.
        winScreen.SetActive(true);
        Time.timeScale = 0.2f;
        Time.fixedDeltaTime = 0.2f * 0.02f;
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 1f * 0.02f;
        SceneManager.LoadSceneAsync("MainMenu");
    }
    
    //Same as before, used to working with courountines so I used one here for when I wanted an easy function that could wait for me.
    //Could maybe have optimized it more but for such a small project its not worth the work compared to performance gain.
}
