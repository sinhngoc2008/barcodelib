using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;


namespace BarcodeLib
{
    public interface IBarcodeLib : IDisposable
    {
        #region Properties
        /// <summary>
        /// Gets or sets the raw data to encode.
        /// </summary>
        string RawData { get; set; }

        /// <summary>
        /// Gets the encoded value.
        /// </summary>
        string EncodedValue{ get;}

        /// <summary>
        /// Gets the Country that assigned the Manufacturer Code.
        /// </summary>
        string Country_Assigning_Manufacturer_Code { get; }

        /// <summary>
        /// Gets or sets the Encoded Type (ex. UPC-A, EAN-13 ... etc)
        /// </summary>
        TYPE EncodedType { get; set; }
        
        /// <summary>
        /// Gets the Image of the generated barcode.
        /// </summary>
        Image EncodedImage { get; }

        /// <summary>
        /// Gets or sets the color of the bars. (Default is black)
        /// </summary>
        Color ForeColor { get; set; }

        /// <summary>
        /// Gets or sets the background color. (Default is white)
        /// </summary>
        Color BackColor { get; set; }

        /// <summary>
        /// Gets or sets the label font. (Default is Microsoft Sans Serif, 10pt, Bold)
        /// </summary>
        Font LabelFont { get; set; }

        /// <summary>
        /// Gets or sets the location of the label in relation to the barcode. (BOTTOMCENTER is default)
        /// </summary>
        LabelPositions LabelPosition { get; set; }
        
        /// <summary>
        /// Gets or sets the degree in which to rotate/flip the image.(No action is default)
        /// </summary>
        RotateFlipType RotateFlipType { get; set; }

        /// <summary>
        /// Gets or sets the width of the image to be drawn. (Default is 300 pixels)
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the image to be drawn. (Default is 150 pixels)
        /// </summary>
        int Height { get; set; }

        /// <summary>
        ///   If non-null, sets the width of a bar. <see cref="Width"/> is ignored and calculated automatically.
        /// </summary>
        int? BarWidth { get; set; }

        /// <summary>
        ///   If non-null, <see cref="Height"/> is ignored and set to <see cref="Width"/> divided by this value rounded down.
        /// </summary>
        /// <remarks><para>
        ///   As longer barcodes may be more difficult to align a scanner gun with,
        ///   growing the height based on the width automatically allows the gun to be rotated the
        ///   same amount regardless of how wide the barcode is. A recommended value is 2.
        ///   </para><para>
        ///   This value is applied to <see cref="Height"/> after after <see cref="Width"/> has been
        ///   calculated. So it is safe to use in conjunction with <see cref="BarWidth"/>.
        /// </para></remarks>
        double? AspectRatio { get; set; }

        /// <summary>
        /// Gets or sets whether a label should be drawn below the image. (Default is false)
        /// </summary>
        bool IncludeLabel { get; set; }

        /// <summary>
        /// Alternate label to be displayed.  (IncludeLabel must be set to true as well)
        /// </summary>
        String AlternateLabel { get; set; }

        /// <summary>
        /// Try to standardize the label format. (Valid only for EAN13 and empty AlternateLabel, default is true)
        /// </summary>
        bool StandardizeLabel { get; set;}

        /// <summary>
        /// Gets or sets the amount of time in milliseconds that it took to encode and draw the barcode.
        /// </summary>
        double EncodingTime { get; set; }

        /// <summary>
        /// Gets the XML representation of the Barcode data and image.
        /// </summary>
        string XML { get; }

        /// <summary>
        /// Gets or sets the image format to use when encoding and returning images. (Jpeg is default)
        /// </summary>
        ImageFormat ImageFormat { get; set; }
        /// <summary>
        /// Gets the list of errors encountered.
        /// </summary>
        List<string> Errors { get; }
        
        /// <summary>
        /// Gets or sets the alignment of the barcode inside the image. (Not for Postnet or ITF-14)
        /// </summary>
        AlignmentPositions Alignment { get; set; }

        /// <summary>
        /// Gets a byte array representation of the encoded image. (Used for Crystal Reports)
        /// </summary>
         byte[] Encoded_Image_Bytes { get; }

        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="Width">Width of the resulting barcode.(pixels)</param>
        /// <param name="Height">Height of the resulting barcode.(pixels)</param>
        /// <returns>Image representing the barcode.</returns>
        Image Encode(TYPE iType, string StringToEncode, int Width, int Height);

        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="DrawColor">Foreground color</param>
        /// <param name="BackColor">Background color</param>
        /// <param name="Width">Width of the resulting barcode.(pixels)</param>
        /// <param name="Height">Height of the resulting barcode.(pixels)</param>
        /// <returns>Image representing the barcode.</returns>
        Image Encode(TYPE iType, string StringToEncode, Color ForeColor, Color BackColor, int Width, int Height);

        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="DrawColor">Foreground color</param>
        /// <param name="BackColor">Background color</param>
        /// <returns>Image representing the barcode.</returns>
        Image Encode(TYPE iType, string StringToEncode, Color ForeColor, Color BackColor);

        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <returns>Image representing the barcode.</returns>
        Image Encode(TYPE iType, string StringToEncode);

        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.
        /// </summary>
        /// <returns>
        /// Returns a string containing the binary value of the barcode. 
        /// This also sets the internal values used within the class.
        /// </returns>
        /// <param name="raw_data" >Optional raw_data parameter to for quick barcode generation</param>
        string GenerateBarcode(string raw_data = "");

        /// <summary>
        /// Gets a bitmap representation of the encoded data.
        /// </summary>
        /// <returns>Bitmap of encoded value.</returns>
        Bitmap Generate_Image();

        /// <summary>
        /// Gets the bytes that represent the image.
        /// </summary>
        /// <param name="savetype">File type to put the data in before returning the bytes.</param>
        /// <returns>Bytes representing the encoded image.</returns>
        byte[] GetImageData(SaveTypes savetype);

        /// <summary>
        /// Saves an encoded image to a specified file and type.
        /// </summary>
        /// <param name="Filename">Filename to save to.</param>
        /// <param name="FileType">Format to use.</param>
        void SaveImage(string Filename, SaveTypes FileType);

        /// <summary>
        /// Saves an encoded image to a specified stream.
        /// </summary>
        /// <param name="stream">Stream to write image to.</param>
        /// <param name="FileType">Format to use.</param>
        void SaveImage(Stream stream, SaveTypes FileType);

        /// <summary>
        /// Returns the size of the EncodedImage in real world coordinates (millimeters or inches).
        /// </summary>
        /// <param name="Metric">Millimeters if true, otherwise Inches.</param>
        /// <returns></returns>
        ImageSize GetSizeOfImage(bool Metric);

        #endregion

        #region Function 

        #endregion
    }
}
