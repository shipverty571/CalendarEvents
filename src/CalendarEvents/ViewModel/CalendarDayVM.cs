using CommunityToolkit.Mvvm.ComponentModel;
using Model;

namespace ViewModel;

public class CalendarDayVM : ObservableObject
{
    public CalendarDay CalendarDay { get; set; }
    
    public bool IsDateOfMonth { get; set; }
}