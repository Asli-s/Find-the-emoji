using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


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
        if(Instance != null)
        {
            Debug.LogError("already an instance created");
        }
        Instance = this;
        print("datapersManager awake");
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

        this.gameData = dataHandler.Load();

        if(this.gameData == null)
        {
            Debug.Log("no game to load, create new game");
            NewGame();
        }

        foreach(IDataPersistence dataPersistenceObject in dataPersistenceObjects)
        {
            dataPersistenceObject.LoadData( gameData);
        }

        Debug.Log("loaded coinnum" + gameData.coinNumber);
        Debug.Log("loaded position" + gameData.lastPos);
    }


    public void SaveGame()
    {
        foreach (IDataPersistence dataPers in dataPersistenceObjects)
        {
            dataPers.SaveData( gameData);
        }
        Debug.Log("saved coinnum" + gameData.coinNumber);
        Debug.Log("saved positon" + gameData.lastPos);


        dataHandler.Save(gameData);

    }


    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }


}
