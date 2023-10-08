using System;
using YooAsset;

public class GameEncryption : IEncryptionServices
{
    public EncryptResult Encrypt(EncryptFileInfo fileInfo)
    {
        EncryptResult encryptResult = new EncryptResult();
        encryptResult.LoadMethod = EBundleLoadMethod.Normal;
        int offset = 32;
        // var temper = new byte[fileData.Length + offset];
        // Buffer.BlockCopy(fileData, 0, temper, offset, fileData.Length);
        // encryptResult.EncryptedData = fileInfo;
        return encryptResult;
    }
}