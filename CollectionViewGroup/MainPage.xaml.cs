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
        Console.WriteLine("Adding groups");
        Items.Add(new GroupItemVO { Title = "Group 1" });
        Items.Add(new GroupItemVO { Title = "Group 2" });

        //Console.WriteLine("Adding group 1 items");
        //Items[0].Add("Item 1");
        //Items[0].Add("Item 2");
        //Items[0].Add("Item 3");
        //Items[0].Add("Item 4");

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Adding group 2 item");
            Items[0].Add($"Item {i}");
            Items[1].Add($"Item {i}");
            // await Task.Delay(1000);
        }
    }
}

public class GroupItemVO : ObservableCollection<string>
{
	public string? Title { get; set; }
}


