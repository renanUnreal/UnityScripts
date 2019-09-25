using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CaptureScreenshot : MonoBehaviour
{
    private string _caminho;
    public bool takingScreenshot = false;

    public void Capture_Screenshot()
    {
        StartCoroutine(TakeScreenshotAndSave());
    }

    // esta Função é a responsável por tirar a foto e salvar na galeria do celular
    // Link do Plugin que tem que baixar//////
    // basta apenas importar para o projeto e tudo ja estará funcionando
    //https://assetstore.unity.com/packages/tools/integration/native-gallery-for-android-ios-112630



    private IEnumerator TakeScreenshotAndSave()
    {
        takingScreenshot = true;
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        // Save the screenshot to Gallery/Photos
        string name = string.Format("{0}_Capture{1}_{2}.png", Application.productName, "{0}", System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
        Debug.Log("Permission result: " + NativeGallery.SaveImageToGallery(ss, Application.productName + " Captures", name));
        ScreenCapture.CaptureScreenshot(name, 2);//Unity < 2017
                                                       //ScreenCapture.CaptureScreenshot(nomeImagem, 2); //Unity >= 2017
        takingScreenshot = false;
    }


    public void TiraFoto()
    {
      //  string nomeImagem = _caminho + DateTime.Now.Ticks.ToString() + ".png";
        //O recurso Application.Cap...está obsoleta na versão 2017 da Unity.

   //     ScreenCapture.CaptureScreenshot(nomeImagem, 2);//Unity < 2017
                                                       //ScreenCapture.CaptureScreenshot(nomeImagem, 2); //Unity >= 2017
    }


}