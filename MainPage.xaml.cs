using System.Collections.ObjectModel;

namespace Maui_IssueRowDefinitionAuto;

public partial class MainPage : ContentPage
{
    private ObservableCollection<TestItem> TestItems = new ObservableCollection<TestItem>();

    public MainPage()
	{
		InitializeComponent();
        for (int i = 0; i < 5; i++)
        {
            TestItems.Add(new TestItem() { Id = i + 1, ItemName = "TestItem" + (i + 1) });
        }
        BindableLayout.SetItemsSource(slTestItems, TestItems);
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        var nextId = TestItems.Count == 0 ? 1 : TestItems.AsEnumerable().Max(x => x.Id) + 1;
        TestItems.Add(new TestItem() { Id = nextId, ItemName = "TestItem" + nextId });
    }

    private void btnDelete_Clicked(object sender, EventArgs e)
    {
        TestItems.Remove((sender as Button).BindingContext as TestItem);
    }

}

public class TestItem
{
    public int Id { get; set; }
    public string ItemName { get; set; }
}
