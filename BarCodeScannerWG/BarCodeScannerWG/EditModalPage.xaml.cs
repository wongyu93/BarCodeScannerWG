using BarCodeScannerWG.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarCodeScannerWG
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditModalPage
    {
        public EditModalPage(ObservableCollection<MainListItem> _listToEdit, int _mainListIndex, int _productListIndex)
        {
            InitializeComponent();
        }
    }
}