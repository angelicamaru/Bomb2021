using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase.Database;
using Firebase.Extensions;

public class Win : MonoBehaviour
{
    public Text pointsText;
    public int scene;
    private int idUser;
    public int scoreF;

    DatabaseReference reference;


    public void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        LoadData();
    }
    public void SetUp(int score)
    {
        scoreF = score;
        gameObject.SetActive(true);
        Debug.Log("Gameover");
        pointsText.text = score.ToString() + " POINTS";
        saveScore();
    }

    public void RestartButton()
    {
        Debug.Log("Restart");
        LoadData();
        SceneManager.LoadScene(scene.ToString());
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadData()
    {
        scene = DataBetweenScenes.instance.GetEscenario();
        Debug.Log(scene);
        idUser = DataBetweenScenes.instance.GetUserId();
        Debug.Log(idUser);
    }

    public void saveScore()
    {

        LoadData();
        FirebaseDatabase.DefaultInstance
      .GetReference("usuarios").Child(idUser.ToString()).Child("score")
      .GetValueAsync().ContinueWithOnMainThread(task =>
      {
          if (task.IsFaulted)
          {
              // Handle the error...
              DataSnapshot snapshot = task.Result;
              Debug.Log("Error");
          }
          else if (task.IsCompleted)
          {
              DataSnapshot snapshot = task.Result;
              Debug.Log("Success " + snapshot.GetRawJsonValue());
              // Do something with snapshot...

              int score = int.Parse(snapshot.GetRawJsonValue());
              int scoreT = scoreF + score;
              reference.Child("usuarios").Child(idUser.ToString()).Child("score").SetValueAsync(scoreT);
              saveLevel(scoreT);
          }
      });


    }

    private void saveLevel(int scoreT)
    {
        if (scoreT >= 500 && scoreT < 1000)
        {
            reference.Child("usuarios").Child(idUser.ToString()).Child("nivel").SetValueAsync(2);
        }
        else if (scoreT >= 1000 && scoreT < 2000)
        {
            reference.Child("usuarios").Child(idUser.ToString()).Child("nivel").SetValueAsync(3);
        }
        else if (scoreT >= 2000 && scoreT < 3000)
        {
            reference.Child("usuarios").Child(idUser.ToString()).Child("nivel").SetValueAsync(4);
        }
        else if (scoreT >= 3000)
        {
            reference.Child("usuarios").Child(idUser.ToString()).Child("nivel").SetValueAsync(5);
        }

    }
}
    
