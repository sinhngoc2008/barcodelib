using BarcodeLib;
using BarcodeStandard;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BarcodeLib
{
    public class Utils
    {
        public static IBarcodeLib InitBarcodeLib()
        {
            return new Barcode();
        }

        /// <summary>
        /// Gets the assembly version information.
        /// </summary>
        public static Version Version
        {
            get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version; }
        }

        /// <summary>
        /// Get save data from file
        /// </summary>
        /// <param name="fileContents"></param>
        /// <returns></returns>
        public static SaveData GetSaveDataFromFile(string fileContents)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
                SaveData saveData;
                using (TextReader reader = new StringReader(fileContents))
                {
                    saveData = (SaveData)serializer.Deserialize(reader);
                }

                return saveData;
            }//try
            catch (Exception ex)
            {
                throw new Exception("EGETIMAGEFROMXML-1: " + ex.Message);
            }//catch
        }

        /// <summary>
        /// Get Image from XML
        /// </summary>
        /// <param name="internalXML"></param>
        /// <returns></returns>
        public static Image GetImageFromXML(String internalXML)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
                SaveData result;
                using (TextReader reader = new StringReader(internalXML))
                {
                    result = (SaveData)serializer.Deserialize(reader);
                }
                //loading it to memory stream and then to image object
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(result.Image)))
                {
                    return Image.FromStream(ms);
                }//using
            }//try
            catch (Exception ex)
            {
                throw new Exception("EGETIMAGEFROMXML-1: " + ex.Message);
            }//catch
        }

        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="Data">Raw data to encode.</param>
        /// <returns>Image representing the barcode.</returns>
        public static Image DoEncode(TYPE iType, string Data)
        {
            using (Barcode b = new Barcode())
            {
                return b.Encode(iType, Data);
            }//using
        }
        
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="Data">Raw data to encode.</param>
        /// <param name="XML">XML representation of the data and the image of the barcode.</param>
        /// <returns>Image representing the barcode.</returns>
        public static Image DoEncode(TYPE iType, string Data, ref string XML)
        {
            using (Barcode b = new Barcode())
            {
                Image i = b.Encode(iType, Data);
                XML = b.XML;
                return i;
            }//using
        }
        
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="Data">Raw data to encode.</param>
        /// <param name="IncludeLabel">Include the label at the bottom of the image with data encoded.</param>
        /// <returns>Image representing the barcode.</returns>
        public static Image DoEncode(TYPE iType, string Data, bool IncludeLabel)
        {
            using (Barcode b = new Barcode())
            {
                b.IncludeLabel = IncludeLabel;
                return b.Encode(iType, Data);
            }//using
        }
        
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="data">Raw data to encode.</param>
        /// <param name="IncludeLabel">Include the label at the bottom of the image with data encoded.</param>
        /// <param name="Width">Width of the resulting barcode.(pixels)</param>
        /// <param name="Height">Height of the resulting barcode.(pixels)</param>
        /// <returns>Image representing the barcode.</returns>
        public static Image DoEncode(TYPE iType, string Data, bool IncludeLabel, int Width, int Height)
        {
            using (Barcode b = new Barcode())
            {
                b.IncludeLabel = IncludeLabel;
                return b.Encode(iType, Data, Width, Height);
            }//using
        }
        
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="Data">Raw data to encode.</param>
        /// <param name="IncludeLabel">Include the label at the bottom of the image with data encoded.</param>
        /// <param name="DrawColor">Foreground color</param>
        /// <param name="BackColor">Background color</param>
        /// <returns>Image representing the barcode.</returns>
        public static Image DoEncode(TYPE iType, string Data, bool IncludeLabel, Color DrawColor, Color BackColor)
        {
            using (Barcode b = new Barcode())
            {
                b.IncludeLabel = IncludeLabel;
                return b.Encode(iType, Data, DrawColor, BackColor);
            }//using
        }
        
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="Data">Raw data to encode.</param>
        /// <param name="IncludeLabel">Include the label at the bottom of the image with data encoded.</param>
        /// <param name="DrawColor">Foreground color</param>
        /// <param name="BackColor">Background color</param>
        /// <param name="Width">Width of the resulting barcode.(pixels)</param>
        /// <param name="Height">Height of the resulting barcode.(pixels)</param>
        /// <returns>Image representing the barcode.</returns>
        public static Image DoEncode(TYPE iType, string Data, bool IncludeLabel, Color DrawColor, Color BackColor, int Width, int Height)
        {
            using (Barcode b = new Barcode())
            {
                b.IncludeLabel = IncludeLabel;
                return b.Encode(iType, Data, DrawColor, BackColor, Width, Height);
            }//using
        }
        
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="Data">Raw data to encode.</param>
        /// <param name="IncludeLabel">Include the label at the bottom of the image with data encoded.</param>
        /// <param name="DrawColor">Foreground color</param>
        /// <param name="BackColor">Background color</param>
        /// <param name="Width">Width of the resulting barcode.(pixels)</param>
        /// <param name="Height">Height of the resulting barcode.(pixels)</param>
        /// <param name="XML">XML representation of the data and the image of the barcode.</param>
        /// <returns>Image representing the barcode.</returns>
        public static Image DoEncode(TYPE iType, string Data, bool IncludeLabel, Color DrawColor, Color BackColor, int Width, int Height, ref string XML)
        {
            using (Barcode b = new Barcode())
            {
                b.IncludeLabel = IncludeLabel;
                Image i = b.Encode(iType, Data, DrawColor, BackColor, Width, Height);
                XML = b.XML;
                return i;
            }//using
        }
    }
}
