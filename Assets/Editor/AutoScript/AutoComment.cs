﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class AutoComment : UnityEditor.AssetModificationProcessor{
	private static string COMMENT = "/*NEVER BUG*/\n";
	public static void OnWillCreateAsset(string path){
		path = path.Replace(".meta","");
		var index = path.LastIndexOf(".");
		var file = path.Substring(index);
		if(file != ".cs" && file != ".js" && file != ".boo"){
			return;
		}
		index = Application.dataPath.LastIndexOf("Assets");
		path = Application.dataPath.Substring(0,index)+path;
		file = System.IO.File.ReadAllText(path);
		if(!file.Contains(COMMENT)){
			file = file.Insert(0,COMMENT);
		}
		System.IO.File.WriteAllText(path,file);
		AssetDatabase.Refresh();
	}
}