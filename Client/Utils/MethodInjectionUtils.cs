namespace ExtensaoCurricular.Client.Utils;

public class MethodInjectionUtils
{
    public Dictionary<string, Action> Methods { get; set; } = new();
    public Dictionary<string, Func<Task>> AsyncMethods { get; set; } = new();

    public void Add(string methodName, Action action) => Methods.Add(methodName, action);
    public void AddAsyncMethod(string methodName, Func<Task> task) => AsyncMethods.Add(methodName, task);
    public void Remove(string methodName) => Methods.Remove(methodName);
    public void RemoveAsyncMethod(string methodName) => AsyncMethods.Remove(methodName);
    public void Invoke(string methodName) => Methods.GetValueOrDefault(methodName).Invoke();
    public async Task InvokeAsync(string methodName) => await AsyncMethods.GetValueOrDefault(methodName).Invoke();
}