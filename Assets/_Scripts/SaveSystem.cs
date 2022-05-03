using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class  SaveSystem 
{
    public static void saveData( GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(gameManager);
        formatter.Serialize(stream, data);
        stream.Close();
        /*  using (FileStream stream = new FileStream(path,FileMode.Create))
          {

              // Save / Load code
          }*/
        /*try{
          // Some random save / load code here
        } catch (Exception e){
          // Some code you'd like to run if the "try" block fails
        }*/
    }
    public static PlayerData LoadData()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if(File.Exists(path))
        {
        BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data= formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
              Debug.LogError("No File found at" + path);
            BinaryFormatter formatter = new BinaryFormatter();
             path = Application.persistentDataPath + "/player.fun";
            FileStream stream = new FileStream(path, FileMode.Create);
            stream.Close();

            return null;
          
        }

    }
 
    // Start is called before the first frame update

}
