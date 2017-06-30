//inspired by http://answers.unity3d.com/questions/45186/can-i-auto-run-a-script-when-editor-launches-or-a.html

using UnityEditor;
using UnityEngine;


[InitializeOnLoad]
public class Version {

    static Version() {
        //If you want the scene to be fully loaded before your startup operation,
        // for example to be able to use Object.FindObjectsOfType, you can defer your
        // logic until the first editor update, like this:
        EditorApplication.update += RunOnce;
    }

    static void RunOnce() {
        EditorApplication.update -= RunOnce;
        ReadVersionAndIncrement();
    }

    static void ReadVersionAndIncrement() {
        //the file name and path.  No path is the base of the Unity project directory (same level as Assets folder)
        string versionTextFileNameAndPath = "build.ver";

        string versionText = FileUtilities.ReadTextFile(versionTextFileNameAndPath);

        if (versionText != null) {
            versionText = versionText.Trim(); //clean up whitespace if necessary
            string[] lines = versionText.Split('.');

            int MajorVersion = int.Parse(lines[0]);
            int MinorVersion = int.Parse(lines[1]);
            int SubMinorVersion = int.Parse(lines[2]) + 1; //increment here

            Debug.Log("Major, Minor, SubMinor: " + MajorVersion + " " + MinorVersion + " " + SubMinorVersion);

            versionText = MajorVersion.ToString("0") + "." +
                          MinorVersion.ToString("0") + "." +
                          SubMinorVersion.ToString("0");

            Debug.Log("Version Incremented " + versionText);

            //save the file (overwrite the original) with the new version number
            FileUtilities.WriteTextFile(versionTextFileNameAndPath, versionText);
            //save the file to the Resources directory so it can be used by Game code
            FileUtilities.WriteTextFile("Assets/Resources/build.ver", versionText);

            //tell unity the file changed (important if the versionTextFileNameAndPath is in the Assets folder)
            AssetDatabase.Refresh();
        } else {
            //no file at that path, make it
            FileUtilities.WriteTextFile(versionTextFileNameAndPath, "0.0.0");
        }
    }
}