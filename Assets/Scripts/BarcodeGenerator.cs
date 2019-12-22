using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;

[RequireComponent(typeof(RawImage))]
public class BarcodeGenerator : MonoBehaviour
{
    [SerializeField] private BarcodeFormat format = BarcodeFormat.QR_CODE;
    [SerializeField] private int width = 384;
    [SerializeField] private int height = 384;
    private string s1;
    private string zCode = "11000111100";
    private string data;
    public RawImage cRawImage;
    private void Start()
    {
        if (Variables.recordQR)
        {
            s1 = Variables.commentData;
        }
        else
        {
            if (PlayerPrefs.GetString("role").Equals("Scouting"))
            {
                s1 = Variables.roleBits + Variables.preload + Variables.roundData + Variables.endData + Variables.teamData + PlayerPrefs.GetString("user") + Variables.commentData + "";
            }
            else if (PlayerPrefs.GetString("role").Equals("Strategy") || PlayerPrefs.GetString("role").Equals("Assistant")
             || PlayerPrefs.GetString("role").Equals("Fouls") || PlayerPrefs.GetString("role").Equals("Defense"))
                s1 = Variables.roleBits + PlayerPrefs.GetString("user") + Variables.teamData + Variables.commentData;
        }
        Debug.Log("BINARY STRING");
        Debug.Log(s1);
        Debug.Log(s1.Length);
        Encoding iso = Encoding.GetEncoding("ISO-8859-1");
        //Encoding utf8 = Encoding.UTF8;
        int temp = s1.Length;
        for (int i = 0; i < 8 - (temp % 8); i++)
        {
            s1 = s1 + zCode.Substring(i,1);
        }
        byte[] utfBytes = new byte[s1.Length / 8];
        for (int i = 0; i < s1.Length / 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                utfBytes[i] <<= 1;
                utfBytes[i] += (byte)(s1.Substring(i * 8 + j, 1).Equals("0") ? 0 : 1);
                //Debug.Log(utfBytes[i + j]);
            }
        }
        data = iso.GetString(utfBytes);
        Debug.Log("Bytes: " + utfBytes.Length);
        Debug.Log(data);
        Texture2D tex = GenerateBarcode(data, format, width, height);
        // Setup the RawImage
        cRawImage.texture = tex;
        cRawImage.rectTransform.sizeDelta = new Vector2(tex.width, tex.height);
    }
    private Texture2D GenerateBarcode(string data, BarcodeFormat format, int width, int height)
    {
        // Generate the BitMatrix
        var encOptions = new ZXing.Common.EncodingOptions { };
        encOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
        BitMatrix bitMatrix = new MultiFormatWriter()
            .encode(data, format, width, height, encOptions.Hints);
        // Generate the pixel array
        Color[] pixels = new Color[bitMatrix.Width * bitMatrix.Height];
        int pos = 0;
        /*for (int y = 0; y < bitMatrix.Height; y++)
        {
            for (int x = 0; x < bitMatrix.Width; x++)
            {
                pixels[pos++] = bitMatrix[x, y] ? Color.black : Color.white;
            }
        }*/
        for (int y = bitMatrix.Height - 1; y >= 0; y--)
        {
            for (int x = 0; x < bitMatrix.Width; x++)
            {
                pixels[pos++] = bitMatrix[x, y] ? Color.black : Color.white;
            }
        }
        // Setup the texture
        Texture2D tex = new Texture2D(bitMatrix.Width, bitMatrix.Height);
        tex.SetPixels(pixels);
        tex.Apply();
        return tex;
    }
}