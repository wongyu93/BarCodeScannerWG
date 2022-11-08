using BarCodeScannerWG.Models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BarCodeScannerWG.Helps
{
    public class ExportToShare
    {
        private static readonly ExportToShare instance = new ExportToShare();

        private ExportToShare()
        {

        }

        public static ExportToShare Instance
        {
            get
            {
                return instance;
            }
        }

        public async Task<string> ToExcel(IList<ProductListItem> listExcel, string title, int hearderID)
        {
            var result = await PermissionMethods.AskForRequiredStoragePermission();
            //if (!result)
            //{
            //    IPermissionSettingsService service = DependencyService.Get<IPermissionSettingsService>();
            //    service.OpenAppSettings();
            //}

            string path = string.Empty;

            if (listExcel.Count > 0)
            {
                IWorkbook workbook = new XSSFWorkbook();
                try
                {
                    string date = DateTime.Now.ToShortDateString();
                    date = date.Replace("/", "_");

                    path = Path.Combine(FileSystem.CacheDirectory, string.Format("{0}_{1}", hearderID.ToString(), title) + "_" + date + ".xlsx");

                    ISheet sheet1 = workbook.CreateSheet(string.Format("{0}_{1}", hearderID.ToString(), title));
                    sheet1.SetColumnWidth(0, 7000);
                    sheet1.SetColumnWidth(1, 7000);
                    //sheet1.SetColumnWidth(2, 3000);
                    //sheet1.SetColumnWidth(3, 4000);
                    //sheet1.SetColumnWidth(4, 3000);
                    //sheet1.SetColumnWidth(5, 3000);


                    ICellStyle style1 = workbook.CreateCellStyle();
                    style1.Alignment = HorizontalAlignment.Center;
                    style1.VerticalAlignment = VerticalAlignment.Center;
                    //style.ShrinkToFit = true; //지정된 사이즈보다 텍스트가 클 경우 자동 맞춤

                    ICellStyle style2 = workbook.CreateCellStyle();
                    style2.Alignment = HorizontalAlignment.Center;
                    style2.VerticalAlignment = VerticalAlignment.Center;
                    style2.FillForegroundColor = IndexedColors.LightYellow.Index;
                    style2.FillPattern = FillPattern.SolidForeground;

                    IRow headerRow = sheet1.CreateRow(0);
                    ICell cell = headerRow.CreateCell(0, NPOI.SS.UserModel.CellType.String);
                    cell.SetCellValue("barcode");
                    cell.CellStyle = style2;

                    cell = headerRow.CreateCell(1, NPOI.SS.UserModel.CellType.String);
                    cell.SetCellValue("scantime");
                    cell.CellStyle = style1;

                    ICellStyle styleEdit2 = workbook.CreateCellStyle();
                    styleEdit2.Alignment = HorizontalAlignment.Center;

                    int i = 1;
                    foreach (var d in listExcel)
                    {
                        IRow row = sheet1.CreateRow(i);
                        ICell bodyCell = row.CreateCell(0, NPOI.SS.UserModel.CellType.String);
                        bodyCell.SetCellValue((string)d.DisplayName);

                        bodyCell = row.CreateCell(1, NPOI.SS.UserModel.CellType.String);
                        bodyCell.SetCellValue(d.ScanTime.ToString("yyyy-MM-dd HH:mm:ss"));

                        //row.CreateCell(4, NPOI.SS.UserModel.CellType.Numeric).SetCellValue(d.Cost);
                        //row.CreateCell(5, NPOI.SS.UserModel.CellType.Numeric).SetCellValue(d.Price);
                        i++;
                    }

                    using (FileStream sw = File.Create(path))
                    {
                        workbook.Write(sw);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                    await Application.Current.MainPage.DisplayAlert("Err", ex.Message, "OK");
                }
                finally
                {
                    workbook.Close();
                }
            }

            return path;
        }
    }
}
