using Lab6.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Lab6.ViewModels
{
    class MyViewModel : INotifyPropertyChanged
    {
        int date = DateTime.Now.Day;

        //private int[] y = new int[31]; //и У
        List<int> y = new List<int>();
        private int result;    //Результат умножения. Обратите внимание, что все поля приватные
        private int selectedY; //выбранные поля ComboBox

        public void fArrY(List<int> y)
        {
            for(int i = 1; i <= date; ++i)
            {
                y.Add(i);

            }
        }


        public List<int> Y
        {
            get
            {
                fArrY(y);
                return y;
            }
        }

        public int Result
        {
            get
            {
                return result;
            }

            set
            {
                result = value;
                RaisePropertyChanged("Result");
            }
        }

        

        public int SelectedY
        {
            get {
                return selectedY;
                    }
            set
            {
                selectedY = value;
                RaisePropertyChanged("SelectedY");
            }
        }

        private RelayCommand clickCommand;
        public RelayCommand ClickCommand
        {
            get
            {
                return clickCommand ??
                  (clickCommand = new RelayCommand(obj =>
                  {  //при нажатии на кнопку производится расчет результата умножения
                      Numbers numbers = new Numbers();  //создадим объект класса модели
                      Result = numbers.returnResult(SelectedY, date); //вызовем функцию расчета результата и присвоим ее значение
                      //соответствующему полю Result
                      
                  }));
            }
        }


        private RelayCommand resetCommand;
        public RelayCommand ResetCommand
        {
            get
            {
                return resetCommand ??
                  (resetCommand = new RelayCommand(obj =>
                  {
                      Result = 0; //обнуление результата
                      SelectedY = 0; //Х и У
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }


        public MyViewModel() //пустой конструктор
        {
        }
    }
}
