using System.Threading.Tasks;
using AppLetGo.Service;
using ZXing.Mobile;
using Xamarin.Forms;
using QR_Code_Scanner.Droid.Services;

[assembly: Dependency(typeof(QrScanningService))]

namespace QR_Code_Scanner.Droid.Services
{
    public class QrScanningService : IQrScanningService
    {
        public async Task<string> ScanAsync()
        {
            var optionsDefault = new MobileBarcodeScanningOptions();
            var optionsCustom = new MobileBarcodeScanningOptions();

            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Scan the QR Code",
                BottomText = "Please Wait",
            };

            var scanResult = await scanner.Scan(optionsCustom);
            return scanResult.Text;
        }
    }
}