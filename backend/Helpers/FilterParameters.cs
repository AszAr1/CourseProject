namespace Kinopoisk.Helpers;

public class FilterParameters {
    OrderMethod? order;
    public string? Order { 
        get {
            if (order == null) 
                return null;

            return Enum.GetName(typeof(OrderMethod), order)!;
        } 
        set {
            if (value == null) {
                order = null;
                return;
            }
            order = Enum.Parse<OrderMethod>(value);
        } 
    }
    MediaType? type;
    public string? Type { 
        get {
            if (type == null) 
                return null;

            return Enum.GetName(typeof(MediaType), type)!;
        } 
        set {
            if (value == null) {
                type = null;
                return;
            }
            type = Enum.Parse<MediaType>(value);
        } 
    }
    public int? RatingFrom { get; set; }
    public int? RatingTo { get; set; }
    public int? YearFrom { get; set; }
    public int? YearTo { get; set; }
    public string? Keyword { get; set; }
    public int? Page { get; set; }
}