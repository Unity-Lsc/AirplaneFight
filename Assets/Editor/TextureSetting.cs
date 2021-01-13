/****************************************************
    文件：TextureSetting.cs
	作者：LSC
    邮箱: 314623971@qq.com
    日期：2021/1/13 23:17:7
	功能：图片格式规范工具
*****************************************************/

using UnityEditor;

public class TextureSetting : AssetPostprocessor
{
    private void OnPreprocessTexture() {
        TextureImporter importer = (TextureImporter)assetImporter;
        importer.textureType = TextureImporterType.Sprite;
    }
}