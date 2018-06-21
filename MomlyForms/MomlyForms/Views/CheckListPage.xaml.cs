using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MomlyForms.Models;
using MomlyForms.Data;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections;

namespace MomlyForms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckListPage : ContentPage
	{
        List<CheckListItem> allItems = new List<CheckListItem>();
        List<CheckListItem> itemsChecked = new List<CheckListItem>();

        public CheckListPage ()
		{
			InitializeComponent ();
            Title = "Huskeliste";
            InitializeAllItems();

            ItemsCheckedText();
        }

        private void ItemsCheckedText()
        {
            StringBuilder builder = new StringBuilder();

            if (itemsChecked.Count == 0)
                textLabel.Text = "Du har endnu ikke valgt nogle ting du skal huske til turen";
            else
            {
                builder.Append("Du har nu husket:\n");

                int count = 0;
                foreach (var item in itemsChecked)
                {
                    count++;
                    if (count == 3)
                    {
                        builder.Append("\n");
                        count = 0;
                    }
                    builder.Append(item.Description + ", ");
                }
                textLabel.Text = builder.ToString().TrimEnd(',', ' ');
            }
        }


        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            foreach (var item in allItems.Where(x => x.Checked == false))
                if (itemsChecked.Contains(item))
                    itemsChecked.Remove(item);

            foreach (var item in allItems.Where(x => x.Checked == true))
                if (!itemsChecked.Contains(item))
                    itemsChecked.Add(item);

            itemsChecked.Reverse();
            ItemsCheckedText();
        }

        private async void InitializeAllItems()
        {
            RestService restService = new RestService();
            allItems = await restService.RefreshCheckListItems();
            checkList.ItemsSource = allItems;
        }
    }
}