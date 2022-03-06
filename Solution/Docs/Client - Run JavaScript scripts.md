### How to call JavaScript from Blazor 
1. Place your `.js` file under `Client` > `wwwroot` > `scripts`. 

2. Create new `JsWrapper` in `Client.Infrastructure` > `JavaScriptWrappers`.  
   `OffcanvasJsWrapper : JsWrapperBase`

3. _Registering is handled by extension method. It's scope is transient._

4. Inject former `JsWrapper` in code.  
```
//Fields
private readonly OffcanvasJsWrapper _offcanvasJsWrapper;

//Constructors 
public HomePage(OffcanvasJsWrapper offcanvasJsWrapper)
    => _offcanvasJsWrapper = OffcanvasJsWrapper;
```

5. Initialize in `AfterRenderAsync()` method.
```
protected override async Task OnAfterRenderAsync(bool firstRender)
{
    await base.OnAfterRenderAsync(firstRender);

    if (firstRender)
        await _offcanvasJsWrapper.InitializeAsync();
}
```

6. Use your methods.  
`await _offcanvasJsWrapper.ShowAsync();`

7. Dispose your service. 
```
public partial class MyComponent : IAsyncDisposable 
{
    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        return _offcanvasJsWrapper.DisposeAsync();
    }
}
```