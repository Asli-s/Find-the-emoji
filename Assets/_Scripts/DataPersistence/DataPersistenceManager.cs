using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Globalization;

public class DataPersistenceManager : MonoBehaviour

{

    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    // Start is called before the first frame update
    private GameData gameData;
    private FileDataHandler dataHandler;

    private List<IDataPersistence> dataPersistenceObjects;

    public static DataPersistenceManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("already an instance created");
            Destroy(Instance);
            //
        }
        Instance = this;
   
    }


    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }



    public void NewGame()
    {
        this.gameData = new GameData();

    }
    


    public void LoadGame()
    {

        this.gameData = dataHandler?.Load();

        if(this.gameData == null)
        {
            Debug.Log("no game to load, create new game");
            NewGame();
        }

        foreach(IDataPersistence dataPersistenceObject in dataPersistenceObjects ?? new List<IDataPersistence> { null })
        {
            dataPersistenceObject?.LoadData( gameData);
        }

        Debug.Log("loaded coinnum" + gameData.coinNumber);
        Debug.Log("loaded position" + gameData.lastPos);
        Debug.Log("loaded gamenum" + gameData.gameNumber);
        Debug.Log("loaded win" + gameData.win);
        Debug.Log("loaded lose" + gameData.lose);
        Debug.Log("loaded score 1" + " " + gameData.score1);
        Debug.Log("loaded score2" + " " + gameData.score2);
        Debug.Log("loaded score3" + " " + gameData.score3);

        Debug.Log("load  dateTime = " + gameData.savedTIme);


        print("load minutes" + gameData.
      minutesLeft);
        print("load sec" + gameData.
         secondsLeft);
        print("activecountd" + gameData.
         timerActive);


    }


    public void SaveGame()
    {
        foreach (IDataPersistence dataPers in dataPersistenceObjects)
        {
            dataPers.SaveData( gameData);
        }
        //Debug.Log("saved coinnum" + gameData.coinNumber);
       // Debug.Log("saved positon" + gameData.lastPos);
        Debug.Log("saved coinnum" + gameData.coinNumber);
        Debug.Log("saved position" + gameData.lastPos);
        Debug.Log("saved gamenum" + gameData.gameNumber);
        Debug.Log("saved win" + gameData.win);
        Debug.Log("saved lose" + gameData.lose);
        Debug.Log("score 1" + " "+ gameData.score1);
        Debug.Log("score2" + " " + gameData.score2);
        Debug.Log("score3" + " " + gameData.score3);

        Debug.Log("dateTime = " + gameData.savedTIme);
        print("save minutes"+ gameData.
            minutesLeft);
        print("save sec" + gameData.
         secondsLeft);
        print("activecountd" + gameData.
         timerActive);


        dataHandler.Save(gameData);

    }


    private void OnApplicationQuit()
    {
        SaveGame();
    }
    public void changeScene()
    {
        SaveGame();
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            print("game paused ");
            SaveGame();

            GameManager.Instance.minimizedApp = true;
        }
        else
        {
   
            DataPersistenceManager.Instance.LoadGame();
            GameManager.Instance.callLoadAgain();
         
            print("not paused anymore");


        }
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }


}
