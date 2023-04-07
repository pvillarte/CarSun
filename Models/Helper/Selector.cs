using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;

namespace CarSun.Models.Helper;

public class Selector<T> where T : class
{
    public static List<SelectListItem> GetSelectList(ICollection<T> items, string valueField, string displayField, int? selectedValue= -1)
    {
        var selectList = new SelectList(items, valueField, displayField, selectedValue).ToList();
        selectList.Insert(0, new SelectListItem { Text = "Seleccione...", Value = "-1" });
        return selectList;
    }
}
