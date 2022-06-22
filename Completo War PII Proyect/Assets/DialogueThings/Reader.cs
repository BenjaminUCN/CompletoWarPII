using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Reader : MonoBehaviour
{
    public TextAsset AssetData;

    public int[] lineNumbers;
    public int lineNumber = 0;
    public string language = "ESP";

    public void getLines(Dialogue dialogue){
        for(int i = 0;i<lineNumbers.Length;i++){
            //get text from the file
            string lineText = ReadLine(lineNumbers[i]);
            //set the text in the dialogue object
            dialogue.sentences[i] = lineText;
        }
    }

    string ReadLine(int line){
        string[] lines = AssetData.text.Split(char.Parse("\n"));
        
        //select language
        int LanguageIndex;
        switch (language)
        {
            case "ESP":
                LanguageIndex = 0;
                break;
            case "ENG":
                LanguageIndex = 1;
                break;
            default:
                LanguageIndex = 0;
                break;
        }

        //find line
        for(int i = 0;i<lines.Length;i++){
            if(i==line){
                string[] data = lines[i].Split(char.Parse(";"));
                
                //return text line
                return data[LanguageIndex];
            }
        }
        
        return "-missing dialogue-";
    }
}
