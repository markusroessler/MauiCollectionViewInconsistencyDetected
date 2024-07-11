using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CollectionViewGroup;

public partial class MainPage : ContentPage
{
    public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(ObservableCollection<GroupItemVO>), typeof(MainPage));
    public ObservableCollection<GroupItemVO> Items
    {
        get => (ObservableCollection<GroupItemVO>)GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    public MainPage()
	{
		InitializeComponent();
        BindingContext = this;
        Items = new ObservableCollection<GroupItemVO>();
	}

    async void AddItems_Clicked(System.Object sender, System.EventArgs e)
    {
        if (Items.Count == 0)
        {
            Console.WriteLine("Adding groups");
            var grp = new GroupItemVO { Title = "Group 1" };
            grp.Add($"Item x");
            Items.Add(grp);

            await Task.Delay(2000);

            grp = new GroupItemVO { Title = "Group 2" };
            grp.Add($"Item x");
            Items.Add(grp);
        }

        await Task.Delay(2000);
        Items[0].Add($"Item x");

        //Console.WriteLine("Adding group 1 items");
        //Items[0].Add("Item 1");
        //Items[0].Add("Item 2");
        //Items[0].Add("Item 3");
        //Items[0].Add("Item 4");

        // for (int i = 0; i < 10; i++)
        // {
        //     Console.WriteLine("Adding group 2 item");
        //     Items[0].Add($"Item {i}");
        //     // Items[1].Add($"Item {i}");
        // }
    }
}

public class GroupItemVO : ObservableCollection<string>
{
	public string? Title { get; set; }
}


