using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMTest.Models;

namespace MVVMTest.ViewModels {

    class CoordinateObservable : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        public double X {
            get => Value.X;
            set {
                Value.X = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("X"));
            }
        }

        public double Y {
            get => Value.Y;
            set {
                Value.Y = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Y"));
            }
        }

        public object Tag {
            get => Value.Tag;
            set {
                Value.Tag = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tag"));
            }
        }


        public CoordinateObservable(Coordinate coordinate) => Value = coordinate;

        public static implicit operator Coordinate(CoordinateObservable coordinateObservable) => coordinateObservable.Value;
        public static implicit operator CoordinateObservable(Coordinate coordinate) => new CoordinateObservable(coordinate);

        private readonly Coordinate Value;


    }

}
