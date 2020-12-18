using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

#if UNITY_IOS
using UnityEditor.iOS.Xcode;
using System;

public class JoypacXCodeBuildEditor
{
    [PostProcessBuildAttribute(1)]
    public static void OnPostProcessBuild(BuildTarget target, string path) {
        if (target != BuildTarget.iOS) {
            Debug.Log("Target is not iOS. JoypacXCodeBuildEditor will not run.");
            return;
        }

        // Read.
        string projectPath = UnityEditor.iOS.Xcode.PBXProject.GetPBXProjectPath(path);

        UnityEditor.iOS.Xcode.PBXProject project = new UnityEditor.iOS.Xcode.PBXProject();
        project.ReadFromString(File.ReadAllText(projectPath));

#if UNITY_2019_3_OR_NEWER
        string xcodeTarget = project.GetUnityFrameworkTargetGuid();
#else
            string xcodeTarget = project.TargetGuidByName("Unity-iPhone");
#endif
        //string targetFrameworkGUID = project.GetUnityFrameworkTargetGuid();
        //string targetMainGUID = project.GetUnityMainTargetGuid();


        AddFrameworks(project, xcodeTarget);
        AddBuildProperties(project, xcodeTarget);
       
        EditorPlist(path);


       
        // Write.
        File.WriteAllText(projectPath, project.WriteToString());
    }


    private static void ECKAddResourceGroupToiOSProject(string xcodePath, PBXProject proj, string target, string resourceDirectoryPath, string fileName) {
        
    }

    static void AddFrameworks(UnityEditor.iOS.Xcode.PBXProject project, string targetGUID) {
        project.AddFrameworkToProject(targetGUID, "AVFoundation.framework", true);
        project.AddFrameworkToProject(targetGUID, "Accelerate.framework", true);
        project.AddFrameworkToProject(targetGUID, "AdSupport.framework", true);
        project.AddFrameworkToProject(targetGUID, "AudioToolbox.framework", true);

        project.AddFrameworkToProject(targetGUID, "CoreLocation.framework", false);
        project.AddFrameworkToProject(targetGUID, "CoreMedia.framework", false);
        project.AddFrameworkToProject(targetGUID, "CoreMotion.framework", false);
        project.AddFrameworkToProject(targetGUID, "CoreTelephony.framework", false);

        project.AddFrameworkToProject(targetGUID, "MessageUI.framework", false);
        project.AddFrameworkToProject(targetGUID, "MobileCoreServices.framework", false);

        project.AddFrameworkToProject(targetGUID, "SafariServices.framework", false);
        project.AddFrameworkToProject(targetGUID, "StoreKit.framework", false);
        project.AddFrameworkToProject(targetGUID, "SystemConfiguration.framework", false);

        project.AddFrameworkToProject(targetGUID, "VideoToolbox.framework", false);

        project.AddFrameworkToProject(targetGUID, "WebKit.framework", false);

        project.AddFrameworkToProject(targetGUID, "libbz2.tbd", false);
        project.AddFrameworkToProject(targetGUID, "libc++.tbd", false);
        project.AddFrameworkToProject(targetGUID, "libresolv.9.tbd", false);
        project.AddFrameworkToProject(targetGUID, "libsqlite3.tbd", false);
        project.AddFrameworkToProject(targetGUID, "libxml2.tbd", false);
        project.AddFrameworkToProject(targetGUID, "libz.tbd", false);

    }

    static void AddEmbedFrameworks(UnityEditor.iOS.Xcode.PBXProject project, string targetGUID) {
        //      project.AddFileToBuild(targetGUID, project.AddFile("usr/lib/libresolv.9.tbd", "Libraries/libresolv.9.tbd", PBXSourceTree.Sdk));		
    }

    static void AddBuildProperties(UnityEditor.iOS.Xcode.PBXProject project, string targetGUID) {
        project.AddBuildProperty(targetGUID, "OTHER_LDFLAGS", "-ObjC");
    }


    public static void CopyDirectory(string sourceDirPath, string SaveDirPath) {
        
    }

    static void EditorPlist(string path) {
        string plistPath = path + "/Info.plist";
        PlistDocument plist = new PlistDocument();
        plist.ReadFromString(File.ReadAllText(plistPath));
        PlistElementDict rootDict = plist.root;

        rootDict.SetString("GADApplicationIdentifier", "ca-app-pub-0000000000000000/0000000000");
        rootDict.SetBoolean("GADIsAdManagerApp", true);
        PlistElementDict securityDict = rootDict.CreateDict("NSAppTransportSecurity");
        securityDict.SetBoolean("NSAllowsArbitraryLoads", true);
        plist.WriteToFile(plistPath);

   



    }

    static void EditorUnityAppController(string path) {
    }
}
#endif