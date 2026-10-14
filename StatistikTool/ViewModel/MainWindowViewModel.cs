using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StatistikTool.ViewModel
{
    public class MainWindowViewModel : BaseModel
    {


        public MainWindowViewModel()
        {
            Datas = new ObservableCollection<Data>(Data.AlleLesen());
        }
        private ObservableCollection<Data> _datas;

        public ObservableCollection<Data> Datas
        {
            get { return _datas; }
            set
            {
                _datas = value;
                OnPropertyChanged("Datas");
            }
        }




    }
}
