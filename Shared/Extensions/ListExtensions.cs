namespace ExtensaoCurricular.Shared.Extensions;

public static class ListExtensions
{
    public static bool IsNullOrEmpty<T>(this List<T> list)
    {
        return list is null || list.Count == 0;
    }

    public static bool IsNotNullOrEmpty<T>(this List<T> list)
    {
        return !list.IsNullOrEmpty();
    }
}