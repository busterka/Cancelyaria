using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;


namespace Cancelyaria.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageCheck.xaml
    /// </summary>
    public partial class PageCheck : Page
    {
        public PageCheck()
        {
            InitializeComponent();
            GenerateReceiptAndCodes();
        }

        private void GenerateReceiptAndCodes()
        {
            
            string receiptText = "Ваш чек:\n" +
                                 "Товары: 3\n" +
                                 "Итого: 1500 руб\n" +
                                 "Спасибо за покупку!";
            txtReceipt.Text = receiptText;

          
            var barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions
                {
                    Height = 100,
                    Width = 300,
                    Margin = 10
                },
                Renderer = new BitmapRenderer()
            };

            var barcodeBitmap = barcodeWriter.Write("ORDER123456");

            
            imgBarcode.Source = BitmapToImageSource(barcodeBitmap);

            
            var qrWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = 200,
                    Width = 200,
                    Margin = 1
                }
            };
            var qrBitmap = qrWriter.Write("https://example.com/order/ORDER123456");

            imgQRCode.Source = BitmapToImageSource(qrBitmap);
        }

        private BitmapSource BitmapToImageSource(System.Drawing.Bitmap bitmap)
        {
            var hBitmap = bitmap.GetHbitmap();
            try
            {
                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                NativeMethods.DeleteObject(hBitmap);
            }
        }

        private static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("gdi32.dll")]
            [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
            public static extern bool DeleteObject(IntPtr hObject);
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
