using System;
using System.IO;
using System.IO.Compression;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class MyData
{
    public float speed;
    public float health;
    public string name;
    public int[] numbers;
}

public class Person
{
    public float speed;
    public float health;
    public string fullName;
    public string base64Texture;
}

public class Base64Tutorial : MonoBehaviour
{
    private static readonly int BumpMap = Shader.PropertyToID("_BumpMap");

    [MenuItem(("Tools/Task"))]
    private static void Task()
    {
        const string url = "https://dminsky.com/settings.zip";
        var outPath = Path.Combine(Application.persistentDataPath, "settings.zip");
        var outArchive = Path.Combine(Application.persistentDataPath, "outArchive");
        
        var uwr = UnityWebRequest.Get(url);
        uwr.downloadHandler = new DownloadHandlerFile(outPath);
        var asyncOp = uwr.SendWebRequest();
        asyncOp.completed += ao =>
        {
            if (uwr.isNetworkError || uwr.isHttpError) 
                Debug.Log("Some Error");
            else
            {
                Debug.Log("Complited");
                
                if (!Directory.Exists(outArchive)) 
                    Directory.CreateDirectory(outArchive);

                try
                {
                    ZipFile.ExtractToDirectory(outPath, outArchive);
                }
                catch (IOException ex)
                {
                    //Files already exist
                    Debug.Log(ex);
                }
                finally
                {
                    Debug.Log("Unpacking completed");
                }
                
                var temp = Directory.GetFiles(outArchive)[0].Split('/');
                var nameFileInArchive = temp[temp.Length - 1];

                var dataJson = File.ReadAllText(Path.Combine(outArchive, nameFileInArchive));
                var person = JsonUtility.FromJson<Person>(dataJson);

                var texBase64 = Convert.FromBase64String(person.base64Texture);
                var myTexture = new Texture2D(2,2);
                myTexture.LoadImage(texBase64);
                
                var material = GameObject.Find("Ground").GetComponent<MeshRenderer>().sharedMaterial;
                material.SetTexture(BumpMap, myTexture);
                material.EnableKeyword("_NORMALMAP");
                
                PersonController._speed = person.speed;
            }
        };
    }
    
    //[MenuItem("Tools/Convert to base64")]
    private static void ConvertToBase64()
    {
        var path = Application.persistentDataPath;
        Debug.Log(path);
        
        File.WriteAllBytes("MyDir/image.asset", new byte[] {10, 34, 24, 53});
        
        var brickBytes = File.ReadAllBytes("MyDir/image.asset");
        var brickBase64 = Convert.ToBase64String(brickBytes);
        File.WriteAllText("MyDir/brick_base64.txt", brickBase64);
        
        brickBase64 = File.ReadAllText("MyDir/brick_base64.txt");
        var image = Convert.FromBase64String(brickBase64);
        File.WriteAllBytes("MyDir/out_image.png", image);
        
        ZipFile.CreateFromDirectory("MyDir", "archive.zip");
        ZipFile.ExtractToDirectory("archive.zip", "MyDir");
        
        var textureData = File.ReadAllBytes("Assets/brick.jpg");
        var myTexture = new Texture2D(2,2);
        myTexture.LoadImage(textureData);
        
        var material = GameObject.Find("Ground").GetComponent<MeshRenderer>().sharedMaterial;
        material.SetTexture("_BumpMap", myTexture);
        material.EnableKeyword("_NORMALMAP");

        var myData = new MyData();
        myData.health = 10f;
        myData.speed = 5f;
        myData.name = "Petr";
        myData.numbers = new[] {1, 3, 4};
        
        var jsonData = JsonUtility.ToJson(myData);
        var newData = JsonUtility.FromJson<MyData>(jsonData);
        Debug.Log(newData.health);
        
        const string url = "https://dminsky.com/rock_normal.jpg";
        var outPath = Path.Combine(Application.persistentDataPath, "MyDir/rock_normal.jpg");
        
        var uwr = UnityWebRequest.Get(url);
        uwr.downloadHandler = new DownloadHandlerFile(outPath);
        var asyncOp = uwr.SendWebRequest();
        asyncOp.completed += (ao) =>
        {
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log("Error");
            }
            else
            {
                Debug.Log("Complited");
            }
        };
    }
}
