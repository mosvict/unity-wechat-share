using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using System.IO;
using UnityEditor.iOS.Xcode;

namespace NS{

public class PostProcessBuildIOS {


	[PostProcessBuild]
	public static void ChangeXcodePlist(BuildTarget buildTarget, string pathToBuiltProject) {
		

		if (buildTarget == BuildTarget.iOS) {

			// Get plist
			string plistPath = pathToBuiltProject + "/Info.plist";
			PlistDocument plist = new PlistDocument();
			plist.ReadFromString(File.ReadAllText(plistPath));

			// Get root
			PlistElementDict rootDict = plist.root;

			// Change value of CFBundleVersion in Xcode plist


			PlistElementArray schemes =  rootDict.CreateArray ("LSApplicationQueriesSchemes");
			schemes.AddString ("line");

				rootDict.SetString ("NSPhotoLibraryAddUsageDescription", "Save Image");



			File.WriteAllText (plistPath, plist.WriteToString ());


		
		}
	}

	}

}
