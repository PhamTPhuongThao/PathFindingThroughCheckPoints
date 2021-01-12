using UnityEngine;
using UnityEditor;
using System.IO;

public class FindAllPaths : EditorWindow
{
   FindingPaths finding;
   string path;

   string myString;
   string TXTPath = "Assets/FindPathResult";
   [MenuItem("CustomEditor/Find All Paths A - B - A")]
   static void Init()
   {

      FindAllPaths findAllPaths = (FindAllPaths)EditorWindow.GetWindow(typeof(FindAllPaths));
      findAllPaths.Show();
   }

   void OnGUI()
   {
      GUILayout.Label("Base Settings", EditorStyles.boldLabel);

      if (GUILayout.Button("FIND"))
      {
         if (!Directory.Exists(TXTPath))
         {
            Directory.CreateDirectory(TXTPath);
         }
         if (!File.Exists(TXTPath + "/" + "result.txt"))
         {
            File.Create(TXTPath + "/" + "result.txt");
         }

         finding = new FindingPaths();
         WriteToResultFile();
      }
   }
   private void WriteToResultFile()
   {
      string path = TXTPath + "/" + "result.txt";
      StreamWriter writer = new StreamWriter(path, true);
      writer.WriteLine("Test");
      writer.Close();
      //Re-import the file to update the reference in the editor
      AssetDatabase.ImportAsset(path);
      // // TextAsset asset = Resources.Load("test");

      // // //Print the text from the file
      // // Debug.Log(asset.text);
   }
}
