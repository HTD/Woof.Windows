using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Woof.WindowsEx;
using MVVMTest.Models;

namespace MVVMTest.ViewModels {

    class MainVM : ViewModelBase {

        public FullyObservableCollection<CoordinateObservable> Items { get; set; }
            = new FullyObservableCollection<CoordinateObservable>(new CoordinateCollection(8).Select(i => new CoordinateObservable(i)));

        public override void Execute(object parameter) {

            if (parameter is string c) switch (c) {
                    case "Add":
                        Items.Add(Coordinate.Random);
                        break;
                    case "Clear":
                        Items.Clear();
                        break;
                    case "Update":
                        for (int i = 0, n = Items.Count; i < n; i++) {
                            Items[i].X = Math.Sin(Items[i].X);
                            Items[i].Y = Math.Cos(Items[i].Y);

                            //var changed = Items[i];
                            //Items[i] = null;
                            //changed.X = 0;
                            //Items[i] = changed;
                            ////Items[i].Y = 0;

                        }
                        break;
                }

        }

    }
}
