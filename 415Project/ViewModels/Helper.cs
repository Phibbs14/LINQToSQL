using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _415Project.ViewModels
{
    class Helper
    {
        public static bool IsValid(DependencyObject win)
        {
            if (win == null)
                return true;
            return !Validation.GetHasError(win) &&
                LogicalTreeHelper.GetChildren(win)
                .OfType<DependencyObject>()
                .All(IsValid);
        }

        public static int GetTermWeight(int index, Weighted item)
        {
            return (int)typeof(Weighted).GetProperty("Term" + index).GetValue(item);
        }
    }
}
