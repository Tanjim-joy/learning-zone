Here's a comprehensive WPF notes file in both Bangla and English:

# Here's a comprehensive WPF notes file in both Bangla and English:

- [Introduction / ভূমিকা](#introduction--ভূমিকা)
- [XAML Basics / এক্সএএমএল মৌলিক ধারণা](#xaml-basics--এক্সএএমএল-মৌলিক-ধারণা)
- [Controls / কন্ট্রোলসমূহ](#controls--কন্ট্রোলসমূহ)
- [Layouts / লেআউটসমূহ](#layouts--লেআউটসমূহ)
- [Data Binding / ডেটা বাইন্ডিং](#data-binding--ডেটা-বাইন্ডিং)
- [MVVM Pattern / এমভিভিএম প্যাটার্ন](#mvvm-pattern--এমভিভিএম-প্যাটার্ন)
- [Styling & Templates / স্টাইলিং ও টেমপ্লেট](#styling--templates--স্টাইলিং-ও-টেমপ্লেট)
- [Commands / কমান্ডসমূহ](#commands--কমান্ডসমূহ)
- [Resources / রিসোর্সসমূহ](#resources--রিসোর্সসমূহ)
- [Common Tips / সাধারণ টিপস](#common-tips--সাধারণ-টিপস)

---

## Introduction / ভূমিকা

### English
WPF (Windows Presentation Foundation) is a UI framework for building desktop applications on Windows. It uses XAML for UI design and supports data binding, styling, and MVVM pattern.

### বাংলা
ডব্লিউপিএফ (উইন্ডোজ প্রেজেন্টেশন ফাউন্ডেশন) একটি ইউআই ফ্রেমওয়ার্ক যা উইন্ডোজে ডেস্কটপ অ্যাপ্লিকেশন তৈরি করতে ব্যবহৃত হয়। এটি ইউআই ডিজাইনের জন্য এক্সএএমএল ব্যবহার করে এবং ডেটা বাইন্ডিং, স্টাইলিং ও এমভিভিএম প্যাটার্ন সমর্থন করে।

---

## XAML Basics / এক্সএএমএল মৌলিক ধারণা

### English
XAML (eXtensible Application Markup Language) is used to define UI elements hierarchically.

### বাংলা
এক্সএএমএল (এক্সটেনসিবল অ্যাপ্লিকেশন মার্কআপ ল্যাঙ্গুয়েজ) ইউআই এলিমেন্টগুলোকে হায়ারার্কিক্যালি ডিফাইন করতে ব্যবহৃত হয়।

### Basic Structure / মৌলিক কাঠামো

```xml
<Window x:Class="MyApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Main Window" Height="450" Width="800">
    
    <Grid>
        <!-- UI Elements will go here -->
        <!-- ইউআই এলিমেন্ট এখানে বসবে -->
    </Grid>
</Window>
```

---

## Controls / কন্ট্রোলসমূহ

### Common Controls / সাধারণ কন্ট্রোলসমূহ

| Control Name | English | বাংলা |
|--------------|---------|-------|
| Button | Clickable button | ক্লিকযোগ্য বোতাম |
| TextBox | Text input field | টেক্সট ইনপুট ফিল্ড |
| Label | Static text | স্ট্যাটিক টেক্সট |
| ListBox | Selectable list | সিলেক্টযোগ্য তালিকা |
| ComboBox | Dropdown list | ড্রপডাউন তালিকা |
| CheckBox | Checkbox option | চেকবক্স অপশন |
| RadioButton | Single select option | একক সিলেক্ট অপশন |
| DataGrid | Tabular data display | ট্যাবুলার ডেটা প্রদর্শন |

### Example / উদাহরণ

```xml
<StackPanel Margin="10">
    <!-- Button / বোতাম -->
    <Button Content="Click Me" 
            Width="100" 
            Height="30" 
            Click="Button_Click"/>
    
    <!-- TextBox / টেক্সটবক্স -->
    <TextBox x:Name="txtInput" 
             Width="200" 
             Height="25" 
             Margin="0,5"/>
    
    <!-- CheckBox / চেকবক্স -->
    <CheckBox Content="Accept Terms" 
              IsChecked="True"/>
</StackPanel>
```

---

## Layouts / লেআউটসমূহ

### English
Layout panels help arrange UI elements. Common layouts:

### বাংলা
লেআউট প্যানেল ইউআই এলিমেন্ট সাজাতে সাহায্য করে। সাধারণ লেআউটসমূহ:

| Panel | English Description | বাংলা বর্ণনা |
|-------|---------------------|--------------|
| Grid | Tabular arrangement (rows & columns) | ট্যাবুলার সাজানো (সারি ও কলাম) |
| StackPanel | Vertical/horizontal stacking | উল্লম্ব/অনুভূমিক স্ট্যাকিং |
| WrapPanel | Wraps elements to next line | এলিমেন্ট পরবর্তী লাইনে র‍্যাপ করে |
| DockPanel | Docks to edges | প্রান্তে ডক করে |
| Canvas | Absolute positioning | অ্যাবসলিউট পজিশনিং |

### Grid Example / গ্রিড উদাহরণ

```xml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
        <RowDefinition Height="2*"/>
    </Grid.RowDefinitions>
    
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="Auto"/>
        <ColumnDefinition Width="*"/>
    </Grid.ColumnDefinitions>
    
    <!-- Row 0, Col 0 -->
    <Label Grid.Row="0" Grid.Column="0" Content="Name:"/>
    
    <!-- Row 0, Col 1 -->
    <TextBox Grid.Row="0" Grid.Column="1" Width="200"/>
    
    <!-- Row 1, Col 0 (spanning both columns) -->
    <Button Grid.Row="1" Grid.Column="0" 
            Grid.ColumnSpan="2" 
            Content="Submit"/>
</Grid>
```

---

## Data Binding / ডেটা বাইন্ডিং

### English
Data binding connects UI elements to data sources automatically.

### বাংলা
ডেটা বাইন্ডিং ইউআই এলিমেন্টকে ডেটা সোর্সের সাথে স্বয়ংক্রিয়ভাবে সংযুক্ত করে।

### Binding Modes / বাইন্ডিং মোড

| Mode | English | বাংলা |
|------|---------|-------|
| OneWay | UI updates when data changes | ডেটা পরিবর্তনে ইউআই আপডেট |
| TwoWay | Both UI and data update each other | ইউআই ও ডেটা পরস্পর আপডেট |
| OneTime | UI updates only once | ইউআই শুধু একবার আপডেট |
| OneWayToSource | Data updates when UI changes | ইউআই পরিবর্তনে ডেটা আপডেট |

### Basic Binding Example / মৌলিক বাইন্ডিং উদাহরণ

```xml
<TextBox Text="{Binding UserName, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
<TextBlock Text="{Binding WelcomeMessage}"/>
```

```csharp
public class MainViewModel : INotifyPropertyChanged
{
    private string _userName;
    public string UserName
    {
        get => _userName;
        set
        {
            _userName = value;
            OnPropertyChanged();
            WelcomeMessage = $"Welcome, {value}!";
        }
    }
    
    private string _welcomeMessage;
    public string WelcomeMessage
    {
        get => _welcomeMessage;
        set
        {
            _welcomeMessage = value;
            OnPropertyChanged();
        }
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
```

---

## MVVM Pattern / এমভিভিএম প্যাটার্ন

### English
MVVM (Model-View-ViewModel) separates UI (View) from business logic (ViewModel) and data (Model).

### বাংলা
এমভিভিএম (মডেল-ভিউ-ভিউমডেল) ইউআই (ভিউ) কে বিজনেস লজিক (ভিউমডেল) ও ডেটা (মডেল) থেকে আলাদা করে।

### Structure / কাঠামো

```
┌─────────┐     ┌───────────┐     ┌─────────┐
│  View   │◄───►│ ViewModel │◄───►│  Model  │
│ (XAML)  │     │   (C#)    │     │  (C#)   │
└─────────┘     └───────────┘     └─────────┘
```

### Complete MVVM Example / সম্পূর্ণ এমভিভিএম উদাহরণ

**Model / মডেল**
```csharp
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
```

**ViewModel / ভিউমডেল**
```csharp
public class UserViewModel : INotifyPropertyChanged
{
    private ObservableCollection<User> _users;
    private User _selectedUser;
    
    public ObservableCollection<User> Users
    {
        get => _users;
        set
        {
            _users = value;
            OnPropertyChanged();
        }
    }
    
    public User SelectedUser
    {
        get => _selectedUser;
        set
        {
            _selectedUser = value;
            OnPropertyChanged();
        }
    }
    
    public ICommand AddUserCommand { get; set; }
    public ICommand DeleteUserCommand { get; set; }
    
    public UserViewModel()
    {
        Users = new ObservableCollection<User>();
        AddUserCommand = new RelayCommand(AddUser, CanAddUser);
        DeleteUserCommand = new RelayCommand(DeleteUser, CanDeleteUser);
    }
    
    private void AddUser(object parameter)
    {
        Users.Add(new User { Id = Users.Count + 1, Name = "New User" });
    }
    
    private bool CanAddUser(object parameter)
    {
        return true;
    }
    
    private void DeleteUser(object parameter)
    {
        if (SelectedUser != null)
            Users.Remove(SelectedUser);
    }
    
    private bool CanDeleteUser(object parameter)
    {
        return SelectedUser != null;
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
```

**View / ভিউ**
```xml
<Window x:Class="MyApp.UserView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="User Management" Height="400" Width="600">
    
    <Window.DataContext>
        <local:UserViewModel/>
    </Window.DataContext>
    
    <Grid Margin="10">
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
        
        <DataGrid ItemsSource="{Binding Users}" 
                  SelectedItem="{Binding SelectedUser}"
                  AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="ID" Binding="{Binding Id}"/>
                <DataGridTextColumn Header="Name" Binding="{Binding Name}"/>
                <DataGridTextColumn Header="Email" Binding="{Binding Email}"/>
            </DataGrid.Columns>
        </DataGrid>
        
        <StackPanel Grid.Row="1" 
                    Orientation="Horizontal" 
                    HorizontalAlignment="Center" 
                    Margin="0,10">
            <Button Content="Add" 
                    Command="{Binding AddUserCommand}"
                    Width="80" Margin="5"/>
            <Button Content="Delete" 
                    Command="{Binding DeleteUserCommand}"
                    Width="80" Margin="5"/>
        </StackPanel>
    </Grid>
</Window>
```

---

## Styling & Templates / স্টাইলিং ও টেমপ্লেট

### English
Styles define visual properties, while templates control the entire visual structure.

### বাংলা
স্টাইল ভিজুয়াল প্রোপার্টি নির্ধারণ করে, আর টেমপ্লেট সম্পূর্ণ ভিজুয়াল স্ট্রাকচার নিয়ন্ত্রণ করে।

### Style Example / স্টাইল উদাহরণ

```xml
<Window.Resources>
    <!-- Button Style / বোতাম স্টাইল -->
    <Style x:Key="PrimaryButtonStyle" TargetType="Button">
        <Setter Property="Background" Value="#0078D4"/>
        <Setter Property="Foreground" Value="White"/>
        <Setter Property="FontWeight" Value="Bold"/>
        <Setter Property="Padding" Value="10,5"/>
        <Setter Property="Margin" Value="5"/>
        
        <!-- Hover effect / হোভার ইফেক্ট -->
        <Style.Triggers>
            <Trigger Property="IsMouseOver" Value="True">
                <Setter Property="Background" Value="#005A9E"/>
            </Trigger>
        </Style.Triggers>
    </Style>
    
    <!-- TextBox Style / টেক্সটবক্স স্টাইল -->
    <Style x:Key="TextBoxStyle" TargetType="TextBox">
        <Setter Property="Padding" Value="5"/>
        <Setter Property="BorderThickness" Value="1"/>
        <Setter Property="BorderBrush" Value="#CCCCCC"/>
        
        <Style.Triggers>
            <Trigger Property="IsFocused" Value="True">
                <Setter Property="BorderBrush" Value="#0078D4"/>
                <Setter Property="BorderThickness" Value="2"/>
            </Trigger>
        </Style.Triggers>
    </Style>
</Window.Resources>

<!-- Usage / ব্যবহার -->
<Button Style="{StaticResource PrimaryButtonStyle}" Content="Save"/>
<TextBox Style="{StaticResource TextBoxStyle}" Width="200"/>
```

### Control Template Example / কন্ট্রোল টেমপ্লেট উদাহরণ

```xml
<Window.Resources>
    <!-- Custom Button Template / কাস্টম বোতাম টেমপ্লেট -->
    <ControlTemplate x:Key="CustomButtonTemplate" TargetType="Button">
        <Border x:Name="border" 
                Background="{TemplateBinding Background}"
                BorderBrush="{TemplateBinding BorderBrush}"
                BorderThickness="{TemplateBinding BorderThickness}"
                CornerRadius="5">
            <ContentPresenter HorizontalAlignment="Center" 
                            VerticalAlignment="Center"/>
        </Border>
        
        <ControlTemplate.Triggers>
            <Trigger Property="IsMouseOver" Value="True">
                <Setter TargetName="border" Property="Background" Value="#E5E5E5"/>
            </Trigger>
            <Trigger Property="IsPressed" Value="True">
                <Setter TargetName="border" Property="Background" Value="#CCCCCC"/>
            </Trigger>
        </ControlTemplate.Triggers>
    </ControlTemplate>
</Window.Resources>

<Button Template="{StaticResource CustomButtonTemplate}" 
        Content="Custom Button" 
        Background="#F0F0F0" 
        Width="100" Height="30"/>
```

---

## Commands / কমান্ডসমূহ

### English
Commands handle user actions and enable/disable UI elements automatically.

### বাংলা
কমান্ড ইউজার অ্যাকশন হ্যান্ডেল করে এবং স্বয়ংক্রিয়ভাবে ইউআই এলিমেন্ট সক্রিয়/নিষ্ক্রিয় করে।

### RelayCommand Implementation / রিলে কমান্ড ইমপ্লিমেন্টেশন

```csharp
public class RelayCommand : ICommand
{
    private readonly Action<object> _execute;
    private readonly Predicate<object> _canExecute;
    
    public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }
    
    public bool CanExecute(object parameter)
    {
        return _canExecute == null || _canExecute(parameter);
    }
    
    public void Execute(object parameter)
    {
        _execute(parameter);
    }
    
    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
}
```

### Usage Example / ব্যবহারের উদাহরণ

```csharp
public class MainViewModel
{
    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }
    
    private string _data;
    public string Data
    {
        get => _data;
        set
        {
            _data = value;
            CommandManager.InvalidateRequerySuggested();
        }
    }
    
    public MainViewModel()
    {
        SaveCommand = new RelayCommand(Save, CanSave);
        CancelCommand = new RelayCommand(Cancel);
    }
    
    private void Save(object parameter)
    {
        // Save logic / সেভ লজিক
        MessageBox.Show($"Saved: {Data}");
    }
    
    private bool CanSave(object parameter)
    {
        return !string.IsNullOrWhiteSpace(Data);
    }
    
    private void Cancel(object parameter)
    {
        // Cancel logic / ক্যান্সেল লজিক
        Data = string.Empty;
    }
}
```

---

## Resources / রিসোর্সসমূহ

### English
Resources can be defined at different levels: Application, Window, or Control level.

### বাংলা
রিসোর্স বিভিন্ন লেভেলে ডিফাইন করা যায়: অ্যাপ্লিকেশন, উইন্ডো অথবা কন্ট্রোল লেভেলে।

### Resource Types / রিসোর্সের ধরন

```xml
<!-- Application Resources (App.xaml) / অ্যাপ্লিকেশন রিসোর্স -->
<Application.Resources>
    <SolidColorBrush x:Key="PrimaryColor" Color="#0078D4"/>
    <SolidColorBrush x:Key="ErrorColor" Color="#E81123"/>
    
    <Style x:Key="DefaultButtonStyle" TargetType="Button">
        <Setter Property="Background" Value="{StaticResource PrimaryColor}"/>
        <Setter Property="Foreground" Value="White"/>
    </Style>
</Application.Resources>

<!-- Window Resources / উইন্ডো রিসোর্স -->
<Window.Resources>
    <BooleanToVisibilityConverter x:Key="BoolToVis"/>
    
    <DataTemplate x:Key="UserTemplate">
        <StackPanel Orientation="Horizontal">
            <TextBlock Text="{Binding Name}" FontWeight="Bold"/>
            <TextBlock Text=" ("/>
            <TextBlock Text="{Binding Email}"/>
            <TextBlock Text=")"/>
        </StackPanel>
    </DataTemplate>
</Window.Resources>
```

### Converters / কনভার্টার

```csharp
public class BooleanToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool isVisible = (bool)value;
        return isVisible ? Visibility.Visible : Visibility.Collapsed;
    }
    
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Visibility visibility = (Visibility)value;
        return visibility == Visibility.Visible;
    }
}
```

---

## Common Tips / সাধারণ টিপস

### English Tips

1. **Use VirtualizingStackPanel** for large lists to improve performance
2. **Freeze brushes** when possible: `Freeze()` method
3. **Use Async/Await** for long-running operations
4. **Implement IDisposable** for cleanup
5. **Use ObservableCollection** for dynamic collections
6. **x:Name vs Name**: Use x:Name for XAML elements
7. **Debug DataBinding**: Add `PresentationTraceSources.TraceLevel=High`
8. **Use SharedSizeGroup** for consistent column sizing in Grid

### বাংলা টিপস

1. **ভার্চুয়ালাইজিং স্ট্যাকপ্যানেল** ব্যবহার করুন বড় লিস্টের জন্য (পারফরম্যান্স উন্নত করতে)
2. **ব্রাশ ফ্রিজ** করুন সম্ভব হলে: `Freeze()` মেথড
3. **Async/Await** ব্যবহার করুন লম্বা অপারেশনের জন্য
4. **IDisposable ইমপ্লিমেন্ট** করুন ক্লিনআপের জন্য
5. **ObservableCollection** ব্যবহার করুন ডায়নামিক কালেকশনের জন্য
6. **x:Name বনাম Name**: এক্সএএমএল এলিমেন্টের জন্য x:Name ব্যবহার করুন
7. **ডেটাবাইন্ডিং ডিবাগ**: `PresentationTraceSources.TraceLevel=High` যোগ করুন
8. **SharedSizeGroup** ব্যবহার করুন গ্রিডের কলাম সাইজিং কনসিস্টেন্ট রাখতে

### Debugging Tips / ডিবাগিং টিপস

```xml
<!-- Debug data binding / ডেটা বাইন্ডিং ডিবাগ -->
<TextBlock Text="{Binding UserName, 
                PresentationTraceSources.TraceLevel=High}"/>
```

```csharp
// Debug output / ডিবাগ আউটপুট
System.Diagnostics.Debug.WriteLine("Binding executed");
```

---

## Tips & Tricks / টিপস ও ট্রিকস

- Use `VirtualizingStackPanel` or enable virtualization for large `ItemsControl`/`ListBox`/`DataGrid` lists to improve performance.
- Freeze Freezable objects (Brushes, Geometries) with `Freeze()` when they are immutable to reduce memory and CPU overhead.
- Use `BitmapCache` on complex static visuals (e.g., large vector drawings) to reduce redraw cost.
- Prefer `DrawingVisual` for rendering many simple shapes instead of creating many `UIElement` instances.
- Avoid heavy work inside value converters; compute or prepare data in the ViewModel instead.
- Use `x:Shared="False"` for large resources that shouldn't be shared in memory by default.
- Split large `ResourceDictionary` files and merge them on demand to reduce startup cost.
- Use tools like Snoop, WPF Inspector, or Visual Studio Live Visual Tree for runtime debugging and visual inspection.
- Enable layout rounding and `SnapsToDevicePixels` to prevent blurry borders and text.
- Reduce visual-tree depth: flatter trees and simpler templates improve layout performance.
- Optimize images with `DecodePixelWidth`/`DecodePixelHeight` and use appropriately compressed formats.
- Keep long-running work off the UI thread (use `async/await` and `Task.Run`) and marshal small UI updates with `Dispatcher`.

---

## Quick Code Snippets / দ্রুত কোড স্নিপেট

### Window Centering / উইন্ডো সেন্টারিং
```xml
<Window WindowStartupLocation="CenterScreen"/>
```

### PasswordBox Binding / পাসওয়ার্ডবক্স বাইন্ডিং
```csharp
// Helper class for PasswordBox binding
public static class PasswordBoxHelper
{
    public static readonly DependencyProperty BoundPasswordProperty =
        DependencyProperty.RegisterAttached("BoundPassword", 
            typeof(string), typeof(PasswordBoxHelper), 
            new PropertyMetadata(string.Empty, OnBoundPasswordChanged));
    
    // Attached property implementation...
}
```

### Async Command / অ্যাসিংক কমান্ড
```csharp
public class AsyncRelayCommand : ICommand
{
    private readonly Func<Task> _execute;
    private bool _isExecuting;
    
    public AsyncRelayCommand(Func<Task> execute)
    {
        _execute = execute;
    }
    
    public async void Execute(object parameter)
    {
        _isExecuting = true;
        CommandManager.InvalidateRequerySuggested();
        
        await _execute();
        
        _isExecuting = false;
        CommandManager.InvalidateRequerySuggested();
    }
    
    public bool CanExecute(object parameter)
    {
        return !_isExecuting;
    }
    
    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
}
```

---

## Common Errors & Solutions / সাধারণ ত্রুটি ও সমাধান

| Error | Solution |
|-------|----------|
| Binding path not found | Check property names and DataContext |
| Object reference not set | Initialize collections in constructor |
| Threading issues | Use Dispatcher.Invoke for UI updates |
| Memory leaks | Unsubscribe from events, use WeakEvent pattern |

---

## Useful NuGet Packages / প্রয়োজনীয় নিউগেট প্যাকেজ

- **MVVM Toolkit** - Microsoft.Toolkit.Mvvm
- **PropertyChanged.Fody** - Automatic INotifyPropertyChanged
- **MahApps.Metro** - Modern UI styles
- **LiveCharts** - Charts and graphs
- **Entity Framework** - Database operations

---

## Resources for Learning / শেখার রিসোর্স

### English Resources
- [Microsoft WPF Documentation](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)
- [WPF Tutorial](https://www.wpf-tutorial.com/)
- [Stack Overflow WPF Tag](https://stackoverflow.com/questions/tagged/wpf)

### বাংলা রিসোর্স
- ইউটিউব টিউটোরিয়াল (বাংলায়)
- বাংলা প্রোগ্রামিং ব্লগ
- ফেসবুক গ্রুপ: ডব্লিউপিএফ ডেভেলপার বাংলাদেশ

---

**Happy WPF Coding! / ডব্লিউপিএফ কোডিংয়ে শুভকামনা!** 🚀

*Last Updated / সর্বশেষ আপডেট: 26 February 2026*

This comprehensive WPF notes file includes:

1. **Bilingual content** - Each section has both English and Bangla explanations
2. **Code examples** - Practical examples with both languages in comments
3. **Tables** - Easy reference tables for controls, layouts, binding modes
4. **Complete MVVM example** - Full implementation with explanation
5. **Styling and templates** - Both basic and advanced examples
6. **Commands** - RelayCommand implementation with usage
7. **Resources** - How to use resources and converters
8. **Tips** - Practical tips in both languages
9. **Common errors** - Solutions to frequent problems
10. **Quick references** - Snippets and shortcuts

The formatting makes it easy to read with clear section separators, and the bilingual approach helps Bangla-speaking developers understand WPF concepts in their native language while learning the English terminology used in the industry.