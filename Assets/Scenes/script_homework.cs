using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Runtime.Serialization;

public class script_homework : MonoBehaviour
{


    // Start is called before the first frame update
    [SerializeField] private bool boolperemen; // bool peremennaia
    [SerializeField] private int intperemen; // int peremennaia
    [SerializeField] private float floatperemen; // float peremennaia
    [SerializeField] private int[] intmassiv; //int massiv
    [SerializeField] private float[] floatmassiv; // float massiv
    [SerializeField] private int dlinamassiva;
    [SerializeField] private string path;

    [System.Serializable]
    public struct peremens_and_massivs
    {
        public int intperemen;
        public float floatperemen;
        public int[] intmassiv;
        public float[] floatmassiv;
        public bool boolperemen;
        public int dlinamassiva;
    }

    [ContextMenu("CheckBoolValue")]
    public bool Task1_sozdanie_bool_peremen()
    {
        return boolperemen;
    }

    [ContextMenu("DlinaMassiva")]
    public int Task2_sozdanie_dlina_massiva()
    {
        return dlinamassiva;
    }


    public int[] Int_Task3(int[] intmassiv)
    {

        intmassiv[0] = intperemen;
        for (int i = 1; i < Task2_sozdanie_dlina_massiva(); i++)
        {
            intmassiv[i] = (int)Mathf.Pow(intmassiv[i - 1], 2);
        }

        return intmassiv;
    }

    public float[] Float_Task3(float[] floatmassiv)
    {

        floatmassiv[0] = floatperemen;
        for (int i = 1; i < Task2_sozdanie_dlina_massiva(); i++)
        {
            floatmassiv[i] = Mathf.Pow(floatmassiv[i - 1], 2);
        }

        return floatmassiv;
    }

    public int[] Int_Task4(int[] intmassiv)
    {

        for (int i = 0; i < Task2_sozdanie_dlina_massiva(); i++)
        {
            intmassiv[i] = intmassiv[i] - 5;
        }

        return intmassiv;
    }

    public float[] Float_Task4(float[] floatmassiv)
    {

        for (int i = 0; i < Task2_sozdanie_dlina_massiva(); i++)
        {
            floatmassiv[i] = floatmassiv[i] - 5.0f;
        }

        return floatmassiv;
    }



    public void Task5_Int()
    {
        Int_Task3(intmassiv);
        Int_Task4(intmassiv);

    }

    public void Task5_Float()
    {
        Float_Task3(floatmassiv);
        Float_Task4(floatmassiv);
    }

    [ContextMenu("task5")]
    public void Task5()
    {
        if (Task1_sozdanie_bool_peremen())
        {
            Task5_Int();
        }
        else
        {
            Task5_Float();
        }
    }

    [ContextMenu("task6")]
    public void Task6()
    {
        if (Task1_sozdanie_bool_peremen())
        {
            Task6_Int();
        }
        else
        {
            Task6_Float();
        }
    }


    public void Task6_Int()
    {
        intperemen = 0;
        IntRef(ref intperemen);
        Int_Task3(intmassiv);
        Int_Task4(intmassiv);

    }


    public void Task6_Float()
    {
        float floatperemen = 0;
        FloatRef(ref floatperemen);

        Float_Task3(floatmassiv);
        Float_Task4(floatmassiv);

    }

    public void IntRef(ref int value)
    {
        value = value + 4;
    }


    public void FloatRef(ref float value)
    {
        value = value + 3.0f;
    }


    [ContextMenu("task7")]
    public void Task7()
    {
        if (Task1_sozdanie_bool_peremen())
        {
            Task7_Int();
        }
        else
        {
            Task7_Float();
        }
    }


    public void Task7_Int()
    {
        IntOut(out intperemen);
        Int_Task3(intmassiv);
        Int_Task4(intmassiv);

    }


    public void Task7_Float()
    {
        FloatOut(out floatperemen);
        Float_Task3(floatmassiv);
        Float_Task4(floatmassiv);

    }


    public void IntOut(out int value)
    {
        value = 10;
    }


    public void FloatOut(out float value)
    {
        value = 6.0f;
    }



    [ContextMenu("CreateFile_Task8")]
    public void SaveFile()
    {
        StreamWriter sw = new StreamWriter("test.txt");
        sw.Write("intperemen = ");
        sw.WriteLine(intperemen);
        sw.Write("floatperemen = ");
        sw.WriteLine(floatperemen);
        sw.Write("boolperemen = ");
        sw.WriteLine(boolperemen);
        sw.Write("dlinamassiva = ");
        sw.WriteLine(dlinamassiva);
        sw.Write("intmassiv = ");
        for (int i = 0; i < Task2_sozdanie_dlina_massiva(); i++)
        {
            sw.WriteLine(intmassiv[i] + " ");
        }
        sw.Write("floatmassiv = ");
        for (int i = 0; i < Task2_sozdanie_dlina_massiva(); i++)
        {
            sw.WriteLine(floatmassiv[i] + " ");
        }
        sw.Close();
        StreamReader sr = new StreamReader("test.txt");
        sr.Close();
    }

    [ContextMenu("SaveData")]
    public void SaveData()
    {
        peremens_and_massivs saveState = new peremens_and_massivs();
       // saveState.boolperemen = false;

        DirectoryInfo dir = new DirectoryInfo(@"./UpdateData");
        if (!dir.Exists)
        {
            dir.Create();
        }
        Debug.Log(dir);

        BinaryFormatter binaryFormatter = new BinaryFormatter();

        FileInfo saveFile = new FileInfo(@"./UpdateData/Save.txt");
        using (FileStream saveFileStream = new FileStream(dir +"Save.txt", FileMode.OpenOrCreate))
        {
            binaryFormatter.Serialize(saveFileStream, saveState);
        }
    }


    [ContextMenu("ReadeFile_Task10")]
    public void LoadeFromBinaryFormat()
    {
        peremens_and_massivs dataFromLoadBinery = new peremens_and_massivs();

        var currentDir = new DirectoryInfo(@"./UpdateData");

        var pathDir = currentDir + "/Save.txt";

        Debug.Log(pathDir);
        //path = Path.Combine(currentDir, "DataFile.txt");

        FileInfo loadFile = new FileInfo(pathDir);
        BinaryFormatter binFormat = new BinaryFormatter();

        if (loadFile.Exists)
        {
            using (FileStream loadFileStream = new FileStream(loadFile.FullName, FileMode.OpenOrCreate))
            {
                dataFromLoadBinery = (peremens_and_massivs)binFormat.Deserialize(loadFileStream);
            }
            Debug.Log("Binary data load Done!");
        }
        else
        {
            Debug.Log("Error loading binary data!");
        }
    }


}
