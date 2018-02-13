using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtil.Object
{
    public class ImageTransf
    {
        /// <summary>  
        /// 二进制流转图片  
        /// </summary>  
        /// <param name="streamByte">二进制流</param>  
        /// <returns>图片</returns>  
        public static System.Drawing.Image ReturnPhoto(byte[] streamByte)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(streamByte);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            return img;
        }
        /// <summary>  
        /// 图片转二进制  
        /// </summary>  
        /// <param name="imagepath">图片地址</param>  
        /// <returns>二进制</returns>  
        public static byte[] GetPictureData(string imagepath)
        {
            byte[] byData;
            //根据图片文件的路径使用文件流打开，并保存为byte[]   
            using (FileStream fs = new FileStream(imagepath, FileMode.Open))
            {
                //可以是其他重载方法   
                byData = new byte[fs.Length];
                fs.Read(byData, 0, byData.Length);
                fs.Close();
            }
            return byData;
        }
        /// <summary>  
        /// 图片转二进制  
        /// </summary>  
        /// <param name="imgPhoto">图片对象</param>  
        /// <returns>二进制</returns>  
        public static byte[] PhotoImageInsert(System.Drawing.Image imgPhoto)
        {
            //将Image转换成流数据，并保存为byte[]   
            MemoryStream mstream = new MemoryStream();
            imgPhoto.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] byData = new Byte[mstream.Length];
            mstream.Position = 0;
            mstream.Read(byData, 0, byData.Length);
            mstream.Close();
            return byData;
        }
    }
}
