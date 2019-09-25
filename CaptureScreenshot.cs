using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelBusters;
using VoxelBusters.NativePlugins;

public class CaptureScreenshot : MonoBehaviour
{
    private string _caminho;
    public bool takingScreenshot = false;
    private bool isSharing = false;

    public void Capture_Screenshot()
    {
        // chamada da função que salva a foto
        StartCoroutine(TakeScreenshotAndSave());
        // chamada da função que faz o share
        StartCoroutine(CaptureShare());
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

        /// Share Opição
       
        takingScreenshot = false;



    }


    public void TiraFoto()
    {
        //  string nomeImagem = _caminho + DateTime.Now.Ticks.ToString() + ".png";
        //O recurso Application.Cap...está obsoleta na versão 2017 da Unity.

        //     ScreenCapture.CaptureScreenshot(nomeImagem, 2);//Unity < 2017
        //ScreenCapture.CaptureScreenshot(nomeImagem, 2); //Unity >= 2017
    }




    // //////////////////////////////////////////////  esta parte do codigo é responsavel pelo share
    public void ShareSocialMedia()
    {
        isSharing = true;
    }

    private void LateUpdate()
    {
        if (isSharing == true)
        {
            isSharing = false;
            StartCoroutine(CaptureShare());
        }
    }


    IEnumerator CaptureShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D texture = ScreenCapture.CaptureScreenshotAsTexture();

        ShareSocial(texture);
    }




    // Função que Faz o Share 
    // você precisa importar o Plugin do Link abaixo
    //https://assetstore.unity.com/packages/tools/integration/cross-platform-native-plugins-lite-version-37272
    // depois basta add ela a função de Screenshot
    public void ShareSocial(Texture2D texture) {

        ShareSheet _shareSheet = new ShareSheet();
        // esta mensagem vai junto com a Foto
        _shareSheet.Text = " Testando App";
        _shareSheet.AttachImage(texture);
        _shareSheet.URL = "https://www.instagram.com/renanluanasantosrodrigues/?hl=pt-br";

        NPBinding.Sharing.ShowView(_shareSheet, FinishSharing);
    }
    private void FinishSharing(eShareResult _result)
    {
        Debug.Log(_result);

    }

    ////////////////////////////////// fim da parte responsavel pelo share

}